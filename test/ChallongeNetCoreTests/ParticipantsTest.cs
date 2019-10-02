﻿using ChallongeNetCore;
using ChallongeNetCore.models;
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

        [Fact]
        public async Task IndexParticipant()
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
        public async Task ShowParticipant()
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

        [Fact]
        public async Task BulkAddParticipant()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participants = await client.Participant.BulkAddRequest(this.tournament.Id.ToString())
                .AddParticipant(new BulkParticipant { Name = "Player1" })
                .AddParticipant(new BulkParticipant { Name = "Player2" })
                .SendAsync();

            participants = await client.Participant.IndexRequest(this.tournament.Id.ToString())
                .SendAsync();

            Assert.Equal(2, participants.Count());
            Assert.NotNull(participants.SingleOrDefault(p => string.Equals(p.Name, "Player1", StringComparison.OrdinalIgnoreCase)));
            Assert.NotNull(participants.SingleOrDefault(p => string.Equals(p.Name, "Player2", StringComparison.OrdinalIgnoreCase)));
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
