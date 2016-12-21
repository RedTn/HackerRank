using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //SnakeCase();
            //ClimbLeaderboard();

            //Week of Code 27
            //https://www.hackerrank.com/contests/w27/challenges
            //DrawingBook();
            TailorShop();
        }

        /// <summary>
        /// https://www.hackerrank.com/contests/w27/challenges/tailor-shop
        /// Constraints:
        /// 1 <= n,p,a_i <= 10^5
        /// Time complexity:
        /// O(n), where n = clusters, assuming bool array lookup is O(1)
        /// Space complexity:
        /// O(1), constant if constraints do not change
        /// </summary>
        private static void TailorShop()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int p = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            // your code goes here

            int buttons = 0;
            //Because input can never be > 10^5, and values are only decreased, initialize memory array that can contain all possible values
            bool[] memory = new bool[100000];
            int clusters = n;
            int price = p;
            Array.Sort(a);
            for(int i = 0; i < clusters; i++)
            {
                int buttonsNeeded = (int)Math.Ceiling((double)a[i] / price);
                while(memory[buttonsNeeded])
                {
                    buttonsNeeded++;
                }
                memory[buttonsNeeded] = true;
                buttons += buttonsNeeded;
            }
            Console.WriteLine(buttons);
        }

        /// <summary>
        /// https://www.hackerrank.com/contests/w27/challenges/drawing-book
        /// Constraints: 
        /// 1 <= n <= 10^5
        /// 1 <= p <= n
        /// Time complexity:
        /// O(1)
        /// Space complexity:
        /// O(1)
        /// </summary>
        private static void DrawingBook()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int p = Convert.ToInt32(Console.ReadLine());
            // your code goes here

            //Can simplify problem if assume pages are even, (2,3) is same as (2,-)
            if(n % 2 == 1)
            {
                n--;
            }
            if(p % 2 == 1)
            {
                p--;
            }

            //Find distance to edges, start counting from smallest side
            int leftbound = (0 - p) * -1;
            int rightbound = n - p;
            if(rightbound < leftbound)
            {
                Console.WriteLine(rightbound / 2);
            }
            else
            {
                Console.WriteLine(leftbound / 2);
            }
        }

        private static void ClimbLeaderboard()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] scores_temp = Console.ReadLine().Split(' ');
            int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);
            int m = Convert.ToInt32(Console.ReadLine());
            string[] alice_temp = Console.ReadLine().Split(' ');
            int[] alice = Array.ConvertAll(alice_temp, Int32.Parse);
            // your code goes here
            int score = 0;
            for (int i = 0; i < m; i++)
            {
                score += alice[i];
                int rank = 1;
                int prevScore = Int32.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    if(score >= scores[j])
                    {
                        Console.WriteLine(rank);
                        break;
                    }
                    else if(scores[j] < prevScore)
                    {
                        rank++;
                        prevScore = scores[j];
                    }
                    if(j == n-1)
                    {
                        Console.WriteLine(rank);
                    }
                }
            }
        }

        private static void CalculateRanking()
        {

        }

        static void SnakeCase()
        {
            string s = Console.ReadLine();
            Console.WriteLine(s.Split('_').Length);
        }

        void old()
        {
            int[][] arr = new int[6][];
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }
            int max = 0;
            for (int j = 1; j < 5; j++)
            {
                int thisMax = 0;
                for (int i = 0; i < 4; i++)
                {
                    thisMax += arr[i][j - 1];
                }
            }
        }
    }
}
