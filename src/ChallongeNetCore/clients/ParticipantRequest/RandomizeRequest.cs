using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.ParticipantRequest
{
    public class RandomizeRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }
        public string TournamentIdentifier { get; private set; }

        public RandomizeRequest(ChallongeV1Connection connection, string tournamentIdentifier)
        {
            this.Connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
        }

        public async Task<IList<Participant>> SendAsync()
        {
            string apiUrl = $"/tournaments/{this.TournamentIdentifier}/participants/randomize";
            const string method = "POST ";
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.ListOfParticipants(jsonString);
        }
    }
}
