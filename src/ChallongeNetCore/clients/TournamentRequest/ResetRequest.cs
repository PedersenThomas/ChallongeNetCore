using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.TournamentRequest
{
    public class ResetRequest
    {
        private IDictionary<string, dynamic> queryParameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }

        private string TournamentIdentitier { get; set; }

        public ResetRequest(ChallongeV1Connection connection, string Identifier)
        {
            this.Connection = connection;
            this.TournamentIdentitier = Identifier;
        }

        public ResetRequest SetIncludeParticipants(bool value) { queryParameters["include_participants"] = value ? 1 : 0; return this; }
        public ResetRequest SetIncludeMatches(bool value) { queryParameters["include_matches"] = value ? 1 : 0; return this; }

        public async Task<Tournament> SendAsync()
        {
            string apiUrl = $"/tournaments/{TournamentIdentitier}/reset";
            const string method = "POST";
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, null, queryParameters);
            return Deserializer.Tournament(jsonString);
        }
    }
}
