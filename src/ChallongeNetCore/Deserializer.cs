using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore
{
#pragma warning disable 0649
    public class WrapperTournament
    {
        [JsonProperty(PropertyName = "tournament")]
        public Tournament Tournament { get; set; }
    }

    public class WrapperParticipant
    {
        [JsonProperty(PropertyName = "Participant")]
        public Participant Participant { get; set; }
    }

    public class WrapperMatch
    {
        [JsonProperty(PropertyName = "Match")]
        public Match Match { get; set; }
    }

    public class WrapperAttachment
    {
        [JsonProperty(PropertyName = "Attachment")]
        public Attachment Attachment { get; set; }
    }
#pragma warning restore 0649

    internal static class Deserializer
    {
        private static readonly JsonConverter[] TournamentConverts =
            {
                new TournamentRankedByConverter(),
                new TournamentTypeConverter(),
                new TournamentStateConverter()
            };

        internal static IList<Tournament> ListOfTournaments(string json)
        {
            var dummyTournaments = JsonConvert.DeserializeObject<List<WrapperTournament>>(json, new TournamentRankedByConverter(), new TournamentTypeConverter(), new TournamentStateConverter());

            return dummyTournaments.Select(dummy => dummy.Tournament).ToList();
        }

        internal static Tournament Tournament(string json)
        {
            var result = JsonConvert.DeserializeObject<WrapperTournament>(json, TournamentConverts);

            return result.Tournament;
        }

        internal static IList<Participant> ListOfParticipants(string json)
        {
            var dummyParticipants = JsonConvert.DeserializeObject<List<WrapperParticipant>>(json);

            return dummyParticipants.Select(dummy => dummy.Participant).ToList();
        }

        internal static Participant Participant(string json)
        {
            var result = JsonConvert.DeserializeObject<WrapperParticipant>(json);

            return result.Participant;
        }

        internal static IList<Match> ListOfMatches(string json)
        {
            var dummyMatches = JsonConvert.DeserializeObject<List<WrapperMatch>>(json);

            return dummyMatches.Select(dummy => dummy.Match).ToList();
        }

        internal static Match Match(string json)
        {
            var result = JsonConvert.DeserializeObject<WrapperMatch>(json);

            return result.Match;
        }

        internal static Attachment Attachment(string json)
        {
            var result = JsonConvert.DeserializeObject<WrapperAttachment>(json);

            return result.Attachment;
        }

        private class TournamentTypeConverter : JsonConverter
        {
            /// <summary>
            /// Writes the JSON representation of the object.
            /// </summary>
            /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
            /// <exception cref="NotImplementedException"></exception>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Reads the JSON representation of the object.
            /// </summary>
            /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
            /// <returns>
            /// The object value.
            /// </returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var value = reader.Value as string;
                if (value == "single elimination")
                {
                    return TournamentType.SingleElimination;
                }

                if (value == "double elimination")
                {
                    return TournamentType.DoubleElimination;
                }

                if (value == "round robin")
                {
                    return TournamentType.RoundRobin;
                }

                if (value == "swiss")
                {
                    return TournamentType.Swiss;
                }

                throw new ArgumentException("Unknow Tournament Type: " + value);
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

        private class TournamentRankedByConverter : JsonConverter
        {
            /// <summary>
            /// Writes the JSON representation of the object.
            /// </summary>
            /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
            /// <exception cref="NotImplementedException"></exception>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Reads the JSON representation of the object.
            /// </summary>
            /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
            /// <returns>
            /// The object value.
            /// </returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var value = reader.Value as string;
                if (value == null || value == "null")
                {
                    return null;
                }

                if (value == "match wins")
                {
                    return TournamentRankedBy.MatchWins;
                }

                if (value == "game wins")
                {
                    return TournamentRankedBy.GameWins;
                }

                if (value == "points scored")
                {
                    return TournamentRankedBy.PointsScored;
                }

                if (value == "custom")
                {
                    return TournamentRankedBy.Custom;
                }

                throw new ArgumentException("Unknow Tournament Rank: " + value);
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

        private class TournamentStateConverter : JsonConverter
        {
            /// <summary>
            /// Writes the JSON representation of the object.
            /// </summary>
            /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
            /// <exception cref="NotImplementedException"></exception>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Reads the JSON representation of the object.
            /// </summary>
            /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
            /// <returns>
            /// The object value.
            /// </returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var value = reader.Value as string;
                if (value == "pending")
                {
                    return TournamentState.pending;
                }

                if (value == "underway")
                {
                    return TournamentState.underway;
                }

                if (value == "awaiting_review")
                {
                    return TournamentState.awaiting_review;
                }

                if (value == "complete")
                {
                    return TournamentState.complete;
                }

                throw new ArgumentException("Unknow Tournament State: " + value);
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
