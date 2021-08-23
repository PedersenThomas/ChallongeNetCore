using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChallongeNetCore
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class ChallongeV1Connection
    {
        private const string BaseUrl = "https://api.challonge.com/v1";

        private readonly NetworkCredential credential;

        //TODO (TP): Remove
        public Action<string> DebugWriteline { get; set; }

        public ChallongeV1Connection(string username, string apiKey)
        {
            this.Username = username;
            this.Apikey = apiKey;
            this.credential = new NetworkCredential(this.Username, this.Apikey);

            this.Tournament = new TournamentClient(this);
            this.Participant = new ParticipantClient(this);
            this.Match = new MatchClient(this);
        }

        public string Username { get; private set; }
        public string Apikey { get; private set; }

        public TournamentClient Tournament { get; private set; }
        public ParticipantClient Participant { get; private set; }
        public MatchClient Match { get; private set; }

        internal async Task<string> MakeJSONRequestAsync(string apiUrl, string httpMethod, IDictionary<string, dynamic> Parameters = null, IDictionary<string, dynamic> queryParameters = null)
        {
            const string ResponseType = "json";
            var url = string.Format("{0}{1}.{2}", BaseUrl, apiUrl, ResponseType);
            
            using (var client = new HttpClient())
            {
                ApplyAuth(client);

                HttpContent content = null;
                bool containsQueryParameters = false;
                switch (httpMethod)
                {
                    case "GET":
                        if (Parameters != null && Parameters.Count > 0)
                        {
                            url += "?" + this.DictionaryQuerystring(Parameters);
                            containsQueryParameters = true;
                        }

                        break;
                    case "POST":
                    case "PUT":
                    case "DELETE":
                        content = constructJsonContent(Parameters);
                        break;
                    default:
                        throw new ChallongeException("Unknown HttpMethod: " + httpMethod);
                }

                if(queryParameters != null && queryParameters.Count > 0)
                {
                    url += (containsQueryParameters ? "&" : "?") + this.DictionaryQuerystring(queryParameters);
                }
                DebugWriteline?.Invoke(httpMethod + " " + url);

                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri(url);
                request.Method = parseMethod(httpMethod);
                if (Parameters != null && Parameters.Count > 0)
                {
                    request.Content = content;
                }

                HttpResponseMessage response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                DebugResponse(response, responseContent);

                if (response.IsSuccessStatusCode)
                {
                    return responseContent;
                }
                
                throw new ChallongeException(responseContent);
            }
            throw new ChallongeException("Something went wrong sending the request.");
        }

        private void ApplyAuth(HttpClient client)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{this.Username}:{this.Apikey}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            DebugWriteline?.Invoke(client.DefaultRequestHeaders.ToString());
        }

        private HttpContent constructJsonContent(IDictionary<string, dynamic> dictionary)
        {
            var json = JsonSerializer.Serialize(dictionary);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            DebugWriteline?.Invoke("JSON: " + json);

            return content;
        }

        private static HttpMethod parseMethod(string httpMethod)
        {
            switch (httpMethod)
            {
                case "GET":
                    return HttpMethod.Get;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                case "DELETE":
                    return HttpMethod.Delete;
                default:
                    throw new ChallongeException("Unknown HttpMethod: " + httpMethod);
            }
        }

        private string DictionaryQuerystring(IDictionary<string, dynamic> dict)
        {
            var queryList = new List<string>();

            foreach (KeyValuePair<string, dynamic> pair in dict)
            {
                var data = System.Uri.EscapeDataString(pair.Value.ToString());
                queryList.Add(string.Format("{0}={1}", pair.Key, data));
            }


            return String.Join("&", queryList);
        }

        private void DebugRequest(HttpClient client, HttpRequestMessage request)
        {
            DebugWriteline?.Invoke("---Request---");
            DebugWriteline?.Invoke(request.ToString());
            DebugWriteline?.Invoke("Request Headers");
            foreach (var item in request.Headers)
            {
                DebugWriteline?.Invoke(item.Key + " -> " + String.Join("", item.Value));
            }
            DebugWriteline?.Invoke("Client Default Headers");
            foreach (var item in client.DefaultRequestHeaders)
            {
                DebugWriteline?.Invoke(item.Key + " -> " + String.Join("", item.Value));
            }
            DebugWriteline?.Invoke("Request Properties");
            foreach (var item in request.Properties)
            {
                DebugWriteline?.Invoke(item.Key + " -> " + item.Value);
            }
        }

        private void DebugResponse(HttpResponseMessage response, string responseContent)
        {
            DebugWriteline?.Invoke("---Response---");
            DebugWriteline?.Invoke(response.ToString());
            DebugWriteline?.Invoke("Request Headers");


            DebugWriteline?.Invoke(responseContent);
        }
    }
}
