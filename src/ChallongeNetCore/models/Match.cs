using System;
using System.Text.Json.Serialization;

namespace ChallongeNetCore
{
    public enum MatchState
    {
        pending,
        open,
        complete
    }

    public class Match
    {
        //[JsonPropertyName("created_at")]
        //public DateTime? CreatedAt { get; set; }

        //[JsonPropertyName("group_id")]
        //public int? GroupId { get; set; }

        //[JsonPropertyName("has_attachment")]
        //public bool HasAttachment { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        //[JsonPropertyName("identifier")]
        //public string Identifier { get; set; }

        //[JsonPropertyName("loser_id")]
        //public int? LoserId { get; set; }

        //[JsonPropertyName("player1_id")]
        //public int? Player1Id { get; set; }

        //[JsonPropertyName("player1_is_prereq_match_loser")]
        //public bool Player1IsPrereqMatchLoser { get; set; }

        //[JsonPropertyName("player1_prereq_match_id")]
        //public int? Player1PrereqMatchId { get; set; }

        //[JsonPropertyName("player1_votes")]
        //public string Player1Votes { get; set; }

        //[JsonPropertyName("player2_id")]
        //public int? Player2Id { get; set; }

        //[JsonPropertyName("player2_is_prereq_match_loser")]
        //public bool Player2IsPrereqMatchLoser { get; set; }

        //[JsonPropertyName("player2_prereq_match_id")]
        //public int? Player2PrereqMatchId { get; set; }

        //[JsonPropertyName("player2_votes")]
        //public string Player2Votes { get; set; }

        //[JsonPropertyName("round")]
        //public int Round { get; set; }

        //[JsonPropertyName("started_at")]
        //public DateTime? StartedAt { get; set; }

        //[JsonPropertyName("state")]
        //public MatchState State { get; set; }

        //[JsonPropertyName("tournament_id")]
        //public int TournamentId { get; set; }

        //[JsonPropertyName("updated_at")]
        //public DateTime? UpdatedAt { get; set; }

        //[JsonPropertyName("winner_id")]
        //public int? WinnerId { get; set; }

        //[JsonPropertyName("prerequisite_match_ids_csv")]
        //public string PrerequisiteMatchIdsCsv { get; set; }

        //[JsonPropertyName("scores_csv")]
        //public string ScoresCsv { get; set; }
    }
}
