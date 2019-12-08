using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace BombBros
{
    public class Bomb
    {
        const string BombImagePath = "../Bomb.png";
        public static Image BombImage { get; set; }
        public const uint BombWidth = 16;
        public const uint BombHeight = 16;
        public const uint Xscale = 3;
        public const uint Yscale = 3;
        public float BombPlaced { get; set; }
        public float BombTimer { get; set; }
        public Vector2f Position { get; set; }
        public int BlastRadius { get; set; }
        public bool BombExploded { get; set; }


        public Bomb(Vector2f position, int blastRadius, float bombPlaced)
        {
            BombExploded = false;
            Position = position;
            BlastRadius = blastRadius;
            BombTimer = 3.0f; // default bomb timer in seconds
            BombPlaced = bombPlaced;
        }
        public static void LoadBomb()
        {
            BombImage = new Image(BombImagePath);
        }
        public void DisplayBomb(Game game)
        {
            if (BombImage != null)
            {
                Sprite sprite = new Sprite
                {
                    Position = Position,
                    Scale = new Vector2f(Xscale, Yscale),
                    Origin = new Vector2f(BombWidth / 2, BombHeight / 2),
                    Texture = new Texture(BombImage)
                };
                game.Window.Draw(sprite);
            }
        }
        public void ExplodeBomb()
        {
            BombExploded = true;
        }
        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalTimeElapsed - BombPlaced >= BombTimer)
            {
                ExplodeBomb();
            }
        }

    }
}
