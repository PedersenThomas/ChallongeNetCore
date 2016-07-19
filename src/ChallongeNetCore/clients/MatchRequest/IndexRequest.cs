using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.MatchRequest
{
    public class IndexRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }
        public string TournamentIdentifier { get; private set; }

        public IndexRequest(ChallongeV1Connection connection, string tournamentIdentifier)
        {
            this.connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
        }

        public IndexRequest setState(MatchIndexState value) { parameters["state"] = value; return this; }
        public IndexRequest setParticipantId(int value) { parameters["participant_id"] = value; return this; }

        public async Task<IEnumerable<Match>> SendAsync()
        {
            string apiUrl = $"/tournaments/{this.TournamentIdentifier}/matches";
            const string method = "GET";
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.ListOfMatches(jsonString);
        }

        public enum MatchIndexState
        {
            all,
            pending,
            in_progress,
            ended
        }
    }
}
