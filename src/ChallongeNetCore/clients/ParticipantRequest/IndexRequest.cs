using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.ParticipantRequest
{
    public class IndexRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }

        public IndexRequest(ChallongeV1Connection connection)
        {
            this.connection = connection;
        }


        public async Task<IList<Tournament>> SendAsync(string TournamentIdentifier)
        {
            string apiUrl = $"/tournaments/{TournamentIdentifier}/participants";
            const string method = "GET";
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.ListOfTournaments(jsonString);
        }
    }
}
