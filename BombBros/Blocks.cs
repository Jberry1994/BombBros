using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace BombBros
{
    public class Blocks
    {
        public bool Destroyable { get; set; }
        public Vector2i Size { get; set; }
        public Vector2f Position { get; set; }
        public string BlockImagePath { get; set; }
        public Image BlockImage { get; set; }
        public bool Destroyed { get; set; }
        public const uint BlockWidth = 16;
        public const uint BlockHeight = 16;
        public const uint Xscale = 4;
        public const uint Yscale = 4;

        public Blocks(string blockImagePath, Vector2f position, bool destroyable)
        {
            Position = position;
            BlockImagePath = blockImagePath;
            Destroyable = destroyable;
        }
        public void LoadBlock()
        {
            BlockImage = new Image(BlockImagePath);
        }

        public void DisplayBlock(Game game)
        {
            if (BlockImage != null)
            {
                Sprite sprite = new Sprite
                {
                    Position = Position,
                    Scale = new Vector2f(Xscale, Yscale),
                    Texture = new Texture(BlockImage)
                };
                game.Window.Draw(sprite);
            }
        }

        public void DestroyBlock()
        {
            if (Destroyable)
            {
                Destroyed = true;
            }
        }
        
        public void Update()
        {

        }

    }
}
