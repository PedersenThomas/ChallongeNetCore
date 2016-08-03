namespace ChallongeNetCore
{
    public class ParticipantClient
    {
        public ChallongeV1Connection connection { get; private set; }

        public ParticipantClient(ChallongeV1Connection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Retrieve a tournament's participant list.
        /// </summary>
        /// <param name="tournamentIdentifier">Tournament identifier (Id or tournament_url or subdomain-tournament_url if subdomains are used)</param>
        /// <returns></returns>
        public clients.ParticipantRequest.IndexRequest IndexRequest(string tournamentIdentifier)
        {
            return new clients.ParticipantRequest.IndexRequest(this.connection, tournamentIdentifier);
        }

        /// <summary>
        /// Add a participant to a tournament (up until it is started). 
        /// </summary>
        /// <param name="tournamentIdentifier">Tournament identifier (Id or tournament_url or subdomain-tournament_url if subdomains are used)</param>
        /// <returns></returns>
        public clients.ParticipantRequest.CreateRequest CreateRequest(string tournamentIdentifier) 
        {
            return new clients.ParticipantRequest.CreateRequest(this.connection, tournamentIdentifier);
        }

        /// <summary>
        /// Retrieve a single participant record for a tournament.
        /// </summary>
        /// <param name="tournamentIdentifier">Tournament identifier (Id or tournament_url or subdomain-tournament_url if subdomains are used)</param>
        /// <param name="participantIdentifier">Participant identifer (Id)</param>
        /// <returns></returns>
        public clients.ParticipantRequest.ShowRequest ShowRequest(string tournamentIdentifier, string participantIdentifier)
        {
            return new clients.ParticipantRequest.ShowRequest(this.connection, tournamentIdentifier, participantIdentifier);
        }

        //Bulk Add
        //Show
        //Update
        //Check in
        //Undo Check in
        //Destroy
        //Randomize
    }
}
