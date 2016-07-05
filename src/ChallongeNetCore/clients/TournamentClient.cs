using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore
{
    public class TournamentClient
    {
        public ChallongeV1Connection connection { get; private set; }

        public TournamentClient(ChallongeV1Connection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Retrieve a set of tournaments created with your account.
        /// </summary>
        /// <returns></returns>
        public clients.TournamentRequest.CreateRequest CreateRequest()
        {
            return new clients.TournamentRequest.CreateRequest(this.connection);
        }

        /// <summary>
        /// Retrieve a set of tournaments created with your account.
        /// </summary>
        /// <returns></returns>
        public clients.TournamentRequest.IndexRequest IndexRequest()
        {
            return new clients.TournamentRequest.IndexRequest(this.connection);
        }

        /// <summary>
        /// Retrieve a single tournament record created with your account.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public clients.TournamentRequest.ShowRequest ShowRequest(string identifier)
        {
            return new clients.TournamentRequest.ShowRequest(this.connection, identifier);
        }

        /// <summary>
        /// Deletes a tournament along with all its associated records. There is no undo, so use with care!
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public clients.TournamentRequest.DeleteRequest DeleteRequest(string identifier)
        {
            return new clients.TournamentRequest.DeleteRequest(this.connection, identifier);
        }

        /// <summary>
        /// Start a tournament, opening up first round matches for score reporting. The tournament must have at least 2 participants.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public clients.TournamentRequest.StartRequest StartRequest(string identifier)
        {
            return new clients.TournamentRequest.StartRequest(this.connection, identifier);
        }

        /// <summary>
        /// Finalize a tournament that has had all match scores submitted, rendering its results permanent.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public clients.TournamentRequest.FinalizeRequest FinalizeRequest(string identifier)
        {
            return new clients.TournamentRequest.FinalizeRequest(this.connection, identifier);
        }
    }
}
