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
    }
}
