using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore
{
    public class MatchClient
    {
        public ChallongeV1Connection connection { get; private set; }

        public MatchClient(ChallongeV1Connection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Retrieve a tournament's match list.
        /// </summary>
        /// <param name="tournamentIdentifier"></param>
        /// <returns></returns>
        public clients.MatchRequest.IndexRequest IndexRequest(string tournamentIdentifier)
        {
            return new clients.MatchRequest.IndexRequest(this.connection, tournamentIdentifier);
        }
        
        /// <summary>
        /// Retrieve a single match record for a tournament.
        /// </summary>
        /// <param name="tournamentIdentifier"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public clients.MatchRequest.ShowRequest ShowRequest(string tournamentIdentifier, int matchId)
        {
            return new clients.MatchRequest.ShowRequest(this.connection, tournamentIdentifier, matchId);
        }

        /// <summary>
        /// Update/submit the score(s) for a match.
        /// </summary>
        /// <param name="tournamentIdentifier"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public clients.MatchRequest.UpdateRequest UpdateRequest(string tournamentIdentifier, int matchId)
        {
            return new clients.MatchRequest.UpdateRequest(this.connection, tournamentIdentifier, matchId);
        }
    }
}
