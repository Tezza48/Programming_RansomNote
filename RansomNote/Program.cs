using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RansomNote
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<char, int> magazineCount = new Dictionary<char, int>();

            string letterIn = File.ReadAllText(@"letter.txt");
            string magazineIn = File.ReadAllText(@"magazine.txt");
            bool canUse = true;

            letterIn.Replace("\n", "").Replace(" ", "");
            magazineIn.Replace("\n", "").Replace(" ", "");

            foreach (char letter in magazineIn)
            {
                try
                {
                    magazineCount[letter]++;
                }
                catch
                {
                    magazineCount.Add(letter, 1);
                }
            }

            foreach (char letter in letterIn)
            {
                try
                {
                    if (magazineCount[letter] > 0) magazineCount[letter]--;
                    else
                    {
                        canUse = false;
                        break;
                    }
                }
                catch
                {
                    canUse = false;
                    break;
                }
            }
            if (canUse)
            {
                Console.WriteLine("You can use this magazine! Go bag youself a hostage!");
            }
            else
            {
                Console.WriteLine("the magazine does not have enough of the \nrequired letters!");
            }
            Console.ReadKey();
        }
    }
}
