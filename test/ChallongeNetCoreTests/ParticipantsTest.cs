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
        public async Task Create()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participantName = TestHelper.RandomName();
            var participant = await client.Participant.CreateRequest(this.tournament.Id.ToString())
                .SetName(participantName)
                .SendAsync();

            Assert.NotNull(participant);
            Assert.Equal(participantName, participant.Name);
        }

        [Fact]
        public async Task Index()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participant1 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            var participant2 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var allParticipants = await client.Participant.IndexRequest(this.tournament.Id.ToString())
                .SendAsync();

            Assert.True(allParticipants.Any(p => p.Id == participant1.Id));
            Assert.True(allParticipants.Any(p => p.Id == participant2.Id));
        }

        [Fact]
        public async Task Show()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participant1 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            var participant2 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var allParticipants = await client.Participant.IndexRequest(this.tournament.Id.ToString())
                .SendAsync();

            Assert.True(allParticipants.Any(p => p.Id == participant1.Id));
            Assert.True(allParticipants.Any(p => p.Id == participant2.Id));
        }

        [Fact]
        public async Task UpdateParticipant()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participant = await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            var newName = "new" + TestHelper.RandomName();

            var updatedParticipant = await client.Participant.UpdateRequest(this.tournament.Id.ToString(), participant.Id.ToString())
                .SetName(newName)
                .SendAsync();

            Assert.Equal(newName, updatedParticipant.Name);
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
