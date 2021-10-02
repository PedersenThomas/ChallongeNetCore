namespace ChallongeNetCore.clients.ParticipantRequest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShowRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }

        public string TournamentIdentifier { get; private set; }

        public string ParticipantIdentifier { get; private set; }

        public ShowRequest(ChallongeV1Connection connection, string tournamentIdentifier, string participantIdentifier)
        {
            this.Connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
            this.ParticipantIdentifier = participantIdentifier;
        }

        public async Task<Participant> SendAsync()
        {
            string apiUrl = $"/tournaments/{this.TournamentIdentifier}/participants/{this.ParticipantIdentifier}";
            const string method = "GET";
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Participant(jsonString);
        }
    }
}
