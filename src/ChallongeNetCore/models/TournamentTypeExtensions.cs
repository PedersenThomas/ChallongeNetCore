﻿namespace ChallongeNetCore
{
    using System;

    public static class TournamentTypeExtensions
    {
        public static string ToChallongeString(this TournamentType me)
        {
            switch (me)
            {
                case TournamentType.SingleElimination:
                    return "single elimination";
                case TournamentType.DoubleElimination:
                    return "double elimination";
                case TournamentType.RoundRobin:
                    return "round robin";
                case TournamentType.Swiss:
                    return "swiss";
            }

            throw new ArgumentException("TournamentType is extended without TournamentTypeExtensions knowing about it.");
        }
    }
}
