using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyGame
{
    public class IdleLeftState : HeroState
    {
        public override HeroState HandleInput(Hero h)
        {
            if (Keyboard.IsKeyDown(Key.Left))
                return new RunLeftState(h);

            if (Keyboard.IsKeyDown(Key.Right))
                return new RunRightState(h);

            return null;
        }

        public IdleLeftState(Hero hero) : base("Idle", hero.Width, hero.Height, HeroDirection.Left)
        {

        }
    }
}
