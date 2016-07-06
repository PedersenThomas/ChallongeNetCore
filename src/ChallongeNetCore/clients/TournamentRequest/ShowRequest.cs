using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.TournamentRequest
{
    public class ShowRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }

        private string TournamentIdentitier { get; set; }

        public ShowRequest(ChallongeV1Connection connection, string Identifier)
        {
            this.connection = connection;
            this.TournamentIdentitier = Identifier;
        }

        public ShowRequest setIncludeParticipants(bool value) { parameters["include_participants"] = value ? 1 : 0; return this; }
        public ShowRequest setIncludeMatches(bool value) { parameters["include_matches"] = value ? 1 : 0; return this; }
        
        public async Task<Tournament> SendAsync()
        {
            string apiUrl = $"/tournaments/{TournamentIdentitier}";
            const string method = "GET";
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Tournament(jsonString);
        }
    }
}
