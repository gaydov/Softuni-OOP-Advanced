using CardGame.Models;

namespace CardGame
{
    public class Launcher
    {
        public static void Main()
        {
            Game game = new Game();
            game.StartGame();
            game.PrintWinner();
        }
    }
}
