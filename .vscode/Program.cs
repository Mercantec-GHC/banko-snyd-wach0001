using System; 
using System.Collections.Generic;
using System.Linq; 
using System.Threading; 

class BingoCard
{
    public string UniqueID { get; }
    public List<List<string>> Rows { get; }

    public BingoCard(string uniqueID, List<List<string>> rows)
    {
        UniqueID = uniqueID;
        Rows = rows;
    }
}


    class Program 
    {

        static string GetUserInput(string message) 
        {
            Console.Write(message);
            return Console.ReadLine();
        }


        static void Main() 
        {
            string plade1UniqueID = GetUserInput("Hvad er dit navn?");
            BingoCard plade1 = new BingoCard(plade1UniqueID, new List<List<string>>
            {
                new List<string> {"5", "34", "42", "53", "73"},
                new List<string> {"6", "12", "37", "44", "75"},
                new List<string> {"7", "27", "45", "60", "65"}
                
            });
        string plade2UniqueID = ("");
        BingoCard plade2 = new BingoCard(plade2UniqueID, new List<List<string>>
        {
     new List<string> {"14", "35", "45", "66", "87"},
    new List<string> {"17", "36", "46", "67", "88"},
     new List<string> {"30","37","59","79","89"}
        });
  string plade3UniqueID = ("");
        BingoCard plade3 = new BingoCard(plade3UniqueID, new List<List<string>>
        {
                new List<string> {"8","28", "48", "68", "77"},
            new List<string> {"19", "29", "49","78", "89"},
            new List<string> {"10", "40", "50", "80", "90"}
        });
                
                
                
                
        
           
 
       
             
             
             

                
                 
        

            string trukneTal = "0";
            bool bingoRække1 = false; 
            bool bingoRække2 = false; 
            bool fuldPlade = false; 
            int fullLinesCount = 0;

            while (!fuldPlade) 
            {

                DisplayPlader(plade1, plade2, plade3);
                Console.WriteLine();
                Console.Write("Tallet der blev trukket: ");
                trukneTal = Console.ReadLine();

                if (!IsValidNumber(trukneTal))
                {
                    Console.WriteLine("ugyldig input");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                UpdatePlader(plade1, plade2, plade3, trukneTal);
                CheckForBingo(plade1, plade2, plade3, ref fullLinesCount, ref fuldPlade, ref bingoRække1, ref bingoRække2);
                Thread.Sleep(1000);
                Console.Clear();

             }

        }
        static bool IsValidNumber(string tal) 
        {
            int parsedNumber;
            return int.TryParse(tal, out parsedNumber) && parsedNumber >= 1 && parsedNumber <= 90;
        }

        static void UpdatePlader(BingoCard plade1, BingoCard plade2, BingoCard plade3, string trukneTal) 
        {
            UpdateRække(plade1.Rows);
            UpdateRække(plade2.Rows);
            UpdateRække(plade3.Rows);



            void UpdateRække(List<List<string>> plade) 
            {
                foreach (var række in plade) 
                {
                    if (række.Contains(trukneTal)) 
                    {
                        int index = række.IndexOf(trukneTal);
                        række[index] = "X";
                        Console.WriteLine(trukneTal + " er paa Plade");
                    }
                }
            }
        }
        static void CheckForBingo(BingoCard plade1, BingoCard plade2, BingoCard plade3, ref int fullLinesCount, ref bool fuldPlade, ref bool bingoRække1, ref bool bingoRække2) 
        {
            int fullLinesInPlade1 = CountFullLines(plade1.Rows);
            int fullLinesInPlade2 = CountFullLines(plade2.Rows);
            int fullLinesInPlade3 = CountFullLines(plade3.Rows);
                fullLinesCount = fullLinesInPlade1 + fullLinesInPlade2 + fullLinesInPlade3;

                if (fullLinesCount == 1 && !bingoRække1) 
                {
                    Console.WriteLine("Bingo! Du har en raekke!");
                    Console.WriteLine("Tryk paa enter for at forsaette");
                    Console.ReadLine();
                    Console.Clear();
                    bingoRække1 = true;
                }
                else if (fullLinesCount == 2 && !bingoRække2)
                {
                    Console.WriteLine("Tillykke! Du har to raekker!");
                    Console.WriteLine("Tryk på enter for at forsaette");
                    Console.ReadLine();
                    Console.Clear();
                    bingoRække2 = true;
                }

                else if (fullLinesCount == 3) 
                {
                    Console.WriteLine("BANKO du har en fuld plade!");
                    Console.WriteLine("Tryk på enter for at afslutte");
                    Console.ReadLine();
                    Console.Clear();
                    fuldPlade = true;
                }


        }

        static int CountFullLines(List<List<string>> plader)
        {
            int count = 0;
            foreach (var plade in plader) 
            {
                if (plade.All(x => x == "X"))
                {
                    count++;
                }
            }
                return count;
         
            }
            static void DisplayPlader(BingoCard plade1, BingoCard plade2, BingoCard plade3) 
            {
                DisplayPlade(plade1.UniqueID, plade1.Rows);
                DisplayPlade(plade2.UniqueID, plade2.Rows);
                DisplayPlade(plade3.UniqueID, plade3.Rows);

                void DisplayPlade(string pladeNavn, List<List<string>> plader) {
                    Console.WriteLine(pladeNavn);
                    foreach (var række in plader) 
                    {
                        foreach (var nummer in række) 
                        {
                            Console.Write(nummer + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        

    }


