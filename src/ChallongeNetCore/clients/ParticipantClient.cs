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
        public clients.ParticipantRequest.IndexRequest IndexRequest()
        {
            return new clients.ParticipantRequest.IndexRequest(this.connection);
        }
        
        /// <summary>
        /// Add a participant to a tournament (up until it is started). 
        /// </summary>
        /// <returns></returns>
        public clients.ParticipantRequest.CreateRequest CreateRequest() 
        {
            return new clients.ParticipantRequest.CreateRequest(this.connection);
        }
    }
}
