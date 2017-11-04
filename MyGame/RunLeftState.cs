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
        public override HeroState HandleInput(Hero hero)
        {
            if (Keyboard.IsKeyUp(Key.Left))
                //TEMP
                return new IdleLeftState(hero);

            return null;
        }

        public override void Update(Hero hero)
        {
            base.Update(hero);
            hero.Position.X -= 5;
        }

        public RunLeftState(Hero hero) : base("Run", hero.Width, hero.Height, HeroDirection.Left)
        { 

        }
    }
}
