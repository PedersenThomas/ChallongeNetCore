using ChallongeNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChallongeNetCoreTests
{
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
    }
}
