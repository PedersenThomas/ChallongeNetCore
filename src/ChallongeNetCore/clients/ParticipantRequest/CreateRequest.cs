namespace ChallongeNetCore.clients.ParticipantRequest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CreateRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }

        public string TournamentIdentifier {get; private set;}

        public CreateRequest(ChallongeV1Connection connection, string tournamentIdentifier)
        {
            this.Connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
        }

        public CreateRequest SetName(string value) { parameters["name"] = value; return this; }

        public CreateRequest SetChallongeUsername(string value) { parameters["challonge_username"] = value; return this; }

        public CreateRequest SetEmail(string value) { parameters["email"] = value; return this; }

        public CreateRequest SetSeed(int value) { parameters["seed"] = value; return this; }

        public CreateRequest SetMisc(string value) { parameters["misc"] = value; return this; }


        public async Task<Participant> SendAsync()
        {
            string apiUrl = $"/tournaments/{TournamentIdentifier}/participants";
            const string method = "POST";
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Participant(jsonString);
        }
    }
}
