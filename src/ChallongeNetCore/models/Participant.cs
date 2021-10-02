namespace ChallongeNetCore
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Participant
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("checked_in_at")]
        public DateTime? CheckedInAt { get; set; }

        [JsonPropertyName("checked_in")]
        public bool CheckedIn { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("final_rank")]
        public string FinalRank { get; set; }

        [JsonPropertyName("group_id")]
        public string GroupId { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("invitation_id")]
        public int? InvitationId { get; set; }

        [JsonPropertyName("invite_email")]
        public string InviteEmail { get; set; }

        [JsonPropertyName("matches")]
        public List<WrapperMatch> Matches { get; set; }

        [JsonPropertyName("misc")]
        public string Misc { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("on_waiting_list")]
        public bool OnWaitingList { get; set; }

        [JsonPropertyName("seed")]
        public int Seed { get; set; }

        [JsonPropertyName("tournament_id")]
        public int TournamentId { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("challonge_username")]
        public string ChallongeUsername { get; set; }

        [JsonPropertyName("challonge_email_address_verified")]
        public bool? ChallongeEmailAddressVerified { get; set; }

        [JsonPropertyName("removable")]
        public bool Removable { get; set; }

        [JsonPropertyName("participatable_or_invitation_attached")]
        public bool ParticipatableOrInvitationAttached { get; set; }

        [JsonPropertyName("confirm_remove")]
        public bool ConfirmRemove { get; set; }

        [JsonPropertyName("invitation_pending")]
        public bool InvitationPending { get; set; }

        [JsonPropertyName("display_name_with_invitation_email_address")]
        public string DisplayNameWithInvitationEmailAddress { get; set; }

        [JsonPropertyName("email_hash")]
        public string EmailHash { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("attached_user_portrait_url")]
        public string AttachedUserPortraitUrl { get; set; }

        [JsonPropertyName("can_check_in")]
        public bool CanCheckIn { get; set; }

        [JsonPropertyName("reactivatable")]
        public bool Reactivatable { get; set; }
    }
}
