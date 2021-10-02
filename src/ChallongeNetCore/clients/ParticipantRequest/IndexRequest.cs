namespace ChallongeNetCore.clients.ParticipantRequest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IndexRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }

        public string TournamentIdentifier { get; private set; }

        public IndexRequest(ChallongeV1Connection connection, string tournamentIdentifier)
        {
            this.Connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
        }

        public async Task<IList<Participant>> SendAsync()
        {
            string apiUrl = $"/tournaments/{this.TournamentIdentifier}/participants";
            const string method = "GET";
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.ListOfParticipants(jsonString);
        }
    }
}
