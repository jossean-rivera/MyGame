using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyGame
{
    public class RunLeftState : HeroState
    {
        public override HeroState HandleInput(Hero h)
        {
            if (Keyboard.IsKeyUp(Key.Left))
                //TEMP
                return new IdleRightState("Idle", h.Width, h.Height);

            return null;
        }

        public override void Update(Hero hero)
        {
            base.Update(hero);
            hero.Position.X -= 5;
        }

        public RunLeftState(string name, int heroWidth, int heroHeight) : base(name, heroWidth, heroHeight, HeroDirection.Left)
        { 

        }
    }
}
