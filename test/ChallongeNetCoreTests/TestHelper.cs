using ChallongeNetCore;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeNetCoreTests
{
    public static class TestHelper
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks); // Thanks to McAden

        internal static string RandomName(int size = 16)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor((26 * Random.NextDouble()) + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        internal static async Task<Tournament> createTestTournamentAsync(ChallongeV1Connection client)
        {
            var name = "NetCoreTest" + TestHelper.RandomName();

            var request = client.Tournament.CreateRequest()
                .SetName(name)
                .SetUrl(name)
                .SetTournamentType(TournamentType.DoubleElimination)
                .SetSubdomain(Secrets.ChallongeSubdomain);

            return await request.SendAsync();
        }
        
        internal static async Task<Participant> CreateTestParticipantAsync(ChallongeV1Connection client, Tournament tournament) {
            var name = TestHelper.RandomName();
            
            return await client.Participant.CreateRequest(tournament.Id.ToString())
                .SetName(name)
                .SendAsync();
        }

        internal static async Task<Tournament> addTestParticipantAsync(ChallongeV1Connection client, Tournament tournament)
        {
            var name = "NetCoreTest" + TestHelper.RandomName();
            
            var request = client.Tournament.CreateRequest()
                .SetName(name)
                .SetUrl(name)
                .SetTournamentType(TournamentType.DoubleElimination)
                .SetSubdomain(Secrets.ChallongeSubdomain);

            return await request.SendAsync();
        }
    }
}
