using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.TournamentRequest
{
    public class IndexRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }

        public IndexRequest(ChallongeV1Connection connection)
        {
            this.connection = connection;
        }

        public IndexRequest setState(TournamentIndexState value) { parameters["state"] = value; return this; }
        public IndexRequest setType(TournamentType value) { parameters["type"] = value; return this; }
        public IndexRequest setCreatedAfter(DateTime value) { parameters["created_after"] = value; return this; }
        public IndexRequest setCreatedBefore(DateTime value) { parameters["created_before"] = value; return this; }
        public IndexRequest setSubdomain(string value) { parameters["subdomain"] = value; return this; }


        public async Task<IList<Tournament>> SendAsync()
        {
            const string apiUrl = "/tournaments";
            const string method = "GET";
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.ListOfTournaments(jsonString);
        }

        public enum TournamentIndexState
        {
            all,
            pending,
            in_progress,
            ended
        }
    }
}
