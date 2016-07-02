using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

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
        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int? GroupId { get; set; }

        [JsonProperty(PropertyName = "has_attachment")]
        public bool HasAttachment { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }

        [JsonProperty(PropertyName = "loser_id")]
        public int? LoserId { get; set; }

        [JsonProperty(PropertyName = "player1_id")]
        public int? Player1Id { get; set; }

        [JsonProperty(PropertyName = "player1_is_prereq_match_loser")]
        public bool Player1IsPrereqMatchLoser { get; set; }

        [JsonProperty(PropertyName = "player1_prereq_match_id")]
        public int? Player1PrereqMatchId { get; set; }

        [JsonProperty(PropertyName = "player1_votes")]
        public string Player1Votes { get; set; }

        [JsonProperty(PropertyName = "player2_id")]
        public int? Player2Id { get; set; }

        [JsonProperty(PropertyName = "player2_is_prereq_match_loser")]
        public bool Player2IsPrereqMatchLoser { get; set; }

        [JsonProperty(PropertyName = "player2_prereq_match_id")]
        public int? Player2PrereqMatchId { get; set; }

        [JsonProperty(PropertyName = "player2_votes")]
        public string Player2Votes { get; set; }

        [JsonProperty(PropertyName = "round")]
        public int Round { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter), PropertyName = "state")]
        public MatchState State { get; set; }

        [JsonProperty(PropertyName = "tournament_id")]
        public int TournamentId { get; set; }

        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter), PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "winner_id")]
        public int? WinnerId { get; set; }

        [JsonProperty(PropertyName = "prerequisite_match_ids_csv")]
        public string PrerequisiteMatchIdsCsv { get; set; }

        [JsonProperty(PropertyName = "scores_csv")]
        public string ScoresCsv { get; set; }
    }
}
