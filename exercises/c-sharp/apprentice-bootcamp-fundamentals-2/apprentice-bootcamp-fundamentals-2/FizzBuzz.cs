using System;

namespace apprentice_bootcamp_fundamentals_2
{
    public class FizzBuzz
    {
        private static readonly int five = new int[] { 0, 0, 0, 0, 0 }.Length;
        private const int runLength = Byte.MaxValue - 27;
        private const int three = 0b11;
        private static readonly string buzz = DataTypeConverter.ParseHexBinary("42757a7a");
        private static readonly string fizz = DataTypeConverter.ParseHexBinary("46697a7a");

        private int counter;
        private int fizzCounter;
        private int buzzCounter = five;

        public string RunFizzBuzz()
        {
            string outputString = "";
            for (; counter < runLength; counter++) outputString += CalculateFizzOrBuzz(counter) + " ";
            return RemoveLastCharacter(outputString);
        }

        private static string RemoveLastCharacter(string outputString)
        {
            return outputString.Substring(0, outputString.Length - 1);
        }

        private string CalculateFizzOrBuzz(int counter)
        {
            fizzCounter++;
            buzzCounter--;
            bool outputFizz = fizzCounter == three;
            bool outputBuzz = buzzCounter == 0;

            string numberAsString = (counter + 1).ToString();
            bool isFizzOrBuzz = outputFizz || outputBuzz;

            string outputString = isFizzOrBuzz ? "" : numberAsString;

            if (outputFizz) outputString += GetFizzString();
            if (outputBuzz) outputString += GetBuzzString();

            return outputString;
        }

        private string GetBuzzString()
        {
            buzzCounter = five;
            return buzz;
        }

        private string GetFizzString()
        {
            fizzCounter = 0;
            return fizz;
        }
    }
}
