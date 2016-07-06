﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore
{
    public static class TournamentRankedByExtensions
    {
        public static string ToChallongeString(this TournamentRankedBy item)
        {
            switch (item)
            {
                case TournamentRankedBy.MatchWins:
                    return "match wins";
                case TournamentRankedBy.GameWins:
                    return "game wins";
                case TournamentRankedBy.PointsScored:
                    return "points scored";
                case TournamentRankedBy.Custom:
                    return "custom";
            }

            throw new ArgumentException("TournamentRankedBy is extended without TournamentRankedByExtensions knowing about it.");
        }
    }
}