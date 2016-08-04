using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.TournamentRequest
{
    public class FinalizeRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }

        private string TournamentIdentitier { get; set; }

        public FinalizeRequest(ChallongeV1Connection connection, string Identifier)
        {
            this.Connection = connection;
            this.TournamentIdentitier = Identifier;
        }

        public FinalizeRequest SetIncludeParticipants(bool value) { parameters["include_participants"] = value ? 1 : 0; return this; }
        public FinalizeRequest SetIncludeMatches(bool value) { parameters["include_matches"] = value ? 1 : 0; return this; }

        public async Task<Tournament> SendAsync()
        {
            string apiUrl = $"/tournaments/{TournamentIdentitier}/finalize";
            const string method = "POST";
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Tournament(jsonString);
        }
    }
}
