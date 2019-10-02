using ChallongeNetCore.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.ParticipantRequest
{
    public class BulkAddRequest
    {
        private IList<BulkParticipant> participants = new List<BulkParticipant>();

        public ChallongeV1Connection Connection { get; private set; }
        public string TournamentIdentifier { get; private set; }

        public BulkAddRequest(ChallongeV1Connection connection, string tournamentIdentifier)
        {
            this.Connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
        }

        public BulkAddRequest AddParticipant(BulkParticipant participant)
        {
            participants.Add(participant);
            return this;
        }

        public async Task<IList<Participant>> SendAsync()
        {
            string apiUrl = $"/tournaments/{this.TournamentIdentifier}/participants/bulk_add";
            const string method = "POST";
            var finalParameters = new Dictionary<string, dynamic> { { "participant", participants } };
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, finalParameters);
            return Deserializer.ListOfParticipants(jsonString);
        }
    }
}
