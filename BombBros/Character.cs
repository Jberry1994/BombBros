using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace BombBros
{
    public class Character
    {
        //public int Lives { get; set; } // Maybe lives ?
        public int BlastRadius { get; set; } // squares
        public float BombCooldown { get; set; } // seconds
        public float Speed { get; set; }
        public bool CanDropBomb { get; set; }
        public bool MovingUp { get; set; }
        public bool MovingDown { get; set; }
        public bool MovingLeft { get; set; }
        public bool MovingRight { get; set; }

        public Vector2f Position { get; set; }
        public bool Alive { get; set; }

        public string CharacterImagePath { get; set; }
        public Image CharacterImage { get; set; }
        public const uint CharacterWidth = 16;
        public const uint CharacterHeight = 16;
        public const uint Xscale = 3;
        public const uint Yscale = 3;
        public float TimeOfLastBomb { get; set; }
        public Character(string characterImagePath, Vector2f position)
        {
            //Lives = 3;
            CanDropBomb = true;
            BlastRadius = 1;
            BombCooldown = 3;
            Speed = 1.0f;
            CharacterImagePath = characterImagePath;
            Position = position;
        }

        public Bomb DropBomb(float totalTimeElapsed)
        {
            TimeOfLastBomb = totalTimeElapsed;
            CanDropBomb = false;
            return new Bomb(Position, BlastRadius, totalTimeElapsed);

        }
        public void LoadCharacter()
        {
            CharacterImage = new Image(CharacterImagePath);
        }

        public void DisplayCharacter(Game game)
        {
            if (CharacterImage != null)
            {
                Sprite sprite = new Sprite
                {
                    Position = Position,
                    Scale = MovingLeft ? new Vector2f(-Xscale, Yscale) : new Vector2f(Xscale, Yscale),
                    Texture = new Texture(CharacterImage),
                    Origin = new Vector2f(CharacterWidth / 2, CharacterHeight / 2)

                };
                
                game.Window.Draw(sprite);
            }
        }

        public void KeyDownControls(KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.W)
            {
                MovingUp = false;
            }
            if (e.Code == Keyboard.Key.A)
            {
                MovingLeft = false;
            }
            if (e.Code == Keyboard.Key.S)
            {
                MovingDown = false;
            }
            if (e.Code == Keyboard.Key.D)
            {
                MovingRight = false;
            }

        }
        public void KeyUpControls(KeyEventArgs e)
        {

            if (e.Code == Keyboard.Key.W)
            {
                MovingUp = true;
            }
            if (e.Code == Keyboard.Key.A)
            {
                MovingLeft = true;
            }
            if (e.Code == Keyboard.Key.S)
            {
                MovingDown = true;
            }
            if (e.Code == Keyboard.Key.D)
            {
                MovingRight = true;
            }

        }

        public void MoveUp()
        {
            Position = new Vector2f(Position.X, Position.Y - 1 * Speed);
        }
        public void MoveLeft()
        {
            Position = new Vector2f(Position.X - 1 * Speed, Position.Y);

        }
        public void MoveDown()
        {
            Position = new Vector2f(Position.X, Position.Y + 1 * Speed);

        }
        public void MoveRight()
        {
            Position = new Vector2f(Position.X + 1 * Speed, Position.Y);

        }
        public void Update(GameTime gameTime)
        {

            if (gameTime.TotalTimeElapsed - TimeOfLastBomb >= BombCooldown)
            {
                CanDropBomb = true;
            }
            if (MovingUp)
            {
                MoveUp();
            }
            if (MovingDown)
            {
                MoveDown();
            }
            if (MovingLeft)
            {
                MoveLeft();
            }
            if (MovingRight)
            {
                MoveRight();
            }
        }
    }
}
