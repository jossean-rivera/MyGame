using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyGame
{
    public class IdleState : HeroState
    {
        public override HeroState HandleInput(Hero h)
        {
            if (Keyboard.IsKeyDown(Key.Right))
                return new RunState(h, HeroDirection.Right);

            else if (Keyboard.IsKeyDown(Key.Left))
                return new RunState(h, HeroDirection.Left);

            else if (Keyboard.IsKeyDown(Key.A))
                return new JumpState(h, this.Direction);
            else if (Keyboard.IsKeyDown(Key.S))
                return new AttackState(h, this.Direction);


            return null;
        }

        public IdleState(Hero h, HeroDirection d) : base("Idle", h.Width, h.Height, d)
        {
            
        }
    }
}
