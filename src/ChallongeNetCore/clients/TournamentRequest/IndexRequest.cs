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

        public async Task<IList<Tournament>> SendAsync()
        {
            const string apiUrl = "/tournaments";
            const string method = "GET";
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.ListOfTournaments(jsonString);
        }
    }
}
