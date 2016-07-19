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
        /// <returns></returns>
        public clients.ParticipantRequest.IndexRequest IndexRequest(string tournamentIdentifier)
        {
            return new clients.ParticipantRequest.IndexRequest(this.connection, tournamentIdentifier);
        }
        
        /// <summary>
        /// Add a participant to a tournament (up until it is started). 
        /// </summary>
        /// <returns></returns>
        public clients.ParticipantRequest.CreateRequest CreateRequest(string tournamentIdentifier) 
        {
            return new clients.ParticipantRequest.CreateRequest(this.connection, tournamentIdentifier);
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
