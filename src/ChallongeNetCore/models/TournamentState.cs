namespace ChallongeNetCore
{
    /// <summary>
    /// The state of a tournament
    /// </summary>
    public enum TournamentState
    {
        /// <summary>
        /// Refers to a tournament that is not started yet
        /// </summary>
        /// StringEnumConverter
        pending,

        /// <summary>
        /// Refers to a tournament that is started but not done yet
        /// </summary>
        underway,

        /// <summary>
        /// Refers to a tournament which is done, but is waiting for at review from the organizer.
        /// </summary>
        awaiting_review,

        /// <summary>
        /// Refers to a finished tournament
        /// </summary>
        complete
    }
}
