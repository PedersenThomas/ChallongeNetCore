using ChallongeNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ChallongeNetCoreTests
{
    public class ParticipantsTest : IDisposable
    {

        private ChallongeV1Connection client;
        private Tournament tournament;

        public ParticipantsTest(Xunit.Abstractions.ITestOutputHelper output)
        {
            client = new ChallongeV1Connection(Secrets.ChallongeUsername, Secrets.ChallongeApiKey);
            client.DebugWriteline = output.WriteLine;
        }

        [Fact]
        public async Task CreateParticipant()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participantName = TestHelper.RandomName();
            var participant = await client.Participant.CreateRequest(this.tournament.Id.ToString())
                .SetName(participantName)
                .SendAsync();

            Assert.NotNull(participant);
            Assert.Equal(participantName, participant.Name);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (tournament != null)
                    {
                        client.Tournament.DeleteRequest(tournament.Id.ToString())
                            .SendAsync().Wait();
                    }
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
