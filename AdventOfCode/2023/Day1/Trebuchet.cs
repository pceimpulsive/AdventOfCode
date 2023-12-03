using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCode._2023.DayOneTrebuchet
{
    //struct Trebuchet
    //{
    //    public int Answer;
    //}
    public class DayOne
    {

        public void TrebuchetAnswers()
        {
            var input = ReadTextFile("2023\\Assets\\Trebuchet.txt");
            //var inputTest = ReadTextFile("2023\\Assets\\TrebuchetTestInput.txt");
            int partOneAnswer = PartOne(input);
            Console.WriteLine("Part One Answer is: " + partOneAnswer);
            int partTwoAnswer = PartTwo(input);
            Console.WriteLine("Part Two Answer is: " + partTwoAnswer);
        }

        private int PartOne(List<string> trebuchetInput)
        {
            int answer = 0;
            List<int> answerNumbers = new List<int>();

            foreach (var row in trebuchetInput)
            {
                var regexMatch = Regex.Matches(row, "\\d");
                string firstNum = regexMatch.First().ToString();
                string lastNum = regexMatch.Last().ToString();
                //int result = Convert.ToInt16(firstNum + lastNum);
                int result = Convert.ToInt16(StringToNum(firstNum).ToString() + StringToNum(lastNum).ToString());
                answerNumbers.Add(result);
            }

            foreach (int answerNumber in answerNumbers)
            {
                answer += answerNumber;
            }

            return answer;
        }

        private int PartTwo(List<string> trebuchetInput)
        {
            int answer = 0;
            List<int> answerNumbers = new List<int>();

            foreach (var row in trebuchetInput)
            {
                var firstRegexMatch = Regex.Match(row, "\\d|one|two|three|four|five|six|seven|eight|nine");
                var lastRegexMatch = Regex.Match(row, "\\d|one|two|three|four|five|six|seven|eight|nine",RegexOptions.RightToLeft);
                int result = Convert.ToInt16(StringToNum(firstRegexMatch.Value.ToString()).ToString() + StringToNum(lastRegexMatch.Value.ToString()).ToString());
                //string firstNum = firstRegexMatch.First().ToString();
                //string lastNum = lastRegexMatch.Last().ToString();

                //int result = Convert.ToInt16(StringToNum(firstNum).ToString() + StringToNum(lastNum).ToString());
                answerNumbers.Add(result);
            }

            foreach (int answerNumber in answerNumbers)
            {
                answer += answerNumber;
            }

            return answer;
        }

        private List<string> ReadTextFile(string fileInput)
        {
            var trebuchetInput = new List<string>();

            try
            {
                trebuchetInput = File.ReadAllLines(fileInput).ToList();

            }
            catch(Exception e) 
            { 
                Console.WriteLine("Exception: " + e.Message);
            }

            return trebuchetInput;
        }

        private int StringToNum(string input)
        {
            switch (input)
            {
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
                default:
                    //Regex.IsMatch(input,"\\d")                    
                    return int.Parse(input);
            }
        }
    }
}
