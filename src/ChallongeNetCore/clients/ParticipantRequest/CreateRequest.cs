using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.ParticipantRequest
{
    public class CreateRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }

        public CreateRequest(ChallongeV1Connection connection)
        {
            this.connection = connection;
        }

        public CreateRequest SetName(string value) { parameters["name"] = value; return this; }

        public async Task<Participant> SendAsync(string TournamentIdentifier)
        {
            string apiUrl = $"/tournaments/{TournamentIdentifier}/participants";
            const string method = "POST";
            var finalParameters = new Dictionary<string, dynamic> { { "participant", parameters } };
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.Participant(jsonString);
        }
    }
}