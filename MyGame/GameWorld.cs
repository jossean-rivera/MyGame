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

        public void Update()
        {
            foreach (GameObject obj in _objects)
                obj.Update();
        }

        public const int CONTAINER_WIDTH = 259;
        public const int CONTAINER_HEIGHT = 207;
    }
}
