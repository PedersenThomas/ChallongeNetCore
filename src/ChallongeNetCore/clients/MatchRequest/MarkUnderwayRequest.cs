namespace ChallongeNetCore.clients.MatchRequest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MarkUnderwayRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }
        public string TournamentIdentifier { get; private set; }
        public int MatchId { get; private set; }

        public MarkUnderwayRequest(ChallongeV1Connection connection, string tournamentIdentifier, int matchId)
        {
            this.Connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
            this.MatchId = matchId;
        }

        public async Task<Match> SendAsync()
        {
            string apiUrl = $"/tournaments/{this.TournamentIdentifier}/matches/{MatchId}/mark_as_underway";
            const string method = "POST";
            var finalParameters = new Dictionary<string, dynamic> { { "match", parameters } };
            var jsonString = await this.Connection.MakeJSONRequestAsync(apiUrl, method, finalParameters);
            return Deserializer.Match(jsonString);
        }
    }
}
