namespace ChallongeNetCoreTests
{
    using ChallongeNetCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class MatchTests : IDisposable
    {
        private readonly ChallongeV1Connection client;
        private Tournament tournament;

        public MatchTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            client = new ChallongeV1Connection(Secrets.ChallongeUsername, Secrets.ChallongeApiKey)
            {
                DebugWriteline = output.WriteLine
            };
        }

        [Fact]
        public async Task UnderwayMarking()
        {
            this.tournament = await TestHelper.CreateTestTournamentAsync(client);
            await TestHelper.CreateTestParticipantAsync(client, this.tournament);
            await TestHelper.CreateTestParticipantAsync(client, this.tournament);

            var startedTournament = await client.Tournament.StartRequest(tournament.Id.ToString())
                .SetIncludeMatches(true)
                .SendAsync();

            Assert.True(startedTournament.Matches.All(m => m.Match.UnderwayAt == null), "There are at least one match where it is underway. Debug test to find which.");

            var firstMatch = startedTournament.Matches.First();
            var markedFirstMatch = await client.Match.MarkUnderwayRequest(this.tournament.Id.ToString(), firstMatch.Match.Id)
                .SendAsync();
            Assert.NotNull(markedFirstMatch.UnderwayAt);

            var unmarkedFirstMatch = await client.Match.UnmarkUnderwayRequest(this.tournament.Id.ToString(), firstMatch.Match.Id)
                .SendAsync();
            Assert.Null(unmarkedFirstMatch.UnderwayAt);
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
