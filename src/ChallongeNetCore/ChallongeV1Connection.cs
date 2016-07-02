using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            //this.Participant = new ParticipantClient(this);
            //this.Match = new MatchClient(this);
        }

        public string Username { get; private set; }
        public string Apikey { get; private set; }

        public TournamentClient Tournament { get; private set; }
        //public ParticipantClient Participant { get; private set; }
        //public MatchClient Match { get; private set; }

        internal async Task<string> MakeJSONRequestAsync(string apiUrl, string httpMethod, IDictionary<string, dynamic> dictionary = null)
        {
            const string ResponseType = "json";
            var url = string.Format("{0}{1}.{2}", BaseUrl, apiUrl, ResponseType);
            
            using (var client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes($"{this.Username}:{this.Apikey}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                DebugWriteline?.Invoke(client.DefaultRequestHeaders.ToString());

                HttpContent content = null;
                switch (httpMethod)
                {
                    case "GET":
                        if (dictionary != null && dictionary.Count > 0)
                        {
                            url += "?" + this.DictionaryQuerystring(dictionary);
                        }

                        break;
                    case "POST":
                    case "PUT":
                    case "DELETE":
                        var encoding = new UTF8Encoding();
                        var json = JsonConvert.SerializeObject(dictionary);
                        content = new StringContent(json);
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        DebugWriteline?.Invoke("JSON: " + json);
                        break;
                    default:
                        throw new ChallongeException("Unknown HttpMethod: " + httpMethod);
                }

                HttpResponseMessage response;
                HttpMethod method = default(HttpMethod);
                switch (httpMethod)
                {
                    case "GET":
                        method = HttpMethod.Get;
                        break;
                    case "POST":
                        method = HttpMethod.Post;
                        break;
                    case "PUT":
                        method = HttpMethod.Put;
                        break;
                    case "DELETE":
                        method = HttpMethod.Delete;
                        break;
                    default:
                        throw new ChallongeException("Unknown HttpMethod: " + httpMethod);
                }

                
                HttpRequestMessage request = new HttpRequestMessage();
                DebugWriteline?.Invoke(httpMethod + " " + url);
                        
                request.RequestUri = new Uri(url);
                request.Method = method;
                request.Content = content;
                        
                //DebugRequest(client, request);

                response = await client.SendAsync(request);

                var responseString = await response.Content.ReadAsStringAsync();
                
                DebugResponse(response);
                DebugWriteline?.Invoke(responseString);

                if (response.IsSuccessStatusCode)
                {
                    return responseString;
                }
                else
                {
                    throw new ChallongeException(responseString);
                }
            }
            throw new ChallongeException("Something went wrong sending the request.");
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

        private void DebugResponse(HttpResponseMessage response)
        {
            DebugWriteline?.Invoke("---Response---");
            DebugWriteline?.Invoke(response.ToString());
            DebugWriteline?.Invoke("Request Headers");
        }

        private string DictionaryQuerystring(IDictionary<string, dynamic> dict)
        {
            var queryList = new List<string>();

            foreach (KeyValuePair<string, dynamic> pair in dict)
            {
                var data = System.Uri.EscapeDataString(pair.Value.ToString());
                queryList.Add(string.Format("{0}={1}", pair.Key, data ));
            }


            return String.Join("&", queryList);
        }
    }
}
