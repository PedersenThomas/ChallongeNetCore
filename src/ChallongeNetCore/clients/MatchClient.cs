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

        /// <summary>
        /// Reopens a match that was marked completed, automatically resetting matches that follow it
        /// </summary>
        /// <param name="tournamentIdentifier"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public clients.MatchRequest.ReopenRequest ReopenRequest(string tournamentIdentifier, int matchId)
        {
            return new clients.MatchRequest.ReopenRequest(this.connection, tournamentIdentifier, matchId);
        }

        /// <summary>
        /// Sets "underway_at" to the current time and highlights the match in the bracket
        /// </summary>
        /// <param name="tournamentIdentifier"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public clients.MatchRequest.MarkUnderwayRequest MarkUnderwayRequest(string tournamentIdentifier, int matchId)
        {
            return new clients.MatchRequest.MarkUnderwayRequest(this.connection, tournamentIdentifier, matchId);
        }

        /// <summary>
        /// Clears "underway_at" and unhighlights the match in the bracket
        /// </summary>
        /// <param name="tournamentIdentifier"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public clients.MatchRequest.UnmarkUnderwayRequest UnmarkUnderwayRequest(string tournamentIdentifier, int matchId)
        {
            return new clients.MatchRequest.UnmarkUnderwayRequest(this.connection, tournamentIdentifier, matchId);
        }
    }
}
