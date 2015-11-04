using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KataBank
{
   
    public class CheckSum
    {
        
        public int computeCheckSum(string accountNumber)
        {
            int checkSumResult = 0;
            int charPlace = 9;
            foreach (char car in accountNumber)
            {
                checkSumResult += (int)char.GetNumericValue(car) * charPlace;
                charPlace -- ;
            }
            return checkSumResult  % 11 ;
        }
    }
    
    public class ParseString
    {
        public static int nbLineFile = 40;
        public static int nbColFile = 27; 

        public int getAccountNumberFromString(string account)
        {
            return Int32.Parse(account);
        }

        public string getAccountNumberFromFile(string fileName)
        {
            char[,] digits = FillCharArray(fileName);
            string accountNumber = patternReco(digits);
            return accountNumber;

        }

        public void writeAccountNumberFromFile(string inputFileName, string outputFileName)
        {
            char[,] digits = FillCharArray(inputFileName);
            patternReco(digits, outputFileName);
        }

        char[,] FillCharArray(string fileName)
        {
            nbLineFile = File.ReadLines(fileName).Count();
            char[,] digits = new char[nbLineFile,nbColFile]; 
            try
            {
               string[] lines = File.ReadAllLines(fileName);
                // Display the file contents by using a foreach loop.
                System.Console.WriteLine("LINES of the file = ");
                int i = 0;
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    Console.WriteLine(line);
                    int j = 0;
                    foreach (char car in line)
                    {
                        digits[i, j] = car;
                        j++;
                    }
                    i++;
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return digits;
        }

        string patternReco(char[,] digits)
        {
            string foundNumber = "";
            for (int i = 0; i < 27; i = i + 3)
            { 
 //               foundNumber += detectANumber( digits, i) ;
            }
            return foundNumber;
        }

        void patternReco(char[,] digits, string outputFileName)
        {
            using (StreamWriter outputFile = new StreamWriter(outputFileName)) { 
                for( int i = 0; i < nbLineFile ; i = i + 4) {
                    string foundNumber = "";
                    bool wrongChar = false;
                    for (int j = 0; j < nbColFile; j = j + 3)
                    {
                        string singleNumber =  detectANumber(digits, i, j);
                        if (singleNumber.Equals("?") )
                        {
                            wrongChar = true;
                        }
                        foundNumber += singleNumber;
                    }
                    if (wrongChar)
                    {
                        foundNumber += " ILL";
                    }
                    else
                    {
                        CheckSum checkSumForAccount = new CheckSum();
                        if (checkSumForAccount.computeCheckSum(foundNumber) != 0)
                        {
                            foundNumber += " ERR";
                        }
                    }
                    outputFile.WriteLine(foundNumber);
                }
            }
        }
        
        string detectANumber(char[,] digits, int i, int j)
        {
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1+j].Equals('_') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals('|') && digits[1+i, 1 + j].Equals(' ') && digits[1+i, 2 + j].Equals('|')
                && digits[2+i, 0 + j].Equals('|') && digits[2+i, 1 + j].Equals('_') && digits[2+i, 2+j].Equals('|')
            )
            {
                return "0";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals(' ') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals(' ') && digits[1+i, 1 + j].Equals('|') && digits[1+i, 2 + j].Equals(' ')
                && digits[2+i, 0 + j].Equals(' ') && digits[2+i, 1 + j].Equals('|') && digits[2+i, 2 + j].Equals(' ')
            )
            {
                return "1";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals('_') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals(' ') && digits[1+i, 1 + j].Equals('_') && digits[1+i, 2 + j].Equals('|')
                && digits[2+i, 0 + j].Equals('|') && digits[2+i, 1 + j].Equals('_') && digits[2+i, 2 + j].Equals(' ')
            )
            {
                return "2";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals('_') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals(' ') && digits[1+i, 1 + j].Equals('_') && digits[1+i, 2 + j].Equals('|')
                && digits[2+i, 0 + j].Equals(' ') && digits[2+i, 1 + j].Equals('_') && digits[2+i, 2 + j].Equals('|')
            )
            {
                return "3";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals(' ') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals('|') && digits[1+i, 1 + j].Equals('_') && digits[1+i, 2 + j].Equals('|')
                && digits[2+i, 0 + j].Equals(' ') && digits[2+i, 1 + j].Equals(' ') && digits[2+i, 2 + j].Equals('|')
            )
            {
                return "4";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals('_') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals('|') && digits[1+i, 1 + j].Equals('_') && digits[1+i, 2 + j].Equals(' ')
                && digits[2+i, 0 + j].Equals(' ') && digits[2+i, 1 + j].Equals('_') && digits[2+i, 2 + j].Equals('|')
            )
            {
                return "5";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals('_') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals('|') && digits[1+i, 1 + j].Equals('_') && digits[1+i, 2 + j].Equals(' ')
                && digits[2+i, 0 + j].Equals('|') && digits[2+i, 1 + j].Equals('_') && digits[2+i, 2 + j].Equals('|')
            )
            {
                return "6";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals('_') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals(' ') && digits[1+i, 1 + j].Equals(' ') && digits[1+i, 2 + j].Equals('|')
                && digits[2+i, 0 + j].Equals(' ') && digits[2+i, 1 + j].Equals(' ') && digits[2+i, 2 + j].Equals('|')
            )
            {
                return "7";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals('_') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals('|') && digits[1+i, 1 + j].Equals('_') && digits[1+i, 2 + j].Equals('|')
                && digits[2+i, 0 + j].Equals('|') && digits[2+i, 1 + j].Equals('_') && digits[2+i, 2 + j].Equals('|')
            )
            {
                return "8";
            }
            if (digits[0+i, 0 + j].Equals(' ') && digits[0+i, 1 + j].Equals('_') && digits[0+i, 2 + j].Equals(' ')
                && digits[1+i, 0 + j].Equals('|') && digits[1+i, 1 + j].Equals('_') && digits[1+i, 2 + j].Equals('|')
                && digits[2+i, 0 + j].Equals(' ') && digits[2+i, 1 + j].Equals('_') && digits[2+i, 2 + j].Equals('|')
            )
            {
                return "9";
            }
            return "?";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string InputfileName = @"C:\Users\Olivier\Documents\Visual Studio 2013\Projects\ConsoleApplication1\TestFile_Complete.txt";
            string OutputFileName = @"C:\Users\Olivier\Documents\Visual Studio 2013\Projects\ConsoleApplication1\TranscoTestFileComplete.txt";
            ParseString parser = new ParseString();
            parser.writeAccountNumberFromFile(InputfileName, OutputFileName);
            //Console.WriteLine(accountString);
            //Console.ReadKey();
        }
    }
}

