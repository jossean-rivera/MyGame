using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

namespace MyGame
{
    /// <summary>
    /// Class with only one instance available for all the project. It contains all the objects of the game and the game loop.
    /// </summary>
    public class GameWorld
    {
        #region Instance
        private GameWorld()
        {
            _objects = new List<GameObject>();
        }
        private static GameWorld _instance;

        /// <summary>
        /// Only instance of the class.
        /// </summary>
        public static GameWorld Instance
        {
            get
            {
                //If not used, then we don't create an instance at all.
                if (_instance == null) _instance = new GameWorld();
                return _instance;
            }
        }
        #endregion

        #region Fields
        //Set the Width and Height of the container in this constants
        public const int CONTAINER_WIDTH = 600;
        public const int CONTAINER_HEIGHT = 480;
        
        //Set the amount of the tiles
        public const int TILES_AMOUNT_X = 15;
        public const int TILES_AMOUNT_Y = 15;
        public const int TILES_WIDTH = CONTAINER_WIDTH / TILES_AMOUNT_X;
        public const int TILES_HEIGHT = CONTAINER_HEIGHT / TILES_AMOUNT_Y;

        //Frames per seconds
        public const int FPS = 60;
        public const int MS_PER_FRAME = 1000 / FPS;

        public bool GameOver = false;

        private Tile[,] _tiles = new Tile[TILES_AMOUNT_X, TILES_AMOUNT_Y];

        private List<GameObject> _objects;
        private Image BGImage { get; set; }
        private Hero _hero;
        #endregion

        #region Properties
        public List<GameObject> Objects { get { return _objects; } }
        public Tile[,] Tiles {  get { return _tiles; }   }
        private Hero HeroInstance { get { return _hero; } }

        /// <summary>
        /// This method is called at the end of the Game Loop and it has to be defined by in the main UI thread
        /// It should draw all the elements from the world; you can use the RederAllElements method available in this class. 
        /// </summary>
        public Action GameRender = null;
        #endregion

        #region Methods

        #region Add Methods
        /// <summary>
        /// Add a game object into the World.
        /// </summary>
        /// <param name="NewObj">A new game obect instance to add to the world</param>
        public void AddObject(GameObject NewObj)
        {
            _objects.Add(NewObj);
        }

        /// <summary>
        /// Add a hero instance to the world and to the list of Game Objects. Should not use the AddObject to add the hero.
        /// </summary>
        /// <param name="hero">The hero instance.</param>
        public void AddHero(Hero hero)
        {
            if (_hero == null)
            {
                _hero = hero;
                AddObject(hero);
            }
            else
            {
                throw new ArgumentException("There is a hero instance in the world alredy", "hero");
            }
        }

        /// <summary>
        /// Adds a new tile into the world at the given indexes.
        /// </summary>
        /// <param name="tile">New tile instance to add into the world.</param>
        /// <param name="x">X index the tile should be added to the tiles array.</param>
        /// <param name="y">Y index the tile should be added to the tiles array.</param>
        public void AddTile(Tile tile, int x, int y)
        {
            if (x > TILES_AMOUNT_X | x < 0)
                throw new ArgumentException(String.Format("X has to be between 0 and {0}", TILES_AMOUNT_X), "x");
            else if (y > TILES_AMOUNT_Y | y < 0)
                throw new ArgumentException(String.Format("Y has to be between 0 and {0}", TILES_AMOUNT_Y), "y");
            else
                _tiles[x, y] = tile;
        }
        #endregion

        #region Game Loop Methods

        #region Update Method
        /// <summary>
        /// Calls the update method of every game object in the world.
        /// </summary>
        /// <param name="elapsed">Time lapse since the last call to this method.</param>
        private void Update(double elapsed)
        {
            foreach (GameObject obj in _objects)
                obj.Update(elapsed);
        }
        #endregion

        #region Draw Methods
        /// <summary>
        /// Draws the background image into the given bitmap.
        /// </summary>
        /// <param name="g">The bitmap to draw the background.</param>
        public void DrawBG(Graphics g)
        {
            g.DrawImage(BGImage, 0, 0, CONTAINER_WIDTH, CONTAINER_HEIGHT);
        }

        /// <summary>
        /// Draws the tiles image from the array of tiles in the world into the given bitmap.
        /// </summary>
        /// <param name="g">Bitmap to draw the tiles.</param>
        public void DrawTiles(Graphics g)
        {
            for (int row = 0; row < TILES_AMOUNT_X; row++)
                for (int col = 0; col < TILES_AMOUNT_Y; col++)
                    if (Tiles[row, col] != null)
                        Tiles[row, col].Draw(g, row, col);
        }

        /// <summary>
        /// Draws all the objects in the world into the given bitmap.
        /// </summary>
        /// <param name="g">Bitmap to draw the objects.</param>
        public void DrawObjects(Graphics g)
        {
            foreach (GameObject obj in Objects)
                obj.Draw(g);
        }

        /// <summary>
        /// This method is called at end of the Game Loop, and it draws the BG, then the tiles, and finally it draws all the objects (including the hero).
        /// </summary>
        /// <param name="graphics">Bitmap to draw all the components of the game.</param>
        public void RenderAllElements(Graphics graphics)
        {
            DrawBG(graphics);
            DrawTiles(graphics);
            DrawObjects(graphics);
        }
        #endregion

        /// <summary>
        /// Engine of the Game. First, it handles the input, then calls the Update() method and finally the GameRender() method.
        /// The hero instance should be added before this loop runs, because the hero instance is who handles the input.
        /// This method should be called in a thread in the background.
        /// You should also override the GameRender method and refresh the container of the bitmap.
        /// </summary>
        public void GameLoop()
        {
            InitializeGame();
            double start;
            double lasttick = GetCurrentTime();
            double elapsed;
            int wait;

            if (_hero == null)
                throw new InvalidOperationException("The hero intance has to be added to the game before the loops begins.");

            if (GameRender == null)
                throw new InvalidOperationException("The GameRender action has to be added to the game before the loops begins.");

            while (!GameOver)
            {
                start = GetCurrentTime();
                elapsed = start - lasttick;
                lasttick = start;

                _hero.HandleInput();
                Update(elapsed);
                GameRender();

                //Wait until it's time to start the next frame
                wait = (int)(start + MS_PER_FRAME - GetCurrentTime());
                if (wait > 0)
                    Thread.Sleep(wait);

                //Display the rate of frames per seconds to the console
                Console.WriteLine("FPS: [{0}]", Math.Round(1000 / (GetCurrentTime() - start), 1));
            }
            Console.WriteLine("Game Over");
        }

        private long GetCurrentTime()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        /// <summary>
        /// This method is called before the game loop starts. It initializes the objects in the world.
        /// It creates a simple set of tiles and a hero instance, this method can be overrided.
        /// </summary>
        public virtual void InitializeGame()
        {
            #region TEMP Adding tiles to the game
            AddTile(TileInstances.GroundTile_Under_BottomLeftEnd, 0, TILES_AMOUNT_Y - 1);

            for (int i = 1; i <= TILES_AMOUNT_X - 2; i++)
                AddTile(TileInstances.GroundTile_Under_BottomEnd, i, TILES_AMOUNT_Y - 1);

            AddTile(TileInstances.GroundTile_Under_BottonRightEnd, TILES_AMOUNT_X - 1, TILES_AMOUNT_Y -1);

            AddTile(TileInstances.GroundTile_Top_LeftEnd, 0, TILES_AMOUNT_Y - 2);

            for (int i = 1; i <= TILES_AMOUNT_X - 2; i++)
                AddTile(TileInstances.GroundTile_Top_NoEnd, i, TILES_AMOUNT_Y - 2);

            AddTile(TileInstances.GroundTile_Top_RightEnd, TILES_AMOUNT_X - 1, TILES_AMOUNT_Y - 2);
            #endregion

            #region Generating Hero instance
            Hero hero = new Hero(TILES_WIDTH * (TILES_AMOUNT_X / 2 - 1), TILES_HEIGHT * (TILES_AMOUNT_Y - 4), TILES_WIDTH, TILES_HEIGHT * 2);
            AddHero(hero);
            #endregion

            #region Create BG img instance
            string BGDirectory = Path.Combine(Environment.CurrentDirectory, @"tileset (night)\bg\BG.png");

            if (BGDirectory.Contains("bin\\Debug\\"))
                BGDirectory = BGDirectory.Replace("bin\\Debug\\", string.Empty);

            GameWorld.Instance.BGImage = Image.FromFile(BGDirectory);
            #endregion
        }

        #endregion

        #endregion
    }
}
