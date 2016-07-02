using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients.TournamentRequest
{
    public class CreateRequest
    {
        private IDictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

        public ChallongeV1Connection connection { get; private set; }

        public CreateRequest(ChallongeV1Connection connection)
        {
            this.connection = connection;
        }

        public CreateRequest SetName(string value) { parameters["name"] = value; return this; }
        public CreateRequest SetTournamentType(TournamentType value) { parameters["tournament_type"] = value.ToChallongeString(); return this; }
        public CreateRequest SetUrl(string value) { parameters["url"] = value; return this; }
        public CreateRequest SetSubdomain(string value) { parameters["subdomain"] = value; return this; }
        public CreateRequest SetDescription(string value) { parameters["description"] = value; return this; }
        public CreateRequest SetOpenSignup(bool value) { parameters["open_signup"] = value; return this; }
        public CreateRequest SetHoldThirdPlaceMatch(bool value) { parameters["hold_third_place_match"] = value; return this; }
        public CreateRequest SetPtsForMatchWin(double value) { parameters["pts_for_match_win"] = value; return this; }
        public CreateRequest SetPtsForMatchTie(double value) { parameters["pts_for_match_tie"] = value; return this; }
        public CreateRequest SetPtsForGameWin(double value) { parameters["pts_for_game_win"] = value; return this; }
        public CreateRequest SetPtsForGameTie(double value) { parameters["pts_for_game_tie"] = value; return this; }
        public CreateRequest SetPtsForBye(double value) { parameters["pts_for_bye"] = value; return this; }
        public CreateRequest SetSwissRounds(int value) { parameters["swiss_rounds"] = value; return this; }
        public CreateRequest SetRankedBy(TournamentRankedBy value) { parameters["ranked_by"] = value.ToChallongeString(); return this; }
        public CreateRequest SetRrPtsForMatchWin(double value) { parameters["rr_pts_for_match_win"] = value; return this; }
        public CreateRequest SetRrPtsForMatchTie(double value) { parameters["rr_pts_for_match_tie"] = value; return this; }
        public CreateRequest SetRrPtsForGameWin(double value) { parameters["rr_pts_for_game_win"] = value; return this; }
        public CreateRequest SetRrPtsForGameTie(double value) { parameters["rr_pts_for_game_tie"] = value; return this; }
        public CreateRequest SetAcceptAttachments(bool value) { parameters["accept_attachments"] = value; return this; }
        public CreateRequest SetHideForum(bool value) { parameters["hide_forum"] = value; return this; }
        public CreateRequest SetShowRounds(bool value) { parameters["show_rounds"] = value; return this; }
        public CreateRequest SetPrivate(bool value) { parameters["private"] = value; return this; }
        public CreateRequest SetNotifyUsersWhenMatchesOpen(bool value) { parameters["notify_users_when_matches_open"] = value; return this; }
        public CreateRequest SetNotifyUsersWhenTheTournamentEnds(bool value) { parameters["notify_users_when_the_tournament_ends"] = value; return this; }
        public CreateRequest SetSequentialPairings(bool value) { parameters["sequential_pairings"] = value; return this; }
        public CreateRequest SetSignupCap(int value) { parameters["signup_cap"] = value; return this; }
        public CreateRequest SetStartAt(DateTime value) { parameters["start_at"] = value; return this; }
        public CreateRequest SetCheckInDuration(int value) { parameters["check_in_duration"] = value; return this; }



        public async Task<Tournament> SendAsync()
        {
            const string apiUrl = "/tournaments";
            const string method = "POST";
            var finalParameters = new Dictionary<string, dynamic> { { "tournament", parameters } };
            var jsonString = await connection.MakeJSONRequestAsync(apiUrl, method, finalParameters);
            this.connection.DebugWriteline?.Invoke("Response body: " + jsonString);
            return Deserializer.Tournament(jsonString);
        }
    }
}
