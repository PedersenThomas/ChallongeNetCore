using ChallongeNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ChallongeNetCoreTests
{
    public class TournamentTest: IDisposable
    {
        private ChallongeV1Connection client;
        private Tournament tournament;

        public TournamentTest(Xunit.Abstractions.ITestOutputHelper output)
        {
            client = new ChallongeV1Connection(Secrets.ChallongeUsername, Secrets.ChallongeApiKey);
            client.DebugWriteline = output.WriteLine;
        }
        
        [Fact]
        public async Task Index()
        {
            this.tournament = await TestHelper.createTestTournamentAsync(client);

            var allTournaments = await client.Tournament.IndexRequest()
                .setSubdomain(Secrets.ChallongeSubdomain)
                .SendAsync();
            var expectedTournament = allTournaments.SingleOrDefault(t => t.Id == this.tournament.Id);

            Assert.NotNull(expectedTournament);
            Assert.Equal(expectedTournament.Name, this.tournament.Name);
        }

        [Fact]
        public async Task Show()
        {
            this.tournament = await TestHelper.createTestTournamentAsync(client);

            var expectedTournament = await client.Tournament.ShowRequest(tournament.Id.ToString())
                .setIncludeParticipants(true)
                .SendAsync();

            Assert.NotNull(expectedTournament);
            Assert.Equal(this.tournament.Name, expectedTournament.Name);
            Assert.NotNull(expectedTournament.Participants);
        }

        //[Fact] NOT DONE.
        public async Task Start()
        {
            this.tournament = await TestHelper.createTestTournamentAsync(client);
            Assert.Equal(TournamentState.pending, this.tournament.Tournamentstate);
            
            //TODO(TP): Add two participants

            var startedTournament = await client.Tournament.StartRequest(tournament.Id.ToString())
                .SendAsync();

            Assert.Equal(TournamentState.pending, this.tournament.Tournamentstate);
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
                        client.Tournament.DeleteRequest(tournament.Id.ToString()).SendAsync().Wait();
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
