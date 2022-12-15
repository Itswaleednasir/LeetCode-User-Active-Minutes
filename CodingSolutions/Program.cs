using System;
using System.Collections.Generic;

namespace CodingSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] logs = { new []{0,5},new []{1,2},new []{0,2},new []{0,5},new []{1,3}};
            var activeUsersMinutes = FindingUsersActiveMinutes(logs, 5);

            foreach (var item in activeUsersMinutes)
            {
                Console.Write(" {0}", item);
            }
        }
        
        public static int[] FindingUsersActiveMinutes(int[][] logs, int k)
        {
            Dictionary<int, HashSet<int>> userActiveMinutes = new Dictionary<int, HashSet<int>>();

            for(int i = 0; i < logs.Length; i++)
            {
                int[] userArray = logs[i];

                int user = userArray[0];
                int time = userArray[1];
                if (!userActiveMinutes.TryGetValue(user, out _))
                    userActiveMinutes[user] = new HashSet<int>{time};
                else
                    userActiveMinutes[user].Add(time);
            }

            int[] userCountWithTheirActiveMinutes = new int[k];
            
            foreach (var item in userActiveMinutes)
            {
                userCountWithTheirActiveMinutes[item.Value.Count - 1] += 1;
            }

            return userCountWithTheirActiveMinutes;
        }
    }
}