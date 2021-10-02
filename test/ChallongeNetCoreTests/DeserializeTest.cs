namespace ChallongeNetCoreTests
{
    using ChallongeNetCore;
    using System.Linq;
    using Xunit;

    public class DeserializeTest
    {
        [Fact]
        public void MatchList()
        {
            string json = "[{\"match\":{\"id\":175926682,\"tournament_id\":7635825,\"state\":\"open\",\"player1_id\":106613228,\"player2_id\":106613229,\"player1_prereq_match_id\":null,\"player2_prereq_match_id\":null,\"player1_is_prereq_match_loser\":false,\"player2_is_prereq_match_loser\":false,\"winner_id\":null,\"loser_id\":null,\"started_at\":\"2019-10-02T15:06:19.928-04:00\",\"created_at\":\"2019-10-02T15:06:19.824-04:00\",\"updated_at\":\"2019-10-02T15:06:19.928-04:00\",\"identifier\":\"A\",\"has_attachment\":false,\"round\":1,\"player1_votes\":null,\"player2_votes\":null,\"group_id\":null,\"attachment_count\":null,\"scheduled_time\":null,\"location\":null,\"underway_at\":null,\"optional\":false,\"rushb_id\":null,\"completed_at\":null,\"suggested_play_order\":1,\"forfeited\":null,\"prerequisite_match_ids_csv\":\"\",\"scores_csv\":\"\"}}]";

            var matches = Deserializer.ListOfMatches(json);
            Assert.Equal(1, matches.Count);
            var match = matches.First();
            Assert.IsType<Match>(match);
        }

        [Fact]
        public void WrappedMatch()
        {
            string json = "{\"match\":{\"id\":175926682,\"tournament_id\":7635825,\"state\":\"open\",\"player1_id\":106613228,\"player2_id\":106613229,\"player1_prereq_match_id\":null,\"player2_prereq_match_id\":null,\"player1_is_prereq_match_loser\":false,\"player2_is_prereq_match_loser\":false,\"winner_id\":null,\"loser_id\":null,\"started_at\":\"2019-10-02T15:06:19.928-04:00\",\"created_at\":\"2019-10-02T15:06:19.824-04:00\",\"updated_at\":\"2019-10-02T15:06:19.928-04:00\",\"identifier\":\"A\",\"has_attachment\":false,\"round\":1,\"player1_votes\":null,\"player2_votes\":null,\"group_id\":null,\"attachment_count\":null,\"scheduled_time\":null,\"location\":null,\"underway_at\":null,\"optional\":false,\"rushb_id\":null,\"completed_at\":null,\"suggested_play_order\":1,\"forfeited\":null,\"prerequisite_match_ids_csv\":\"\",\"scores_csv\":\"\"}}";
            json = "{\"match\":{\"id\": 12345}}";
            var match = Deserializer.Match(json);
            Assert.IsType<Match>(match);
        }

        [Fact]
        public void WrappedTournament()
        {
            string json = "{\"tournament\":{\"id\":7902872,\"name\":\"NetCoreTestFCCOKHGJQTRCDJXM\",\"url\":\"NetCoreTestFCCOKHGJQTRCDJXM\",\"description\":\"\",\"tournament_type\":\"single elimination\",\"started_at\":null,\"completed_at\":null,\"require_score_agreement\":false,\"notify_users_when_matches_open\":true,\"created_at\":\"2019-12-15T15:16:53.861+02:00\",\"updated_at\":\"2019-12-15T15:16:53.861+02:00\",\"state\":\"pending\",\"open_signup\":false,\"notify_users_when_the_tournament_ends\":true,\"progress_meter\":0,\"quick_advance\":false,\"hold_third_place_match\":false,\"pts_for_game_win\":\"0.0\",\"pts_for_game_tie\":\"0.0\",\"pts_for_match_win\":\"1.0\",\"pts_for_match_tie\":\"0.5\",\"pts_for_bye\":\"1.0\",\"swiss_rounds\":0,\"private\":false,\"ranked_by\":null,\"show_rounds\":false,\"hide_forum\":false,\"sequential_pairings\":false,\"accept_attachments\":false,\"rr_pts_for_game_win\":\"0.0\",\"rr_pts_for_game_tie\":\"0.0\",\"rr_pts_for_match_win\":\"1.0\",\"rr_pts_for_match_tie\":\"0.5\",\"created_by_api\":true,\"credit_capped\":false,\"category\":null,\"hide_seeds\":false,\"prediction_method\":0,\"predictions_opened_at\":null,\"anonymous_voting\":false,\"max_predictions_per_user\":1,\"signup_cap\":null,\"game_id\":null,\"participants_count\":1,\"group_stages_enabled\":false,\"allow_participant_match_reporting\":true,\"teams\":null,\"check_in_duration\":null,\"start_at\":null,\"started_checking_in_at\":null,\"tie_breaks\":null,\"locked_at\":null,\"event_id\":null,\"public_predictions_before_start_time\":null,\"ranked\":false,\"grand_finals_modifier\":null,\"predict_the_losers_bracket\":null,\"spam\":null,\"ham\":null,\"rr_iterations\":null,\"tournament_registration_id\":null,\"donation_contest_enabled\":null,\"mandatory_donation\":null,\"non_elimination_tournament_data\":{},\"auto_assign_stations\":null,\"only_start_matches_with_stations\":null,\"registration_fee\":\"0.0\",\"registration_type\":\"free\",\"description_source\":\"\",\"subdomain\":\"dalby\",\"full_challonge_url\":\"https://dalby.challonge.com/NetCoreTestFCCOKHGJQTRCDJXM\",\"live_image_url\":\"https://dalby.challonge.com/NetCoreTestFCCOKHGJQTRCDJXM.svg\",\"sign_up_url\":null,\"review_before_finalizing\":true,\"accepting_predictions\":false,\"participants_locked\":false,\"game_name\":null,\"participants_swappable\":true,\"team_convertable\":false,\"group_stages_were_started\":false}}";
            var tournament = Deserializer.Tournament(json);
            Assert.IsType<Tournament>(tournament);
        }

        [Fact]
        public void WrappedTournamentIncludedParticipants()
        {
            string json = "{\"tournament\":{\"id\":7902872,\"name\":\"NetCoreTestFCCOKHGJQTRCDJXM\",\"url\":\"NetCoreTestFCCOKHGJQTRCDJXM\",\"description\":\"\",\"tournament_type\":\"single elimination\",\"started_at\":null,\"completed_at\":null,\"require_score_agreement\":false,\"notify_users_when_matches_open\":true,\"created_at\":\"2019-12-15T15:16:53.861+02:00\",\"updated_at\":\"2019-12-15T15:16:53.861+02:00\",\"state\":\"pending\",\"open_signup\":false,\"notify_users_when_the_tournament_ends\":true,\"progress_meter\":0,\"quick_advance\":false,\"hold_third_place_match\":false,\"pts_for_game_win\":\"0.0\",\"pts_for_game_tie\":\"0.0\",\"pts_for_match_win\":\"1.0\",\"pts_for_match_tie\":\"0.5\",\"pts_for_bye\":\"1.0\",\"swiss_rounds\":0,\"private\":false,\"ranked_by\":null,\"show_rounds\":false,\"hide_forum\":false,\"sequential_pairings\":false,\"accept_attachments\":false,\"rr_pts_for_game_win\":\"0.0\",\"rr_pts_for_game_tie\":\"0.0\",\"rr_pts_for_match_win\":\"1.0\",\"rr_pts_for_match_tie\":\"0.5\",\"created_by_api\":true,\"credit_capped\":false,\"category\":null,\"hide_seeds\":false,\"prediction_method\":0,\"predictions_opened_at\":null,\"anonymous_voting\":false,\"max_predictions_per_user\":1,\"signup_cap\":null,\"game_id\":null,\"participants_count\":1,\"group_stages_enabled\":false,\"allow_participant_match_reporting\":true,\"teams\":null,\"check_in_duration\":null,\"start_at\":null,\"started_checking_in_at\":null,\"tie_breaks\":null,\"locked_at\":null,\"event_id\":null,\"public_predictions_before_start_time\":null,\"ranked\":false,\"grand_finals_modifier\":null,\"predict_the_losers_bracket\":null,\"spam\":null,\"ham\":null,\"rr_iterations\":null,\"tournament_registration_id\":null,\"donation_contest_enabled\":null,\"mandatory_donation\":null,\"non_elimination_tournament_data\":{},\"auto_assign_stations\":null,\"only_start_matches_with_stations\":null,\"registration_fee\":\"0.0\",\"registration_type\":\"free\",\"participants\":[{\"participant\":{\"id\":111245990,\"tournament_id\":7902872,\"name\":\"QGVZGXMCWTPHWZWA\",\"seed\":1,\"active\":true,\"created_at\":\"2019-12-15T15:16:54.791+02:00\",\"updated_at\":\"2019-12-15T15:16:54.791+02:00\",\"invite_email\":null,\"final_rank\":null,\"misc\":null,\"icon\":null,\"on_waiting_list\":false,\"invitation_id\":null,\"group_id\":null,\"checked_in_at\":null,\"ranked_member_id\":null,\"challonge_username\":null,\"challonge_email_address_verified\":null,\"removable\":true,\"participatable_or_invitation_attached\":false,\"confirm_remove\":false,\"invitation_pending\":false,\"display_name_with_invitation_email_address\":\"QGVZGXMCWTPHWZWA\",\"email_hash\":null,\"username\":null,\"display_name\":\"QGVZGXMCWTPHWZWA\",\"attached_participatable_portrait_url\":null,\"can_check_in\":false,\"checked_in\":false,\"reactivatable\":false,\"check_in_open\":false,\"group_player_ids\":[],\"has_irrelevant_seed\":false}}],\"description_source\":\"\",\"subdomain\":\"dalby\",\"full_challonge_url\":\"https://dalby.challonge.com/NetCoreTestFCCOKHGJQTRCDJXM\",\"live_image_url\":\"https://dalby.challonge.com/NetCoreTestFCCOKHGJQTRCDJXM.svg\",\"sign_up_url\":null,\"review_before_finalizing\":true,\"accepting_predictions\":false,\"participants_locked\":false,\"game_name\":null,\"participants_swappable\":true,\"team_convertable\":false,\"group_stages_were_started\":false}}";
            var tournament = Deserializer.Tournament(json);
            Assert.IsType<Tournament>(tournament);
            Assert.Single(tournament.Participants);
        }
    }
}
