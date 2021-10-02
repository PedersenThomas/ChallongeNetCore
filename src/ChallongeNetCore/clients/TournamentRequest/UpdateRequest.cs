namespace ChallongeNetCore.clients.TournamentRequest
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UpdateRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection Connection { get; private set; }
        public string Identifier { get; private set; }

        public UpdateRequest(ChallongeV1Connection connection, string identifier)
        {
            this.Connection = connection;
            this.Identifier = identifier;
        }

        public UpdateRequest SetName(string value) { parameters["name"] = value; return this; }

        public UpdateRequest SetTournamentType(TournamentType value) { parameters["tournament_type"] = value.ToChallongeString(); return this; }

        public UpdateRequest SetUrl(string value) { parameters["url"] = value; return this; }

        public UpdateRequest SetSubdomain(string value) { parameters["subdomain"] = value; return this; }

        public UpdateRequest SetDescription(string value) { parameters["description"] = value; return this; }

        public UpdateRequest SetOpenSignup(bool value) { parameters["open_signup"] = value; return this; }

        public UpdateRequest SetHoldThirdPlaceMatch(bool value) { parameters["hold_third_place_match"] = value; return this; }

        public UpdateRequest SetPtsForMatchWin(double value) { parameters["pts_for_match_win"] = value; return this; }

        public UpdateRequest SetPtsForMatchTie(double value) { parameters["pts_for_match_tie"] = value; return this; }

        public UpdateRequest SetPtsForGameWin(double value) { parameters["pts_for_game_win"] = value; return this; }

        public UpdateRequest SetPtsForGameTie(double value) { parameters["pts_for_game_tie"] = value; return this; }

        public UpdateRequest SetPtsForBye(double value) { parameters["pts_for_bye"] = value; return this; }

        public UpdateRequest SetSwissRounds(int value) { parameters["swiss_rounds"] = value; return this; }

        public UpdateRequest SetRankedBy(TournamentRankedBy value) { parameters["ranked_by"] = value.ToChallongeString(); return this; }

        public UpdateRequest SetRrPtsForMatchWin(double value) { parameters["rr_pts_for_match_win"] = value; return this; }

        public UpdateRequest SetRrPtsForMatchTie(double value) { parameters["rr_pts_for_match_tie"] = value; return this; }

        public UpdateRequest SetRrPtsForGameWin(double value) { parameters["rr_pts_for_game_win"] = value; return this; }

        public UpdateRequest SetRrPtsForGameTie(double value) { parameters["rr_pts_for_game_tie"] = value; return this; }

        public UpdateRequest SetAcceptAttachments(bool value) { parameters["accept_attachments"] = value; return this; }

        public UpdateRequest SetHideForum(bool value) { parameters["hide_forum"] = value; return this; }

        public UpdateRequest SetShowRounds(bool value) { parameters["show_rounds"] = value; return this; }

        public UpdateRequest SetPrivate(bool value) { parameters["private"] = value; return this; }

        public UpdateRequest SetNotifyUsersWhenMatchesOpen(bool value) { parameters["notify_users_when_matches_open"] = value; return this; }

        public UpdateRequest SetNotifyUsersWhenTheTournamentEnds(bool value) { parameters["notify_users_when_the_tournament_ends"] = value; return this; }

        public UpdateRequest SetSequentialPairings(bool value) { parameters["sequential_pairings"] = value; return this; }

        public UpdateRequest SetSignupCap(int value) { parameters["signup_cap"] = value; return this; }

        public UpdateRequest SetStartAt(DateTime value) { parameters["start_at"] = value; return this; }

        public UpdateRequest SetCheckInDuration(int value) { parameters["check_in_duration"] = value; return this; }


        public async Task<Tournament> SendAsync()
        {
            string apiUrl = $"/tournaments/{Identifier}";
            const string method = "PUT";
            var finalParameters = new Dictionary<string, dynamic> { { "tournament", parameters } };
            var jsonString = await Connection.MakeJSONRequestAsync(apiUrl, method, finalParameters);
            this.Connection.DebugWriteline?.Invoke("Response body: " + jsonString);
            return Deserializer.Tournament(jsonString);
        }
    }
}
