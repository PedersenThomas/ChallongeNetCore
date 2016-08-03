using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.ParticipantRequest
{
    public class ShowRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }
        public string TournamentIdentifier { get; private set; }
        public string ParticipantIdentifier { get; private set; }

        public ShowRequest(ChallongeV1Connection connection, string tournamentIdentifier, string participantIdentifier)
        {
            this.connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
            this.ParticipantIdentifier = participantIdentifier;
        }

        public async Task<Participant> SendAsync()
        {
            string apiUrl = $"/tournaments/{this.TournamentIdentifier}/participants/{this.ParticipantIdentifier}";
            const string method = "GET";
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Participant(jsonString);
        }
    }
}
