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

        /// <summary>
        /// Update the attributes of a tournament participant.
        /// </summary>
        /// <param name="tournamentIdentifier">Tournament ID (e.g. 10230) or URL (e.g. 'single_elim' for challonge.com/single_elim). If assigned to a subdomain, URL format must be subdomain-tournament_url (e.g. 'test-mytourney' for test.challonge.com/mytourney)</param>
        /// <param name="participantIdentifier">The participant's unique ID</param>
        /// <returns></returns>
        public clients.ParticipantRequest.UpdateRequest UpdateRequest(string tournamentIdentifier, string participantIdentifier)
        {
            return new clients.ParticipantRequest.UpdateRequest(this.connection, tournamentIdentifier, participantIdentifier);
        }

        /// <summary>
        /// If the tournament has not started, delete a participant, automatically filling in the abandoned seed number. If tournament is underway, mark a participant inactive, automatically forfeiting his/her remaining matches.
        /// </summary>
        /// <param name="tournamentIdentifier">Tournament ID (e.g. 10230) or URL (e.g. 'single_elim' for challonge.com/single_elim). If assigned to a subdomain, URL format must be subdomain-tournament_url (e.g. 'test-mytourney' for test.challonge.com/mytourney)</param>
        /// <param name="participantIdentifier">The participant's unique ID</param>
        /// <returns></returns>
        public clients.ParticipantRequest.DestroyRequest DestroyRequest(string tournamentIdentifier, string participantIdentifier)
        {
            return new clients.ParticipantRequest.DestroyRequest(this.connection, tournamentIdentifier, participantIdentifier);
        }

        /// <summary>
        /// Randomize seeds among participants. Only applicable before a tournament has started.
        /// </summary>
        /// <param name="tournamentIdentifier">Tournament ID (e.g. 10230) or URL (e.g. 'single_elim' for challonge.com/single_elim). If assigned to a subdomain, URL format must be subdomain-tournament_url (e.g. 'test-mytourney' for test.challonge.com/mytourney)</param>
        /// <returns></returns>
        public clients.ParticipantRequest.RandomizeRequest RandomizeRequest(string tournamentIdentifier)
        {
            return new clients.ParticipantRequest.RandomizeRequest(this.connection, tournamentIdentifier);
        }

        /// <summary>
        /// Bulk add participants to a tournament (up until it is started). If an invalid participant is detected, bulk participant creation will halt and any previously added participants (from this API request) will be rolled back.
        /// </summary>
        /// <param name="tournamentIdentifier">Tournament ID (e.g. 10230) or URL (e.g. 'single_elim' for challonge.com/single_elim). If assigned to a subdomain, URL format must be subdomain-tournament_url (e.g. 'test-mytourney' for test.challonge.com/mytourney)</param>
        /// <returns></returns>
        public clients.ParticipantRequest.BulkAddRequest BulkAddRequest(string tournamentIdentifier)
        {
            return new clients.ParticipantRequest.BulkAddRequest(this.connection, tournamentIdentifier);
        }
        
        //Check in
        //Undo Check in
    }
}
