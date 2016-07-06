using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCore.clients
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
    }
}
