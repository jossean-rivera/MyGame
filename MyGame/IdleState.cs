using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyGame
{
    public class IdleRightState : HeroState
    {
        public override void Draw(Graphics g, int x, int y)
        {
            base.Draw(g, x, y);
        }

        public override void Update(Hero hero)
        {
            base.Update(hero);
        }

        public override HeroState HandleInput()
        {
            if (Keyboard.IsKeyDown(Key.Right))
                return null; //return RunRightState;

            return null;
        }

        public IdleRightState(string name, int heroWidth, int heroHeight) : base(name, heroWidth, heroHeight)
        {
            Name = "Idle";
            Direction = HeroDirection.Right;
        }
    }
}
