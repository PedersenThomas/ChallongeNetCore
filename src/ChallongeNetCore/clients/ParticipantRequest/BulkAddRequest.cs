namespace ChallongeNetCore.clients.ParticipantRequest
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class BulkAddRequest
    {
        private List<BulkParticipant> participants = new List<BulkParticipant>();

        public ChallongeV1Connection Connection { get; private set; }
        public string TournamentIdentifier { get; private set; }

        public BulkAddRequest(ChallongeV1Connection connection, string tournamentIdentifier)
        {
            this.Connection = connection;
            this.TournamentIdentifier = tournamentIdentifier;
        }

        /// <summary>
        /// Add a participant to the request.
        /// </summary>
        /// <param name="name">Name of the participant</param>
        /// <param name="inviteNameOrEmail">Email of the participant. If they have a Challonge Account then they will be asked to accept it, otherwise they will receive an email to join challonge</param>
        /// <param name="seed">Seed of the participant.</param>
        /// <param name="misc">Extra information about the participant.</param>
        /// <returns></returns>
        public BulkAddRequest AddParticipant(string name, string inviteNameOrEmail, int seed, string misc)
        {
            participants.Add(new BulkParticipant(name, inviteNameOrEmail, seed, misc));
            return this;
        }

        public async Task<IList<Participant>> SendAsync()
        {
            string apiUrl = $"/tournaments/{TournamentIdentifier}/participants/bulk_add";
            const string method = "POST";
            var parameters = new Dictionary<string, dynamic>();
            parameters["participants"] = participants;
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, parameters);
            return Deserializer.ListOfParticipants(jsonString);
        }

        private class BulkParticipant
        {
            public BulkParticipant(string name, string inviteNameOrEmail, int seed, string misc)
            {
                this.Name = name;
                this.InviteNameOrEmail = inviteNameOrEmail;
                this.Seed = seed;
                this.Misc = misc;
            }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("invite_name_or_email")]
            public string InviteNameOrEmail { get; set; }

            [JsonPropertyName("seed")]
            public int Seed { get; set; }

            [JsonPropertyName("misc")]
            public string Misc { get; set; }
        }
    }
}
