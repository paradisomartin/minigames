namespace MiniGames.Games.Tango;

public class Game
{
    Board board = new Board();
    Rules rules = new Rules();
    public void Start()
    {
        Console.WriteLine("Hello, Welcome to MiniTango!");
        Console.WriteLine("Please, tell us your name:");
        string name = Console.ReadLine() ?? "";
        Console.WriteLine($"Okay {name}, Game Start!!!");
        
        Console.WriteLine("Step 1 - Setup Board");
        board.InitBoard();
        board.ShowBoard();
        Console.WriteLine("Step 2 - User plays");
        rules.ValidatePlay();
        board.ShowPlay();
        
        Console.WriteLine("Step 4 - Repeat -> End");
    }
} 