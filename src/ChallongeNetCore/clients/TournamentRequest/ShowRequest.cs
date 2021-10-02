namespace ChallongeNetCore.clients.TournamentRequest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShowRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }

        private string TournamentIdentitier { get; set; }

        public ShowRequest(ChallongeV1Connection connection, string Identifier)
        {
            this.Connection = connection;
            this.TournamentIdentitier = Identifier;
        }

        public ShowRequest SetIncludeParticipants(bool value) { parameters["include_participants"] = value ? 1 : 0; return this; }

        public ShowRequest SetIncludeMatches(bool value) { parameters["include_matches"] = value ? 1 : 0; return this; }
        
        public async Task<Tournament> SendAsync()
        {
            string apiUrl = $"/tournaments/{TournamentIdentitier}";
            const string method = "GET";
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Tournament(jsonString);
        }
    }
}
