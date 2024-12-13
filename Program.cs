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

        public int y
        {
            get;
            set;
        }
    }

    public class Game
    {
        public Vector ButtonA { get; set; }
        public Vector ButtonB { get; set; }
        public Vector Prize { get; set; }
    }
    
    public static List<Game> game = [];
    
    static void Main(string[] args)
    {
        Console.Clear();
        // Specify the file path
        string filePath = "input.txt";

        // Read all lines from the file
        string lines = File.ReadAllText(filePath);
        string[] gameLines = lines.Split("\n\r");
        foreach (var gameInput in gameLines)
        {
            foreach (var line in gameInput)
            {
                
            }
            game.Add(new Game() { 
                ButtonA = new Vector(),
                ButtonB = new Vector(),
                Prize = new Vector()
            });
        }

        
    }
}
