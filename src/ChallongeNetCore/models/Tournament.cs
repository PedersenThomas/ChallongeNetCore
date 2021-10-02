namespace ChallongeNetCore
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Tournament
    {
        [JsonPropertyName("accept_attachments")]
        public bool AcceptAttachments { get; set; }

        [JsonPropertyName("allow_participant_match_reporting")]
        public bool AllowParticipantMatchReporting { get; set; }

        [JsonPropertyName("anonymous_voting")]
        public bool AnonymousVoting { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("check_in_duration")]
        public int? CheckInDuration { get; set; }

        [JsonPropertyName("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("created_by_api")]
        public bool CreatedByApi { get; set; }

        [JsonPropertyName("credit_capped")]
        public bool CreditCapped { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("game_id")]
        public int? GameId { get; set; }

        [JsonPropertyName("enable_group_stage")]
        public bool EnableGroupStage { get; set; }

        [JsonPropertyName("hide_forum")]
        public bool HideForum { get; set; }

        [JsonPropertyName("hide_seeds")]
        public bool HideSeeds { get; set; }

        [JsonPropertyName("hold_third_place_match")]
        public bool HoldThirdPlaceMatch { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("matches")]
        public List<WrapperMatch> Matches { get; set; }

        [JsonPropertyName("max_predictions_per_user")]
        public int MaxPredictionsPerUser { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("notify_users_when_matches_open")]
        public bool NotifyUsersWhenMatchesOpen { get; set; }

        [JsonPropertyName("notify_users_when_the_tournament_ends")]
        public bool NotifyUsersWhenTheTournamentEnds { get; set; }

        [JsonPropertyName("open_signup")]
        public bool OpenSignup { get; set; }

        [JsonPropertyName("participants_count")]
        public int ParticipantsCount { get; set; }

        [JsonPropertyName("prediction_method")]
        public int PredictionMethod { get; set; }

        [JsonPropertyName("predictions_opened_at")]
        public DateTime? PredictionsOpenedAt { get; set; }

        [JsonPropertyName("private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("participants")]
        public List<WrapperParticipant> Participants { get; set; }

        [JsonPropertyName("progress_meter")]
        public int ProgressMeter { get; set; }

        [JsonPropertyName("pts_for_bye")]
        public string PtsForBye { get; set; }

        [JsonPropertyName("pts_for_game_tie")]
        public string PtsForGameTie { get; set; }

        [JsonPropertyName("pts_for_game_win")]
        public string PtsForGameWin { get; set; }

        [JsonPropertyName("pts_for_match_tie")]
        public string PtsForMatchTie { get; set; }

        [JsonPropertyName("pts_for_match_win")]
        public string PtsForMatchWin { get; set; }

        [JsonPropertyName("quick_advance")]
        public bool QuickAdvance { get; set; }

        [JsonPropertyName("ranked_by")]
        public TournamentRankedBy? RankedBy { get; set; }

        [JsonPropertyName("require_score_agreement")]
        public bool RequireScoreAgreement { get; set; }

        [JsonPropertyName("rr_pts_for_game_tie")]
        public string RrPtsForGameTie { get; set; }

        [JsonPropertyName("rr_pts_for_game_win")]
        public string RrPtsForGameWin { get; set; }

        [JsonPropertyName("rr_pts_for_match_tie")]
        public string RrPtsForMatchTie { get; set; }

        [JsonPropertyName("rr_pts_for_match_win")]
        public string RrPtsForMatchWin { get; set; }

        [JsonPropertyName("sequential_pairings")]
        public bool SequentialPairings { get; set; }

        [JsonPropertyName("show_rounds")]
        public bool ShowRounds { get; set; }

        [JsonPropertyName("signup_cap")]
        public int? SignupCap { get; set; }

        [JsonPropertyName("start_at")]
        public DateTime? StartAt { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonPropertyName("started_checking_in_at")]
        public DateTime? StartedCheckingInAt { get; set; }

        [JsonPropertyName("state")]
        public TournamentState Tournamentstate { get; set; }

        [JsonPropertyName("swiss_rounds")]
        public int SwissRounds { get; set; }

        [JsonPropertyName("tournament_type")]
        public TournamentType TournamentType { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("description_source")]
        public string DescriptionSource { get; set; }

        [JsonPropertyName("subdomain")]
        public string Subdomain { get; set; }

        [JsonPropertyName("full_challonge_url")]
        public string FullChallongeUrl { get; set; }

        [JsonPropertyName("live_image_url")]
        public string LiveImageUrl { get; set; }

        [JsonPropertyName("sign_up_url")]
        public string SignUpUrl { get; set; }

        [JsonPropertyName("review_before_finalizing")]
        public bool ReviewBeforeFinalizing { get; set; }

        [JsonPropertyName("accepting_predictions")]
        public bool AcceptingPredictions { get; set; }

        [JsonPropertyName("participants_locked")]
        public bool ParticipantsLocked { get; set; }

        [JsonPropertyName("game_name")]
        public string GameName { get; set; }

        [JsonPropertyName("participants_swappable")]
        public bool ParticipantsSwappable { get; set; }

        [JsonPropertyName("team_convertable")]
        public bool TeamConvertable { get; set; }

        [JsonPropertyName("group_stages_were_started")]
        public bool GroupStagesWereStarted { get; set; }
    }
}
