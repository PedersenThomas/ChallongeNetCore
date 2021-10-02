namespace ChallongeNetCoreTests
{
    using ChallongeNetCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TournamentTest: IDisposable
    {
        private readonly ChallongeV1Connection client;
        private Tournament tournament;

        public TournamentTest(Xunit.Abstractions.ITestOutputHelper output)
        {
            client = new ChallongeV1Connection(Secrets.ChallongeUsername, Secrets.ChallongeApiKey)
            {
                DebugWriteline = output.WriteLine
            };
        }
        
        [Fact]
        public async Task IndexTournament()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);

            var allTournaments = await client.Tournament.IndexRequest()
                .SetSubdomain(Secrets.ChallongeSubdomain)
                .SendAsync();
            var expectedTournament = allTournaments.SingleOrDefault(t => t.Id == this.tournament.Id);

            Assert.NotNull(expectedTournament);
            Assert.Equal(expectedTournament.Name, this.tournament.Name);
        }

        [Fact]
        public async Task ShowTournament()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);

            var expectedTournament = await client.Tournament.ShowRequest(tournament.Id.ToString())
                .SetIncludeParticipants(true)
                .SendAsync();

            Assert.NotNull(expectedTournament);
            Assert.Equal(this.tournament.Name, expectedTournament.Name);
            Assert.NotNull(expectedTournament.Participants);
        }

        [Fact]
        public async Task ShowTournamentIncludingParticipants()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            var participant = await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var expectedTournament = await client.Tournament.ShowRequest(tournament.Id.ToString())
                .SetIncludeParticipants(true)
                .SendAsync();

            Assert.NotNull(expectedTournament);
            Assert.Equal(this.tournament.Name, expectedTournament.Name);
            Assert.NotNull(expectedTournament.Participants);
            Assert.Single(expectedTournament.Participants);
        }

        [Fact]
        public async Task UpdateTournament() {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            
            var newName = "NetCoreTest" + TestHelper.RandomName();
            var updatedTournament = await client.Tournament.UpdateRequest(this.tournament.Id.ToString())
                .SetName(newName)
                .SendAsync();
            
            Assert.Equal(newName, updatedTournament?.Name);
        }

        [Fact]
        public async Task StartTournament()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            Assert.Equal(TournamentState.pending, this.tournament.Tournamentstate);
            
            //Start requires at least two participants
            await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var startedTournament = await client.Tournament.StartRequest(tournament.Id.ToString())
                .SendAsync();

            Assert.Equal(TournamentState.underway, startedTournament.Tournamentstate);
        }

        [Fact]
        public async Task FinalizeTournament()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            Assert.Equal(TournamentState.pending, this.tournament.Tournamentstate);
            
            //Start requires at least two participants
            var p1 = await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var startedTournament = await client.Tournament.StartRequest(tournament.Id.ToString())
                .SendAsync();

            var matches = await client.Match.IndexRequest(startedTournament.Id.ToString()).SendAsync();
            Assert.Single(matches);

            var match = matches.First();
            await client.Match.UpdateRequest(startedTournament.Id.ToString(), match.Id)
                .setScoresCsv("1-0")
                .setWinnerId(p1.Id)
                .SendAsync();

            var finalTournament = await client.Tournament.FinalizeRequest(this.tournament.Id.ToString()).SendAsync();
            Assert.Equal(TournamentState.complete, finalTournament.Tournamentstate);
        }

        [Fact]
        public async Task ResetTournament()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            Assert.Equal(TournamentState.pending, this.tournament.Tournamentstate);

            //Start requires at least two participants
            await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var startedTournament = await client.Tournament.StartRequest(tournament.Id.ToString())
                .SendAsync();

            Assert.Equal(TournamentState.underway, startedTournament.Tournamentstate);

            var resetTournament = await client.Tournament.ResetRequest(tournament.Id.ToString())
                .SendAsync();

            Assert.Equal(TournamentState.pending, resetTournament.Tournamentstate);
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
            Dispose(true);
        }
        #endregion
    }
}
