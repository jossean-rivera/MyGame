using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyGame
{
    public class JumpState : HeroState
    {
        private Key _input;
        private Hero _hero; //We need the hero instance to be able to be at the draw method
        private const int vely = 15;
        private const int velx = 7;
        public override HeroState HandleInput(Hero h)
        {
            if (Keyboard.IsKeyDown(Key.Right))
                _input = Key.Right;
            else if (Keyboard.IsKeyDown(Key.Left))
                _input = Key.Left;

            else if (Keyboard.IsKeyUp(Key.Right) & Keyboard.IsKeyUp(Key.Down))
                _input = Key.Z;

            return null;
        }

        public override void Update(Hero hero)
        {
            base.Update(hero);

            if (_input == Key.Right)
                hero.Position.X += velx;
            else if (_input == Key.Left)
                hero.Position.X -= velx;

            if(_framecount <= 10)
            {
                //Go up
                hero.Position.Y -= vely;
            }
            else if (_framecount <= 20)
            {
                hero.Position.Y += vely;
                if (_framecount == 20 & _delaycounter == ImgDelay)
                {
                    _hero = hero;
                    //hero.Position.Y -= vely;
                }
            }
        }

        public override void Draw(Graphics g, int x, int y)
        {
            base.Draw(g, x, y);
            if(_hero != null)
            {
                _hero.State = new RunState(_hero, this.Direction);
                _hero.State.Enter(_hero);
            }
        }

        public override void Enter(Hero hero)
        {
            base.Enter(hero);
            _hero = null;
        }

        public JumpState(Hero h, HeroDirection d) : base("Jump", h.Width, h.Height, d)
        {

        }
    }
}
