namespace ChallongeNetCoreTests
{
    using ChallongeNetCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class ParticipantsTest : IDisposable
    {

        private readonly ChallongeV1Connection client;
        private Tournament tournament;

        public ParticipantsTest(Xunit.Abstractions.ITestOutputHelper output)
        {
            client = new ChallongeV1Connection(Secrets.ChallongeUsername, Secrets.ChallongeApiKey)
            {
                DebugWriteline = output.WriteLine
            };
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

        [Fact]
        public async Task IndexParticipant()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participant1 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            var participant2 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var allParticipants = await client.Participant.IndexRequest(this.tournament.Id.ToString())
                .SendAsync();

            Assert.Contains(allParticipants, p => p.Id == participant1.Id);
            Assert.Contains(allParticipants, p => p.Id == participant2.Id);
        }

        [Fact]
        public async Task ShowParticipant()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participant1 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            var participant2 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var allParticipants = await client.Participant.IndexRequest(this.tournament.Id.ToString())
                .SendAsync();

            Assert.Contains(allParticipants, p => p.Id == participant1.Id);
            Assert.Contains(allParticipants, p => p.Id == participant2.Id);
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

        [Fact]
        public async Task RandomizeParticipants()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            for (int i = 0; i < 16; i++)
            {
                await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            }

            var allParticipants = await client.Participant.IndexRequest(this.tournament.Id.ToString())
                .SendAsync();

            var randomizeRequest = await client.Participant.RandomizeRequest(this.tournament.Id.ToString())
                .SendAsync();

            Assert.False(IsSameOrder(allParticipants, randomizeRequest));
        }

        [Fact]
        public async Task BulkAddParticipants()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participant1Name = TestHelper.RandomName();
            var participant2Name = TestHelper.RandomName();
            var participants = await client.Participant.BulkAddRequest(this.tournament.Id.ToString())
                .AddParticipant(participant1Name, null, 1, "")
                .AddParticipant(participant2Name, null, 1, "")
                .SendAsync();

            Assert.NotNull(participants);
            Assert.Equal(2, participants.Count);
            Assert.Contains(participants, p => p.Name == participant1Name);
            Assert.Contains(participants, p => p.Name == participant2Name);
        }

        private bool IsSameOrder(IList<Participant> a, IList<Participant> b)
        {
            Assert.Equal(a.Count, b.Count);

            for (int i = 0; i < a.Count; i++)
            {
                if(a[i].Id != b[i].Id)
                {
                    return false;
                }
            }
            return true;
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
