using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChallongeNetCore
{
#pragma warning disable 0649
    public class WrapperTournament
    {
        [JsonPropertyName("tournament")]
        public Tournament Tournament { get; set; }
    }

    public class WrapperParticipant
    {
        [JsonPropertyName("Participant")]
        public Participant Participant { get; set; }
    }

    public class WrapperMatch
    {
        [JsonPropertyName("Match")]
        public Match Match { get; set; }
    }

    public class WrapperAttachment
    {
        [JsonPropertyName("Attachment")]
        public Attachment Attachment { get; set; }
    }
#pragma warning restore 0649

    internal static class Deserializer
    {
        private static readonly JsonConverter[] TournamentConverters =
            {
                new TournamentRankedByConverter(),
                new TournamentTypeConverter(),
                new TournamentStateConverter()
            };

        private static readonly Lazy<JsonSerializerOptions> jsonSerializerOptions = new Lazy<JsonSerializerOptions>(() =>
        {
            var options = new JsonSerializerOptions();
            foreach (var converter in TournamentConverters)
            {
                options.Converters.Add(converter);
            }

            return options;
        });

        internal static IList<Tournament> ListOfTournaments(string json)
        {
            var dummyTournaments = JsonSerializer.Deserialize<List<WrapperTournament>>(json, jsonSerializerOptions.Value);

            return dummyTournaments.Select(dummy => dummy.Tournament).ToList();
        }

        internal static Tournament Tournament(string json)
        {
            var result = JsonSerializer.Deserialize<WrapperTournament>(json, jsonSerializerOptions.Value);

            return result.Tournament;
        }

        internal static IList<Participant> ListOfParticipants(string json)
        {
            var dummyParticipants = JsonSerializer.Deserialize<List<WrapperParticipant>>(json);

            return dummyParticipants.Select(dummy => dummy.Participant).ToList();
        }

        internal static Participant Participant(string json)
        {
            var result = JsonSerializer.Deserialize<WrapperParticipant>(json);

            return result.Participant;
        }

        internal static IList<Match> ListOfMatches(string json)
        {
            var dummyMatches = JsonSerializer.Deserialize<List<WrapperMatch>>(json);

            return dummyMatches.Select(dummy => dummy.Match).ToList();
        }

        internal static Match Match(string json)
        {
            var result = JsonSerializer.Deserialize<WrapperMatch>(json);

            return result.Match;
        }

        internal static Attachment Attachment(string json)
        {
            var result = JsonSerializer.Deserialize<WrapperAttachment>(json);

            return result.Attachment;
        }

        private class TournamentTypeConverter : JsonConverter<TournamentType>
        {
            public override TournamentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    string text = reader.GetString();
                    switch (text)
                    {
                        case "single elimination":
                            return TournamentType.SingleElimination;
                        case "double elimination":
                            return TournamentType.DoubleElimination;
                        case "round robin":
                            return TournamentType.RoundRobin;
                        case "swiss":
                            return TournamentType.Swiss;
                        default:
                            throw new ArgumentException("Unknow Tournament Rank: " + text);
                    }
                }

                throw new ArgumentException("Reader is trying to read a non-string element for the TournamentType enum.");
            }

            public override void Write(Utf8JsonWriter writer, TournamentType value, JsonSerializerOptions options)
            {
                switch (value)
                {
                    case TournamentType.SingleElimination:
                        writer.WriteStringValue("single elimination");
                        break;
                    case TournamentType.DoubleElimination:
                        writer.WriteStringValue("double elimination");
                        break;
                    case TournamentType.RoundRobin:
                        writer.WriteStringValue("round robin");
                        break;
                    case TournamentType.Swiss:
                        writer.WriteStringValue("swiss");
                        break;
                    default:
                        throw new ArgumentException("Unknow Tournament Type: " + value);
                }
            }

            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>
            /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
            /// </returns>
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(TournamentType);
            }
        }

        private class TournamentRankedByConverter : JsonConverter<TournamentRankedBy>
        {
            public override TournamentRankedBy Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if(reader.TokenType == JsonTokenType.String)
                {
                    string text = reader.GetString();
                    switch (text)
                    {
                        case "match wins":
                            return TournamentRankedBy.MatchWins;
                        case "game wins":
                            return TournamentRankedBy.GameWins;
                        case "points scored":
                            return TournamentRankedBy.PointsScored;
                        case "custom":
                            return TournamentRankedBy.Custom;
                        default:
                            throw new ArgumentException("Unknow Tournament Rank: " + text);
                    }
                }

                throw new ArgumentException("Reader is trying to read a non-string element for the TournamentRankedBy enum.");
            }

            public override void Write(Utf8JsonWriter writer, TournamentRankedBy value, JsonSerializerOptions options)
            {
                switch (value)
                {
                    case TournamentRankedBy.MatchWins:
                        writer.WriteStringValue("match wins");
                        break;
                    case TournamentRankedBy.GameWins:
                        writer.WriteStringValue("game wins");
                        break;
                    case TournamentRankedBy.PointsScored:
                        writer.WriteStringValue("points scored");
                        break;
                    case TournamentRankedBy.Custom:
                        writer.WriteStringValue("custom");
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>
            /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
            /// </returns>
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(TournamentRankedBy?);
            }
        }

        private class TournamentStateConverter : JsonConverter<TournamentState>
        {
            public override TournamentState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    string text = reader.GetString();
                    switch (text)
                    {
                        case "pending":
                            return TournamentState.pending;
                        case "underway":
                            return TournamentState.underway;
                        case "awaiting_review":
                            return TournamentState.awaiting_review;
                        case "complete":
                            return TournamentState.complete;
                        default:
                            throw new ArgumentException("Unknow Tournament State: " + text);
                    }
                }

                throw new ArgumentException("Reader is trying to read a non-string element for the TournamentState enum.");
            }

            public override void Write(Utf8JsonWriter writer, TournamentState value, JsonSerializerOptions options)
            {
                switch (value)
                {
                    case TournamentState.pending:
                        writer.WriteStringValue("pending");
                        break;
                    case TournamentState.underway:
                        writer.WriteStringValue("underway");
                        break;
                    case TournamentState.awaiting_review:
                        writer.WriteStringValue("awaiting_review");
                        break;
                    case TournamentState.complete:
                        writer.WriteStringValue("complete");
                        break;
                }
                throw new NotImplementedException();
            }

            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>
            /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
            /// </returns>
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(TournamentState);
            }
        }
    }
}
