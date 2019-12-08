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
        const string DestroyableBlockPath = "../Block-DestroyableRock.png";
        const string BlockPath = "../Block-Rock.png";
        public Arena()
        {
            Blocks = new List<Blocks>();
            //float height = BombBros.Blocks.BlockHeight * BombBros.Blocks.Yscale;
            //float width = BombBros.Blocks.BlockWidth * BombBros.Blocks.Xscale;
            
            //for (float i = 0; i < Game.DefaultWindowHeight; i += height)
            //{
            //    for (float j = 0; j < Game.DefaultWindowWidth; j += width)
            //    {
            //        int temp = new Random().Next();
            //        Blocks.Add(new Blocks(( temp % 2 == 0 ? DestroyableBlockPath : BlockPath), new Vector2f(j, i) ,temp % 2 == 0 ? true : false));
            //    }
            //}
            Blocks.Add(new Blocks(DestroyableBlockPath, new Vector2f(75.0f, 75.0f), true));
            Blocks.Add(new Blocks(DestroyableBlockPath, new Vector2f(175.0f, 75.0f), true));
            Blocks.Add(new Blocks(DestroyableBlockPath, new Vector2f(275.0f, 75.0f), true));
            Blocks.Add(new Blocks(DestroyableBlockPath, new Vector2f(375.0f, 75.0f), true));
            Blocks.Add(new Blocks(BlockPath, new Vector2f(175.0f, 175.0f), false));
            Blocks.Add(new Blocks(BlockPath, new Vector2f(175.0f, 275.0f), false));
            Blocks.Add(new Blocks(BlockPath, new Vector2f(175.0f, 375.0f), false));
            Blocks.Add(new Blocks(BlockPath, new Vector2f(175.0f, 475.0f), false));

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
