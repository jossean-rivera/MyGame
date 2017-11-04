using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace MyGame
{
    public class Hero : GameObject
    {
        public Image Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public HeroState State { get; set; }

        public Hero(int x, int y, int width, int height)
        {
            Position = new Vector();
            Position.X = x;
            Position.Y = y;

            Width = width;
            Height = height;

            //TEMP
            State = new IdleState(this, HeroDirection.Right);
        }

        public override void Update()
        {
            State.Update(this);
        }

        public override void Draw(Graphics g)
        {
            State.Draw(g, Position.X, Position.Y);
        }

        public void HandleInput()
        {
            HeroState returnedstate = State.HandleInput(this);
            if (returnedstate != null)
            {
                //delete State;
                GC.Collect();
                State = returnedstate;
                State.Enter(this);
            }
        }
    }
}
