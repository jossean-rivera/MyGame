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
        public override HeroState HandleInput(Hero hero)
        {
            if (Keyboard.IsKeyDown(Key.Right))
                return new RunRightState("Run", hero.Width, hero.Height);

            if (Keyboard.IsKeyDown(Key.Left))
                return new RunLeftState("Run", hero.Width, hero.Height);

            return null;
        }

        public IdleRightState(string name, int heroWidth, int heroHeight) : base(name, heroWidth, heroHeight, HeroDirection.Right)
        {

        }
    }
}
