using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
