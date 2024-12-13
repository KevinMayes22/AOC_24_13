using System.Net.Mail;

namespace AdventOfCode13;

class Program
{
    public class Vector
    {
        public int x
        {
            get;
            set;
        }

        public long y { get; set; }
    }

    public class Game
    {
        public Vector ButtonA { get; set; }
        public Vector ButtonB { get; set; }
        public Vector Prize { get; set; }
    }

    public class Attempt
    {
        public long BtnACount { get; set; }
        public long BtnBCount { get; set; }
        public long TokenCount { get; set; }
    }
    
    public static List<Game> gameList = [];

    static void Main(string[] args)
    {
        Console.Clear();
        // Specify the file path
        string filePath = "input.txt";

        // Read all lines from the file
        string lines = File.ReadAllText(filePath);
        string[] Machines = lines.Split("\r\n\r\n");

        foreach (var MachineInput in Machines)
        {
            string[] MachineLine = MachineInput.Split("\r\n");

            Vector BA = new Vector();
            Vector BB = new Vector();
            Vector PZ = new Vector();

            
            foreach (var gameInput in MachineLine)
            {

                if (gameInput.Contains("Button A:"))
                {
                    BA.x = Convert.ToInt64((gameInput.Substring(gameInput.IndexOf("X+") + 2,gameInput.IndexOf(",") - gameInput.IndexOf("X+") - 2)));
                    BA.y = Convert.ToInt64((gameInput.Substring(gameInput.IndexOf("Y+") + 2)));
                    Console.WriteLine($" Ax : {BA.x}  Ay : {BA.y}");
                }
                if (gameInput.Contains("Button B:"))
                {
                    BB.x = Convert.ToInt64((gameInput.Substring(gameInput.IndexOf("X+") + 2,gameInput.IndexOf(",") - gameInput.IndexOf("X+") - 2)));
                    BB.y = Convert.ToInt64((gameInput.Substring(gameInput.IndexOf("Y+") + 2)));
                    Console.WriteLine($"Bx : {BB.x}  Ay : {BB.y}");
                }         
                if (gameInput.Contains("Prize:"))
                {
                    PZ.x = Convert.ToInt64((gameInput.Substring(gameInput.IndexOf("X=") + 2,gameInput.IndexOf(",") - gameInput.IndexOf("X=") - 2)));
                    PZ.x += 10000000000000;
                    PZ.y = Convert.ToInt64((gameInput.Substring(gameInput.IndexOf("Y=") + 2)));
                    PZ.y += 10000000000000;
                    Console.WriteLine($"Px : {PZ.x}  Py : {PZ.y}");
                }                    
            }

            gameList.Add(new Game()
            {
                ButtonA = BA,
                ButtonB = BB,
                Prize = PZ
            });
        }


        //List<Attempt> attemptList = new List<Attempt>();
        
        
        
        
        long TotalTokenSpent = 0;
        
        foreach (var games in gameList)
        {
            // find max of btn a and btn b
            var btnALargest = Math.Max(games.ButtonA.x, games.ButtonA.y);
            var btnBLargest = Math.Max(games.ButtonB.x, games.ButtonB.y);
            
            long btnAMaxCount = 0;
            long btnBMaxCount = 0;
            
            if (btnALargest == games.ButtonA.x)
            {
                btnAMaxCount = games.Prize.x / games.ButtonA.x;
            }
            else
            {
                btnAMaxCount = games.Prize.y / games.ButtonA.y;
            }
            
            if (btnBLargest == games.ButtonB.x)
            {
                btnBMaxCount = games.Prize.x / games.ButtonB.x;
            }
            else
            {
                btnBMaxCount = games.Prize.y / games.ButtonB.y;
            }
            
            Console.WriteLine($"Btn A Max Count: {btnAMaxCount} and Btn B Max Count: {btnBMaxCount}");
            
            Attempt bestAttempt = new Attempt()
            {
                BtnACount = -1,
                BtnBCount = -1,
                TokenCount = -1
            };
            for (long aindex = 0; aindex <= btnAMaxCount; aindex++)
            {
                Console.WriteLine(aindex);
                for (long bindex = 0; bindex <= btnBMaxCount; bindex++)
                {
                    Console.WriteLine(bindex);

                    long TotalPrizeX = (aindex * games.ButtonA.x) + (bindex * games.ButtonB.x);
                    long TotalPrizeY = (aindex * games.ButtonA.y) + (bindex * games.ButtonB.y);
                    if ((games.Prize.x == TotalPrizeX) && (games.Prize.y == TotalPrizeY))
                    {
                        
                        long Tokens = (aindex * 3) + bindex;
                        if ((bestAttempt.TokenCount == -1 ) || (bestAttempt.TokenCount > Tokens ))
                        {
                            bestAttempt.BtnACount = aindex;
                            bestAttempt.BtnBCount = bindex;
                            bestAttempt.TokenCount = Tokens;
                        }
                    }
                }
            }
            if (bestAttempt.TokenCount == -1) { continue; }
            TotalTokenSpent += bestAttempt.TokenCount;
        }
        Console.WriteLine($"Total Tokens Spend : {TotalTokenSpent}");
        ;
        // We have a list of Games with 

        // Button A: X+94, Y+34
        // Button B: X+22, Y+67
        // Prize: X=8400, Y=5400

    }

}
