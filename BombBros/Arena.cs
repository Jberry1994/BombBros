using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace BombBros
{
    public class Arena
    {
       //public Vector2i ArenaSize { get; set; }
       //public double ArenaTimer { get; set; }
        public List<Blocks> Blocks { get; set; }

        public Arena()
        {
            Blocks = new List<Blocks>();
            Blocks.Add(new Blocks("../DestroyableRock.jpg", new Vector2f(75.0f, 75.0f), true));
            Blocks.Add(new Blocks("../DestroyableRock.jpg", new Vector2f(175.0f, 75.0f), true));
            Blocks.Add(new Blocks("../DestroyableRock.jpg", new Vector2f(275.0f, 75.0f), true));
            Blocks.Add(new Blocks("../DestroyableRock.jpg", new Vector2f(375.0f, 75.0f), true));
            Blocks.Add(new Blocks("../Rock.jpg", new Vector2f(175.0f, 175.0f), false));
            Blocks.Add(new Blocks("../Rock.jpg", new Vector2f(175.0f, 275.0f), false));
            Blocks.Add(new Blocks("../Rock.jpg", new Vector2f(175.0f, 375.0f), false));
            Blocks.Add(new Blocks("../Rock.jpg", new Vector2f(175.0f, 475.0f), false));

        }
        public void DisplayArena(Game game)
        {
            foreach (Blocks block in Blocks)
            {
                block.DisplayBlock(game);
            }
        }
        public void Update() 
        {
            foreach (Blocks block in Blocks)
            {
                block.Update();
            }
        }
        public void LoadArena()
        {
            foreach (Blocks block in Blocks)
            {
                block.LoadBlock();
            }
        }

    }
}
