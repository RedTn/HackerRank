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
            #region Practice
            //Practice
            //SnakeCase();
            //ClimbLeaderboard();
            #endregion

            #region TODO
            //TODO
            //JourneyToMoon();
            //StringPermutation();

            //HashSetTest();
            #endregion

            #region Week of Code 27
            //https://www.hackerrank.com/contests/w27/challenges
            //DrawingBook();
            //TailorShop();
            //HackonacciMatrix();

            //Common application
            //CountingBinarySubstrings();
            #endregion

            #region CTCI solutions
            //LLSum();
            //LLSumReverse();
            #endregion
        }

        /// <summary>
        ///FOLLOW UP
        ///Suppose the digits are stored in forward order.Repeat the above problem.
        ///Input: (6 -> 1 -> 7) + (2 -> 9 -> 5).Thatis,617 + 295.
        ///Output: 9 - > 1 - > 2. That is, 912.
        /// </summary>
        private static void LLSumReverse()
        {
            LinkedListNode p = new LinkedListNode();
            LinkedListNode q = new LinkedListNode();
            p = LinkedListNode.GenerateList(new List<int> { 7, 1, 6 });
            q = LinkedListNode.GenerateList(new List<int> { 1, 5, 9, 2 });

            bool blank;
            LinkedListNode current = LinkedListSumReverse(p, q, out blank);
            Console.WriteLine(current);
        }

        private static LinkedListNode LinkedListSumReverse(LinkedListNode n, LinkedListNode m, out bool carry)
        {
            bool thiscarry = false;
            LinkedListNode current = new LinkedListNode();
            int sum = 0;
            int n_length = LinkedListNode.GetLength(n);
            int m_length = LinkedListNode.GetLength(m);

            if(n_length < m_length)
            {
                n = LinkedListNode.Pad(n, m_length - n_length);
            }
            if(m_length < n_length)
            {
                m = LinkedListNode.Pad(m, n_length - m_length);
            }

            if(n.Next != null || m.Next != null)
            {
                current.Next = LinkedListSumReverse(n.Next, m.Next, out thiscarry);
            }
            
            if (n != null)
            {
                sum += n.Val;
            }

            if (m != null)
            {
                sum += m.Val;
            }

            if(thiscarry)
            {
                sum++;
            }

            current.Val = sum % 10;
            carry = sum >= 10;
            return current;
        }

        /// <summary>
        /// 2.5
        /// Sum Lists: You have two numbers represented by a linked list, where each node contains a single
        ///digit.The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
        ///function that adds the two numbers and returns the sum as a linked list.
        ///EXAMPLE
        ///Input: (7-> 1 -> 6) + (5 -> 9 -> 2) .Thatis,617 + 295.
        ///Output: 2 - > 1 - > 9. That is, 912.
        /// </summary>
        private static void LLSum()
        {
            LinkedListNode p = new LinkedListNode();
            LinkedListNode q = new LinkedListNode();
            p = LinkedListNode.GenerateList(new List<int> { 7, 1, 6 });
            q = LinkedListNode.GenerateList(new List<int> { 1, 5, 9, 2 });

            LinkedListNode current = LinkedListSum(p, q, false);
            Console.WriteLine(current.ToString());
        }

        private static LinkedListNode LinkedListSum(LinkedListNode n, LinkedListNode m, bool carry)
        {
            LinkedListNode current = new LinkedListNode();
            int n_val = 0;
            int m_val = 0;
            bool action = false;

            if(n != null)
            {
                action = true;
                n_val = n.Val;
            }

            if(m != null)
            {
                action = true;
                m_val = m.Val;
            }

            if(action || carry)
            {
                int sum = n_val + m_val + (carry ? 1 : 0);
                current.Val = sum % 10;
                if(n?.Next != null || m?.Next != null || sum >= 10)
                {
                    current.Next = LinkedListSum(n?.Next, m?.Next, sum >= 10);
                }
            }

            return current;
        }

        private static void HashSetTest()
        {
            HashSet<string> mem = new HashSet<string>();

            mem.Add("test");
            mem.Add("test2");

            Console.WriteLine(mem.Contains("test"));
            Console.WriteLine(mem.Contains("test3"));

        }

        private static void StringPermutation()
        {
            Console.WriteLine("Input string");
            string input = Console.ReadLine();
        }

        private static void JourneyToMoon()
        {
            string[] init = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(init[0]);
            int p = Convert.ToInt32(init[1]);
            List<int[]> pairs = new List<int[]>();
            for (int i = 0; i < p; i++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                int[] pair = Array.ConvertAll(temp, Int32.Parse);
                pairs.Add(pair);
            }
            int result = 0;
            while(pairs.Count > 1)
            {
                
            }
            Console.WriteLine(result);
        }

        /// <summary>
        /// This function will recursively sort and find all substrings in the input to guarantee they are all grouped consecutively
        /// </summary>
        /// <param name="input"></param>
        /// <param name="substrings"></param>
        private static void FindSubstring(string input, ref List<string> substrings)
        {
            char marker = input[0];
            string sb = String.Empty;
            bool hasChanged = false;
            int indexAtChange = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char index = input[i];
                if (index != marker)
                {
                    if (!hasChanged)
                    {
                        indexAtChange = i;
                        hasChanged = true;
                        marker = index;
                        sb += index;
                    }
                    else
                    {
                        if (indexAtChange < input.Length)
                        {
                            string sub = input.Substring(indexAtChange, input.Length - indexAtChange);
                            FindSubstring(sub, ref substrings);
                            break;
                        }
                    }
                }
                else
                {
                    sb += index;
                }
            }
            substrings.Add(sb.ToString());
        }

        /// <summary>
        /// My common application submitted on Jan.7 2017. 
        /// Objective: In a string of 0's and 1's, find all substrings of consecutive 0's and 1's where the numbers of 0's equals the number of 1's and return the count
        /// Example: 00110 = 0011, 01, 10 == 3; 10101 = 10, 01, 10, 01 == 4
        /// Bug: Bug in code detected when transferring from IDE to HackerRank where "input = Console.ReadLine();"
        /// Comments: I noticed late in the submission that StringBuilder was not a supported class in HackerRanks envrionment, so I had to quickly change to an '+' operator.
        ///     This would create an entirely new string in memory and is not an ideal solution, can be improved.
        /// </summary>
        private static void CountingBinarySubstrings()
        {
            /*
             * Complete the function below.
             */
            List<string> substrings = new List<string>();
            string input;
            input = Console.ReadLine();

            FindSubstring(input, ref substrings);
            int counter = 0;
            foreach(string substring in substrings)
            {
                int zeroes = 0;
                int ones = 0;
                for(int i = 0; i < substring.Length; i++)
                {
                    if(substring[i] == '0')
                    {
                        zeroes++;
                    }
                    else
                    {
                        ones++;
                    }
                }
                // Because substrings have already been sorted to be consecutive, the only examples of substrings would fall under '01' or '10'
                // All other patterns would just append more 0's or 1's at the front or end '0011', '0000011', '1110' etc.
                if(zeroes >= ones)
                {
                    counter += ones;
                }
                else
                {
                    counter += zeroes;
                }
            }
            Console.WriteLine(counter);
        }

        private static void HackonacciMatrix()
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int rightAngleResult = 0;
            int straightAngleResult = 0;
            int counter = 0;

            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int q = Convert.ToInt32(tokens_n[1]);

            bool[,] matrix = new bool[n, n];
            ConstructHackonacci(n, ref matrix, ref map);
            int[] angles = new int[q];

            for (int a0 = 0; a0 < q; a0++)
            {
                int angle = Convert.ToInt32(Console.ReadLine());
                // your code goes here
                angles[a0] = angle;
            }

            bool[,] rightAngle = RotateHackonacci(matrix, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(matrix[i,j] != rightAngle[i,j])
                    {
                        counter++;
                    }
                }
            }
            rightAngleResult = counter;

            counter = 0;
            bool[,] straightAngle = RotateHackonacci(rightAngle, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != straightAngle[i, j])
                    {
                        counter++;
                    }
                }
            }
            straightAngleResult = counter;

            foreach(int angle in angles)
            {
                int currentAngle = angle % 360;
                if(currentAngle == 0)
                {
                    Console.WriteLine(0);
                }
                else if(currentAngle == 90 || currentAngle == 270)
                {
                    Console.WriteLine(rightAngleResult);
                }
                else
                {
                    Console.WriteLine(straightAngleResult);
                }
            }
        }

        

        static bool[,] RotateHackonacci(bool[,]matrix, int size)
        {
            bool[,] ret = new bool[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    ret[i, j] = matrix[size - j - 1, i];
                }
            }

            return ret;
        }

        static void ConstructHackonacci(int size, ref bool[,] matrix, ref Dictionary<int, int> map)
        {
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if (Hackonacci((i+1) * (i+1) * (j+1) * (j+1), ref map) % 2 == 1)
                    {
                        matrix[i, j] = true;
                    }
                }
            }
        }

        static int Hackonacci(int input, ref Dictionary<int, int> map)
        {
            switch(input)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                default:
                    {
                        if(map.ContainsKey(input))
                        {
                            return map[input];
                        }
                        map.Add(input, Hackonacci(input-1, ref map) + 2 * Hackonacci(input - 2, ref map) + 3 * Hackonacci(input - 3, ref map));
                        return map[input];
                    }
                    
            }
        }

        //Not to submit
        private static void DebugMatrix(bool[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", Convert.ToInt32(matrix[i, j]));
                }
                Console.WriteLine();
            }
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
