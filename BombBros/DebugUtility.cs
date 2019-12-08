using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using BombBros;

namespace BombBros
{
    static class DebugUtility
    {
        const string ConsoleFontPath = "../Roboto-Regular.ttf";//C:\Users\Student\source\repos\BombBros\BombBros\bin\Debug\Roboto-Regular.ttf
        public static Font ConsoleFont { get; set; }
        public const int FontSize = 16;
        public static void LoadFont()
        {
            ConsoleFont = new Font(ConsoleFontPath);
        }
        public static void DisplayDebugInfo(Game game, Character character, Color fontColor)
        {
            if (ConsoleFont != null)
            {
                string totalTimeElapsed = game.GameTime.TotalTimeElapsed.ToString("n3");
                string deltaTime = game.GameTime.DeltaTime.ToString("n5");
                string currentFPS = (1.0 / game.GameTime.DeltaTime).ToString("n2");
                string CurrentPos = ($"X: {character.Position.X} Y: {character.Position.Y}");
                //string BombTimer = ($"CD: {character.TimeOfLastBomb - character.BombCooldown} ");
                Text textA = new Text(totalTimeElapsed, ConsoleFont, FontSize)
                {
                    Position = new Vector2f(4, 8),
                    FillColor = fontColor
                };

                Text textB = new Text(deltaTime, ConsoleFont, FontSize)
                {
                    Position = new Vector2f(4, 28),
                    FillColor = fontColor
                };
                Text textC = new Text(currentFPS, ConsoleFont, FontSize)
                {
                    Position = new Vector2f(4, 48),
                    FillColor = fontColor
                };
                Text textD = new Text(CurrentPos, ConsoleFont, FontSize)
                {
                    Position = new Vector2f(4, 68),
                    FillColor = fontColor
                };
                //Text textE = new Text(BombTimer, ConsoleFont, FontSize)
                //{
                //    Position = new Vector2f(4, 88),
                //    FillColor = fontColor
                //};
                game.Window.Draw(textA);
                game.Window.Draw(textB);
                game.Window.Draw(textC);
                game.Window.Draw(textD);
                //game.Window.Draw(textE);
            }

        }
    }
}
