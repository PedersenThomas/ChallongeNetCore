using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ChallongeNetCore
{
    public class Tournament
    {
        [JsonProperty(PropertyName = "accept_attachments")]
        public bool AcceptAttachments { get; set; }

        [JsonProperty(PropertyName = "allow_participant_match_reporting")]
        public bool AllowParticipantMatchReporting { get; set; }

        [JsonProperty(PropertyName = "anonymous_voting")]
        public bool AnonymousVoting { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "check_in_duration")]
        public int? CheckInDuration { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "completed_at")]
        public DateTime? CompletedAt { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "created_by_api")]
        public bool CreatedByApi { get; set; }

        [JsonProperty(PropertyName = "credit_capped")]
        public bool CreditCapped { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "game_id")]
        public int? GameId { get; set; }

        [JsonProperty(PropertyName = "enable_group_stage")]
        public bool EnableGroupStage { get; set; }

        [JsonProperty(PropertyName = "hide_forum")]
        public bool HideForum { get; set; }

        [JsonProperty(PropertyName = "hide_seeds")]
        public bool HideSeeds { get; set; }

        [JsonProperty(PropertyName = "hold_third_place_match")]
        public bool HoldThirdPlaceMatch { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public List<WrapperMatch> Matches { get; set; }

        [JsonProperty(PropertyName = "max_predictions_per_user")]
        public int MaxPredictionsPerUser { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "notify_users_when_matches_open")]
        public bool NotifyUsersWhenMatchesOpen { get; set; }

        [JsonProperty(PropertyName = "notify_users_when_the_tournament_ends")]
        public bool NotifyUsersWhenTheTournamentEnds { get; set; }

        [JsonProperty(PropertyName = "open_signup")]
        public bool OpenSignup { get; set; }

        [JsonProperty(PropertyName = "participants_count")]
        public int ParticipantsCount { get; set; }

        [JsonProperty(PropertyName = "prediction_method")]
        public int PredictionMethod { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "predictions_opened_at")]
        public DateTime? PredictionsOpenedAt { get; set; }

        [JsonProperty(PropertyName = "private")]
        public bool IsPrivate { get; set; }

        [JsonProperty(PropertyName = "participants")]
        public List<WrapperParticipant> Participants { get; set; }

        [JsonProperty(PropertyName = "progress_meter")]
        public int ProgressMeter { get; set; }

        [JsonProperty(PropertyName = "pts_for_bye")]
        public float PtsForBye { get; set; }

        [JsonProperty(PropertyName = "pts_for_game_tie")]
        public float PtsForGameTie { get; set; }

        [JsonProperty(PropertyName = "pts_for_game_win")]
        public float PtsForGameWin { get; set; }

        [JsonProperty(PropertyName = "pts_for_match_tie")]
        public float PtsForMatchTie { get; set; }

        [JsonProperty(PropertyName = "pts_for_match_win")]
        public float PtsForMatchWin { get; set; }

        [JsonProperty(PropertyName = "quick_advance")]
        public bool QuickAdvance { get; set; }

        [JsonProperty(PropertyName = "ranked_by")]
        public TournamentRankedBy? RankedBy { get; set; }

        [JsonProperty(PropertyName = "require_score_agreement")]
        public bool RequireScoreAgreement { get; set; }

        [JsonProperty(PropertyName = "rr_pts_for_game_tie")]
        public float RrPtsForGameTie { get; set; }

        [JsonProperty(PropertyName = "rr_pts_for_game_win")]
        public float RrPtsForGameWin { get; set; }

        [JsonProperty(PropertyName = "rr_pts_for_match_tie")]
        public float RrPtsForMatchTie { get; set; }

        [JsonProperty(PropertyName = "rr_pts_for_match_win")]
        public float RrPtsForMatchWin { get; set; }

        [JsonProperty(PropertyName = "sequential_pairings")]
        public bool SequentialPairings { get; set; }

        [JsonProperty(PropertyName = "show_rounds")]
        public bool ShowRounds { get; set; }

        [JsonProperty(PropertyName = "signup_cap")]
        public int? SignupCap { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "start_at")]
        public DateTime? StartAt { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "started_checking_in_at")]
        public DateTime? StartedCheckingInAt { get; set; }

        [JsonProperty(PropertyName = "state")]
        public TournamentState Tournamentstate { get; set; }

        [JsonProperty(PropertyName = "swiss_rounds")]
        public int SwissRounds { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter), PropertyName = "tournament_type")]
        public TournamentType TournamentType { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "description_source")]
        public string DescriptionSource { get; set; }

        [JsonProperty(PropertyName = "subdomain")]
        public string Subdomain { get; set; }

        [JsonProperty(PropertyName = "full_challonge_url")]
        public string FullChallongeUrl { get; set; }

        [JsonProperty(PropertyName = "live_image_url")]
        public string LiveImageUrl { get; set; }

        [JsonProperty(PropertyName = "sign_up_url")]
        public string SignUpUrl { get; set; }

        [JsonProperty(PropertyName = "review_before_finalizing")]
        public bool ReviewBeforeFinalizing { get; set; }

        [JsonProperty(PropertyName = "accepting_predictions")]
        public bool AcceptingPredictions { get; set; }

        [JsonProperty(PropertyName = "participants_locked")]
        public bool ParticipantsLocked { get; set; }

        [JsonProperty(PropertyName = "game_name")]
        public string GameName { get; set; }

        [JsonProperty(PropertyName = "participants_swappable")]
        public bool ParticipantsSwappable { get; set; }

        [JsonProperty(PropertyName = "team_convertable")]
        public bool TeamConvertable { get; set; }

        [JsonProperty(PropertyName = "group_stages_were_started")]
        public bool GroupStagesWereStarted { get; set; }
    }
}
