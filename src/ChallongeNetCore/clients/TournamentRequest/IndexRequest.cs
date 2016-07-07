using System;
using System.Collections.Generic;
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

        public IndexRequest SetState(TournamentIndexState value) { parameters["state"] = value; return this; }
        public IndexRequest SetType(TournamentType value) { parameters["type"] = value; return this; }
        public IndexRequest SetCreatedAfter(DateTime value) { parameters["created_after"] = value; return this; }
        public IndexRequest SetCreatedBefore(DateTime value) { parameters["created_before"] = value; return this; }
        public IndexRequest SetSubdomain(string value) { parameters["subdomain"] = value; return this; }


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
