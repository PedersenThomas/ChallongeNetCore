namespace ChallongeNetCore.clients.ParticipantRequest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UpdateRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }

        public string TournamentIdentifier { get; private set; }

        public string ParticipantIdentifier { get; private set; }

        public UpdateRequest(ChallongeV1Connection connection, string tournamentIdentifier, string participantIdentifier)
        {
            this.Connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
            this.ParticipantIdentifier = participantIdentifier;
        }

        public UpdateRequest SetName(string value) { parameters["name"] = value; return this; }

        public UpdateRequest SetChallongeUsername(string value) { parameters["challonge_username"] = value; return this; }

        public UpdateRequest SetEmail(string value) { parameters["email"] = value; return this; }

        public UpdateRequest SetSeed(int value) { parameters["seed"] = value; return this; }

        public UpdateRequest SetMisc(string value) { parameters["misc"] = value; return this; }


        public async Task<Participant> SendAsync()
        {
            string apiUrl = $"/tournaments/{TournamentIdentifier}/participants/{this.ParticipantIdentifier}";
            const string method = "PUT";
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Participant(jsonString);
        }
    }
}
