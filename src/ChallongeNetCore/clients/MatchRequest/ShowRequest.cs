namespace ChallongeNetCore.clients.MatchRequest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShowRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }

        public string TournamentIdentifier { get; private set; }

        public int MatchId { get; private set; }

        public ShowRequest(ChallongeV1Connection connection, string tournamentIdentifier, int matchId)
        {
            this.connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
            this.MatchId = matchId;
        }

        //Not Implemented Yet
        //public ShowRequest setIncludeAttachments(bool value) { parameters["include_attachments"] = value ? 1 : 0; return this; }
        
        public async Task<Match> SendAsync(string TournamentIdentifier)
        {
            string apiUrl = $"/tournaments/{TournamentIdentifier}/matches";
            const string method = "GET";
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Match(jsonString);
        }
    }
}
