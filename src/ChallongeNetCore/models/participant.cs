using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ChallongeNetCore
{
    public class Participant
    {
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "checked_in_at")]
        public DateTime? CheckedInAt { get; set; }

        [JsonProperty(PropertyName = "checked_in")]
        public bool CheckedIn { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "final_rank")]
        public string FinalRank { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public string GroupId { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "invitation_id")]
        public int? InvitationId { get; set; }

        [JsonProperty(PropertyName = "invite_email")]
        public string InviteEmail { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public List<WrapperMatch> Matches { get; set; }

        [JsonProperty(PropertyName = "misc")]
        public string Misc { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "on_waiting_list")]
        public bool OnWaitingList { get; set; }

        [JsonProperty(PropertyName = "seed")]
        public int Seed { get; set; }

        [JsonProperty(PropertyName = "tournament_id")]
        public int TournamentId { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "challonge_username")]
        public string ChallongeUsername { get; set; }

        [JsonProperty(PropertyName = "challonge_email_address_verified")]
        public bool? ChallongeEmailAddressVerified { get; set; }

        [JsonProperty(PropertyName = "removable")]
        public bool Removable { get; set; }

        [JsonProperty(PropertyName = "participatable_or_invitation_attached")]
        public bool ParticipatableOrInvitationAttached { get; set; }

        [JsonProperty(PropertyName = "confirm_remove")]
        public bool ConfirmRemove { get; set; }

        [JsonProperty(PropertyName = "invitation_pending")]
        public bool InvitationPending { get; set; }

        [JsonProperty(PropertyName = "display_name_with_invitation_email_address")]
        public string DisplayNameWithInvitationEmailAddress { get; set; }

        [JsonProperty(PropertyName = "email_hash")]
        public string EmailHash { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "attached_user_portrait_url")]
        public string AttachedUserPortraitUrl { get; set; }

        [JsonProperty(PropertyName = "can_check_in")]
        public bool CanCheckIn { get; set; }

        [JsonProperty(PropertyName = "reactivatable")]
        public bool Reactivatable { get; set; }
    }
}
