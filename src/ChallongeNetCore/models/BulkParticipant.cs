using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.models
{
    /// <summary>
    /// Transport class for bulk adding participants
    /// </summary>
    public class BulkParticipant
    {
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "invite_name_or_email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string InviteNameOrEmail { get; set; }
        [JsonProperty(PropertyName = "seed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Seed { get; set; }
        [JsonProperty(PropertyName = "misc", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Misc { get; set; }

        public BulkParticipant SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public BulkParticipant SetInviteNameOrEmail(string nameOrEMail)
        {
            this.InviteNameOrEmail = nameOrEMail;
            return this;
        }

        public BulkParticipant SetSeed(int seed)
        {
            this.Seed = seed;
            return this;
        }

        public BulkParticipant SetMisc(string misc)
        {
            this.Misc = misc;
            return this;
        }
        
    }
}
