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
                return new RunRightState(hero);

            if (Keyboard.IsKeyDown(Key.Left))
                return new RunLeftState(hero);

            return null;
        }

        public IdleRightState(Hero hero) : base("Idle", hero.Width, hero.Height, HeroDirection.Right)
        {

        }
    }
}
