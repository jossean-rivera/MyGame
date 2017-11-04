using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameWorld
    {
        private GameWorld()
        {
            _objects = new List<GameObject>();
        }
        private static GameWorld _instance;
        public static GameWorld Instance
        {
            get
            {
                if (_instance == null) _instance = new GameWorld();
                return _instance;
            }
        }

        private List<GameObject> _objects;
        public List<GameObject> Objects { get { return _objects; } }

        public void AddObject(GameObject NewObj)
        {
            _objects.Add(NewObj);
        }

        public void Update(double elapsed)
        {
            foreach (GameObject obj in _objects)
                obj.Update(elapsed);
        }

        //public const int CONTAINER_WIDTH = 259 + 1;
        //public const int CONTAINER_HEIGHT = 207 + 3;
        public const int CONTAINER_WIDTH = 500;
        public const int CONTAINER_HEIGHT = 400;

        private Tile[,] _tiles = new Tile[10, 10];
        public Tile[,] Tiles
        {
            get
            {
                return _tiles;
            }
        }

        public void AddTile(Tile tile, int x, int y)
        {
            if (x > 10 | x < 0)
                throw new ArgumentException("X has to be between 0 and 10", "x");

            if (y > 10 | y < 0)
                throw new ArgumentException("Y has to be between 0 and 10", "y");

            _tiles[x, y] = tile;
        }

        public Image BGImage { get; set; }
        public void DrawBG(Graphics g)
        {
            g.DrawImage(BGImage, 0, 0, CONTAINER_WIDTH, CONTAINER_HEIGHT);
        }
    }
}
