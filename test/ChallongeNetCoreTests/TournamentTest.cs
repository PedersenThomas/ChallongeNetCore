using ChallongeNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;

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

        #region Helper
        private async Task<Tournament> createTestTournamentAsync()
        {
            var name = "NetCoreTest" + TestHelper.RandomName();

            var request = client.Tournament.CreateRequest()
                .SetName(name)
                .SetUrl(name)
                .SetTournamentType(TournamentType.DoubleElimination)
                .SetSubdomain(Secrets.ChallongeSubdomain);

            return await request.SendAsync();
        }
        #endregion

        [Fact]
        public async Task Index()
        {
            this.tournament = await createTestTournamentAsync();

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
            this.tournament = await createTestTournamentAsync();

            var expectedTournament = await client.Tournament.ShowRequest(tournament.Id.ToString())
                .setIncludeParticipants(true)
                .SendAsync();

            Assert.NotNull(expectedTournament);
            Assert.Equal(this.tournament.Name, expectedTournament.Name);
            Assert.NotNull(expectedTournament.Participants);
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
