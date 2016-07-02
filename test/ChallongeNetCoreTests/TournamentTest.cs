using ChallongeNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;

namespace ChallongeNetCoreTests
{
    public class TournamentTest
    {
        private ChallongeV1Connection client;
        private Tournament tournament;

        public TournamentTest(Xunit.Abstractions.ITestOutputHelper output)
        {
            client = new ChallongeV1Connection(Secrets.ChallongeUsername, Secrets.ChallongeApiKey);
            client.DebugWriteline = output.WriteLine;

            //createTestTournament();
        }

        private Tournament createTestTournament()
        {
            var name = "NetCoreTest" + TestHelper.RandomName();

            var request = client.Tournament.CreateRequest()
                .SetName(name)
                .SetUrl(name)
                .SetTournamentType(TournamentType.DoubleElimination)
                .SetSubdomain(Secrets.ChallongeSubdomain);

            var task = request.SendAsync();
            task.Wait();
            return task.Result;
        }

        [Fact]
        public async Task Index()
        {
            var result = await client.Tournament.IndexRequest().SendAsync();
            Assert.NotNull(result);

            Assert.True(false);
        }

        [Fact]
        public async Task Show()
        {
            var identifier = "RandomID";
            var request = client.Tournament.ShowRequest(identifier);
            request.IncludeParticipants = true;
                
            var result = await request.SendAsync();
            Assert.NotNull(result.Participants);

            Assert.True(false);
        }

        [Fact]
        public void TestConstructor()
        {
            client.DebugWriteline("Test Constructor");
            var tournament = createTestTournament();
            Assert.NotNull(tournament);
        }
    }
}
