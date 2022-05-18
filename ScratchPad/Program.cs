using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colors = { "Brown", "Red" };
           Console.WriteLine(scratchPad.ResistorColorDuo(colors));
            Console.ReadLine();
        }
    }

    public static class scratchPad
    {
        enum Color { Black, Brown, Red, Orange, Yellow, Green, Blue, Violet, Grey, White }
        public static int ResistorColorDuo(string[] colors)
        {
            StringBuilder sb = new StringBuilder();
            string c1 = colors[0];
            string c2 = colors[1];
            sb.Append((int)Enum.Parse(typeof(Color), c1) + 1);
            sb.Append((int)Enum.Parse(typeof(Color), c2) + 1);
            int r = int.Parse(sb.ToString());
            return r;
        }
    
        public static string SqueakyCleanStrings(string identifier)
        {

            StringBuilder sb = new StringBuilder(identifier);
            sb.Replace(' ', '_');
            string cleanControlChar = sb.ToString();
            StringBuilder rs = new StringBuilder();

            for (int i = 0; i < sb.Length; i++)
            {
                Console.WriteLine((short)char.Parse(cleanControlChar.Substring(i, 1)));

                if (char.IsControl(sb[i]))
                {
                    rs.Append("CTRL");
                }
                else if (sb[i] == '-')
                {
                    rs.Append(sb[i + 1].ToString().ToUpper());
                    i++;
                }
                else if (!(((short)(sb[i]) >= 945) && ((short)(sb[i]) <= 969)))
                {
                    rs.Append(sb[i]);
                }
            }
            return rs.ToString();
        }

        public static int SumOfSquares(int max)
        {
            int sum = Int32.Parse(Math.Pow(Enumerable.Range(1, max).Sum(), 2).ToString());
            return sum;

        }


        public static DateTime Schedule(string appointmentDateDescription)
        {
            DateTime dtToReturn = DateTime.Parse("7/25/2019 13:45:00");
            Console.WriteLine(dtToReturn.TimeOfDay);
            return dtToReturn;
        }
        public static string SubstringBetween(this string str, string delimeter1, string delimeter2)
        {
            
            string del1 = delimeter1.Trim();
            string del2 = delimeter2.Trim();

            
            string trimmedString = str.Replace(" ", "");
            Console.WriteLine(trimmedString.Length);
            Console.WriteLine(trimmedString);
            Console.WriteLine(delimeter1 + " " + delimeter1.Trim().Length + " " + delimeter2 + " " + delimeter2.Trim().Length);
            Console.WriteLine(str.IndexOf(delimeter1) + " " + delimeter1.Trim().Length + " " + str.IndexOf(delimeter2) + " " + delimeter2.Trim().Length);
            Console.WriteLine(trimmedString);
            return trimmedString.Substring(trimmedString.IndexOf(del1) + del1.Length, trimmedString.IndexOf(del2) - del2.Length);
            //return "Asdf";
        }


        public static string[] Handshake(int commandValue)
        {
            string binary = Convert.ToString(commandValue, 2);
            char[] binaryArray = binary.ToArray();
            List<string> stringList = new List<string>();
            Console.WriteLine(binary);


            if (binaryArray.Length == 1 && binaryArray[0] == '1')
                stringList.Add("wink");

            if (binaryArray.Length == 2 && binaryArray[0] == '1')
                stringList.Add("double blink");
            if (binaryArray.Length == 2 && binaryArray[1] == '1')
                stringList.Add("wink");

            if (binaryArray.Length == 3 && binaryArray[0] == '1')
                stringList.Add("close your eyes");
            if (binaryArray.Length == 3 && binaryArray[1] == '1')
                stringList.Add("double blink");
            if (binaryArray.Length == 3 && binaryArray[2] == '1')
                stringList.Add("wink");

            if (binaryArray.Length == 4 && binaryArray[0] == '1')
                stringList.Add("jump");
            if (binaryArray.Length == 4 && binaryArray[1] == '1')
                stringList.Add("close your eyes");
            if (binaryArray.Length == 4 && binaryArray[2] == '1')
                stringList.Add("double blink");
            if (binaryArray.Length == 43 && binaryArray[3] == '1')
                stringList.Add("wink");

            if (binaryArray.Length == 5 && binaryArray[4] == '1')
                stringList.Reverse();

            return stringList.ToArray();
        }

        public static DateTime Add(DateTime moment)
        {
            DateTime timeToReturn = moment.AddSeconds(1000000000);
            return timeToReturn;
        }

        public static IEnumerable<IEnumerable<int>> CalculatePascalsTriangle(int rows)
        {
          
            int[][] jaggedArray = new int[rows][];
            //create arrays for each row
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new int[i+1];

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                   
                    if (j == 0)
                    {
                        jaggedArray[i][j] = 1;
                    }
                    if (i == 1 && j == 1)
                    {
                        jaggedArray[i][j] = 1;
                    }
                    
                    else if (i > 1 && j >= 1 && j < jaggedArray[i-1].Length)
                    {
                        jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                    }
                    else if (i > 1 && j >= 1)
                    {
                        jaggedArray[i][j] = 1;
                    }
                }
            }
            return jaggedArray;
        }

        public static string[] Recite(string[] subjects)
        {
            string prefix = "For the want of a ";
            string suffix = " was lost.";
            string connector = "the ";
            string lastLine = "And all for the want of a";

            List<string> song = new List<string>();
            if (subjects.Length > 1)
            {
                for (int i = 0; i <= subjects.Length - 1; i++)
                {
                    string line = $"{prefix} {subjects[i]} {connector} {subjects[i + 1]} {suffix}";
                    song.Add(line);
                }
                song.Add($"{lastLine} {subjects[subjects.Length - 1]}.");
            }
            return song.ToArray();
        }

        public static string[] FindAnagrams(string baseWord, string[] potentialMatches)
        {

            List<string> returnList = new List<string>();
            //string baseWord = _anagram.ToLower();

            for (int i = 0; i < potentialMatches.Length; i++)
            {
                string checkWord = potentialMatches[i].ToLower();
                bool isAnagram = true;

                if (baseWord == checkWord)
                    isAnagram = false;

                //find out if the letter appears the same number of times in each word
                if (checkWord.Length != baseWord.Length)
                    isAnagram = false;

                //iterate through each letter in the match wrod and see if the letter is in the anagram word.
                if (isAnagram)
                    for (int j = 0; j < checkWord.Length; j++)
                    {
                        //check the count of occurrences of each letter and make sure they're the same:
                        int checkWordLetterFreq = checkWord.Count(f => (f == checkWord.ElementAt(j)));
                        int baseWordLetterFreq = baseWord.Count(f => (f == checkWord.ElementAt(j)));
                        if (checkWordLetterFreq != baseWordLetterFreq)
                            isAnagram = false;

                        if (!baseWord.ToLower().Contains(checkWord.ToLower().ElementAt(j)))
                        {
                            isAnagram = false;
                        }
                    }
                if (isAnagram)
                    returnList.Add(potentialMatches[i]);
            }
            return returnList.ToArray();
        }

        public static int BinarySearch(int[] input, int value)
        {
            int keyPosition = -1;
            bool keepSearching = true;
            int[] currentArray = input;
            int currentArrayMid;
            int addr = 0;
            if (currentArray.Length == 0)
                keepSearching = false;
            while (keepSearching)
            {
                if (currentArray.Length % 2 == 0)
                {
                    currentArrayMid = currentArray.Length / 2 + 1;
                }
                else
                {
                    currentArrayMid = (currentArray.Length / 2);
                }
                if (currentArray[currentArrayMid] == value)
                {
                    keyPosition = currentArrayMid + addr;
                    keepSearching = false;
                }
                else if (currentArray.Length == 1 && currentArray[0] != value)
                {
                    keepSearching = false;
                    
                }
                else if (currentArray[currentArrayMid] > value)
                {
                    currentArray = currentArray.Take(currentArrayMid).ToArray();
                    keepSearching = true;
                }
                else if (currentArray[currentArrayMid] < value)
                {
                    currentArray = currentArray.Skip(currentArrayMid).Take(currentArray.Length - (currentArrayMid - 1)).ToArray();
                    addr += currentArrayMid;
                    keepSearching = true;
                }
            }
            return keyPosition;
        }

        public static int[,] GetSpiralMatrix(int size)
        {
            //int[,] array = new int[4,2]; four rows and two columns

            int[,] returnArray = new int[size, size];
            int intSize = size * size;
            int loopNum = 1;
            int keyValue = 1;
            int i = 0;
            int j = 0;
            while (keyValue <= intSize)
            {
                while(j < size - loopNum)
                {
                    returnArray[i, j] = keyValue;
                    keyValue++;
                    j++;
                }

                while(i < size - loopNum)
                {
                    returnArray[i, j] = keyValue;
                    keyValue++;
                    i++;
                }

                while (j > (loopNum - 1))
                {
                    returnArray[i, j] = keyValue;
                    keyValue++;
                    j--;
                }

                while (i > (loopNum - 1))
                {
                    returnArray[i, j] = keyValue;
                    keyValue++;
                    i--;
                }
                j++;
                i++;
                loopNum++;
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Console.Write(returnArray[x, y] + ",");
                }
                Console.WriteLine(); ;
            }

            return returnArray;

        }

        public static int GetOccCount(string toSearch, Stream stream)
        {

            string content = string.Empty;

            byte[] temp = new byte[8];
            int len = 0;
            while((len = stream.Read(temp, 0, temp.Length)) > 0)
            {
                String s = Encoding.UTF8.GetString(temp);
                Console.WriteLine(s);
            }

            if (stream.ToString().Contains(toSearch))
                return 1;
            else return 2;
        }
    }

    public class Robot
    {
       // private static string _name;
        public string Name { get; set; } = GetRandomName();
        private static List<string> _robotNames = new List<string>();

        public static string GetRandomName()
        {
            Random rand = new Random();
            string n = "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            bool uniqueName = true;

            while (uniqueName)
            {
                for (int i = 0; i < 2; i++)
                {
                    n += chars[rand.Next(chars.Length)];
                }

                for (int j = 0; j < 3; j++)
                {
                    n += rand.Next(9);
                }

                if (!_robotNames.Contains(n))
                {
                    _robotNames.Add(n);
                    uniqueName = false;
                }
            }
            return n;
        }

public void Reset()
        {
            Name = GetRandomName();
        }
    }

   
}

