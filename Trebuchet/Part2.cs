
//---Part Two-- -
//Your calculation isn't quite right. It looks like some of the digits are
//actually spelled out with letters: one, two, three, four, five, six, seven,
//eight, and nine also count as valid "digits".

//Equipped with this new information, you now need to find the real first and last digit on each line. For example:

//two1nine
//eightwothree
//abcone2threexyz
//xtwone3four
//4nineeightseven2
//zoneight234
//7pqrstsixteen
//In this example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281.

//What is the sum of all of the calibration values?

//Your puzzle answer was 53268.

using System.Text.RegularExpressions;

namespace Trebuchet
{
    public static class Part2
    {
        enum Numbers
        {
            zero, one, two, three, four, five, six, seven, eight, nine, ten
        }

        public static void DayOnePartTwo()
        {
            string path = @"C:\Users\jeffp\source\repos\AdventOfCode-Trebuchet\Trebuchet\CalibrationValues.txt";
            string pattern = @"\d"; 
            string[] fileText;
            int calibrationTotal = 0;

            fileText = File.ReadAllLines(path);

            foreach(string line in fileText)
            {
                Dictionary<int, int> foundNumber = new Dictionary<int, int>();

                /* check each line for the enum values, there's a possibility of them
                 * occurring more than once. Using the while loop for that. Originally
                 * used string.contains and it only returns the first occurrence.
                 */
                foreach (Numbers number in Enum.GetValues(typeof(Numbers)))
                {
                    int index = -1;
                    while ((index = line.IndexOf(number.ToString(), index + 1)) != -1)
                    {
                        foundNumber.Add(index, (int)number);
                    }
                }

                /* check each line for an actual digit using the regex */
                for (int i = 0; i < line.Length; i++)
                {
                    Match match = Regex.Match(line[i].ToString(), pattern);

                    if (match.Success)
                    {
                        string numberString = match.Value;

                        if (int.TryParse(numberString, out int number))
                        {
                            foundNumber.Add(i, number);
                        }
                        else
                        {
                            Console.WriteLine("Failed to parse the extracted number");
                        }
                    }
                }
               
                /* minKey holds the first occurrence of a number(either spelled out(eight) or
                 * digit.
                 * maxKey holds the last occurrence
                 */
                int minKey = foundNumber.Keys.Min();
                int maxKey = foundNumber.Keys.Max();

                /* combine(don't add) the first and last digit together. 8 9 should equal 89. 
                 * eight 9 should equal 89. */
                string calibrationCombinedNumber = foundNumber[minKey].ToString() + foundNumber[maxKey].ToString();
                int.TryParse(calibrationCombinedNumber, out int calibrationNumber);

                /* keep a running total */
                calibrationTotal += calibrationNumber;

                //Console.WriteLine($"minKey value: {foundNumber[minKey]}");
                //Console.WriteLine($"maxKey value: {foundNumber[maxKey]}");
                //Console.WriteLine($"line: {line}");
                //Console.WriteLine($"calibrationNumber: {calibrationNumber}");
                //Console.WriteLine($"calibrationTotal: {calibrationTotal}");
                //Console.WriteLine("Finished with string, moving onto next string.\n");
            }

            Console.WriteLine($"Part 2 Calibration Total: {calibrationTotal}");
        }
    }
}
