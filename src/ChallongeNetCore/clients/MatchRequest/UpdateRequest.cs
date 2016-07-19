using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.MatchRequest
{
    public class UpdateRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }
        public string TournamentIdentifier { get; private set; }
        public int MatchId { get; private set; }

        public UpdateRequest(ChallongeV1Connection connection, string tournamentIdentifier, int matchId)
        {
            this.connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
            this.MatchId = matchId;
        }

        public UpdateRequest setScoresCsv(string value) { parameters["scores_csv"] = value; return this; }
        public UpdateRequest setWinnerId(int value) { parameters["winner_id"] = value; return this; }
        public UpdateRequest setPlayer1Votes(int value) { parameters["player1_votes"] = value; return this; }
        public UpdateRequest setPlayer2Votes(int value) { parameters["player2_votes"] = value; return this; }

        public async Task<Match> SendAsync()
        {
            string apiUrl = $"/tournaments/{this.TournamentIdentifier}/matches/{MatchId}";
            const string method = "PUT";
            var finalParameters = new Dictionary<string, dynamic> { { "match", parameters } };
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, finalParameters);
            return Deserializer.Match(jsonString);
        }
    }
}
