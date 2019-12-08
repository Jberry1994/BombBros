using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System.Linq;

namespace BombBros
{
    public class Game
    {
        public const int TargetFPS = 60;
        public const double UpdateCounter = 1.0 / TargetFPS;

        public const uint DefaultWindowWidth = 800;
        public const uint DefaultWindowHeight = 600;
        public const string DefaultWindowTitle = "Bomb Bros.";
        public Color DefaultWindowColor = Color.Black;

        public bool IsRunning { get; set; }
        public bool DisplayDebug { get; set; }
        public Character PlayerOne { get; set; }
        public Arena Arena { get; set; }
        public List<Bomb> Bombs { get; set; }
        public RenderWindow Window { get; protected set; }
        public GameTime GameTime { get; protected set; }
        public Color WindowClearColor { get; protected set; }
        public Game(uint windowWidth, uint windowHeight, string windowTitle, Color color)
        {
            this.WindowClearColor = color;
            this.Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle);
            this.GameTime = new GameTime();
            Window.Closed += WindowClosed;
        }
        public Game()
        {
            this.WindowClearColor = DefaultWindowColor;
            this.Window = new RenderWindow(new VideoMode(DefaultWindowWidth, DefaultWindowHeight), DefaultWindowTitle);
            this.GameTime = new GameTime();
            Window.Closed += WindowClosed;
            Window.KeyPressed += WindowKeyPressed;
            Window.KeyReleased += WindowKeyReleased;
        }


        public void Run()
        {

            Initialize();
            LoadContent();
            float totalTimeBeforeUpdate = 0, previousTimeElapsed = 0, deltaTime = 0, totalTimeElapsed = 0;

            Clock clock = new Clock();


            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;
                totalTimeBeforeUpdate += deltaTime;

                if (totalTimeBeforeUpdate >= UpdateCounter)
                {
                    GameTime.Update(totalTimeBeforeUpdate, totalTimeElapsed);
                    totalTimeBeforeUpdate = 0;
                    Update(GameTime);
                    Window.Clear(WindowClearColor);
                    Render(GameTime);
                    Window.Display();
                }

                // Play the game

            }
        }
        public void LoadContent()
        {
            DebugUtility.LoadFont();
            Arena.LoadArena();
            PlayerOne.LoadCharacter();
            Bomb.LoadBomb();
        }
        public void Initialize()
        {
            InitializeArena();
            InitializeCharacters();
            InitializeBombs();
        }
        public void Update(GameTime gameTime)
        {
            Arena.Update();
            if (GetDistance(PlayerOne.Position.X, PlayerOne.Position.Y, Arena.Blocks.FirstOrDefault().Position.X, Arena.Blocks.FirstOrDefault().Position.Y)
                < Character.CharacterWidth /2 + Blocks.BlockWidth)
            {
                
            }
            PlayerOne.Update(gameTime);
            foreach (Bomb bomb in Bombs)
            {
                bomb.Update(gameTime);
            }


        }
        public void Render(GameTime gameTime)
        {
            Arena.DisplayArena(this);
            PlayerOne.DisplayCharacter(this);
            int? IndexToRemove = null;
            for (int i = 0; i < Bombs.Count; i++)
            {
                if (Bombs[i].BombExploded)
                {
                    IndexToRemove = i;
                }
            }
            if (IndexToRemove != null)
            {
                Bombs.RemoveAt((int)IndexToRemove);
            }

            foreach (Bomb bomb in Bombs)
            {


                bomb.DisplayBomb(this);


            }
            if (DisplayDebug)
            {
                DebugUtility.DisplayDebugInfo(this, PlayerOne, Arena.Blocks.FirstOrDefault(), Color.White);
            }



        }


        public void InitializeCharacters()
        {
            PlayerOne = new Character($"../player-{(new Random().Next() % 2 == 0 ? 1 : 2)}.png", new Vector2f(40.0f, 40.0f));
        }
        public void InitializeArena()
        {
            Arena = new Arena();
        }
        public void InitializeBombs()
        {
            Bombs = new List<Bomb>();
        }
        private void WindowClosed(object sender, EventArgs e)
        {
            Window.Close();
        }
        private void WindowKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F3)
            {
                DisplayDebug = !DisplayDebug;
            }
            if (e.Code == Keyboard.Key.Space && PlayerOne.CanDropBomb)
            {
                Bombs.Add(PlayerOne.DropBomb(GameTime.TotalTimeElapsed));
            }
            PlayerOne.KeyUpControls(e);
        }

        private void WindowKeyReleased(object sender, KeyEventArgs e)
        {
            PlayerOne.KeyDownControls(e);
        }
        public double GetDistance(float x1, float y1, float x2, float y2)
        {
            float xDistance = x2 - x1;
            float yDistance = y2 - y1;
            return Math.Sqrt(Math.Pow(xDistance,2) + Math.Pow(yDistance, 2));

        }
    }
}
