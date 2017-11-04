using System.Drawing;
using System.Windows.Input;

namespace MyGame
{
    public class JumpState : HeroState
    {
        private Key _input;
        private Hero _hero; //We need the hero instance to be able to be at the draw method
        private const int vely = 10; //VelocityY = 10 pixels / 1 Frame
        private const double velx = 0.3; //VelocityX = 0.3 pixels / 1ms

        public override HeroState HandleInput(Hero h)
        {
            if (_framecount >= _frametotal)
                if (Keyboard.IsKeyDown(Key.Right))
                    return new RunState(h, HeroDirection.Right);
                else if (Keyboard.IsKeyDown(Key.Left))
                    return new RunState(h, HeroDirection.Left);
                else
                    return new IdleState(h, Direction);

            if (Keyboard.IsKeyDown(Key.Right))
                _input = Key.Right;
            else if (Keyboard.IsKeyDown(Key.Left))
                _input = Key.Left;

            return null;
        }

        public override void Update(Hero hero, double elapsed)
        {
            base.Update(hero, elapsed);

            if (_input == Key.Right)
                hero.Position.X += (int)(velx * elapsed);
            else if (_input == Key.Left)
                hero.Position.X -= (int)(velx * elapsed);

            if(_framecount <= _frametotal / 2)
            {
                //Go up
                hero.Position.Y -= vely;
            }
            else if (_framecount <= _frametotal)
            {
                //Go down
                hero.Position.Y += vely;
                //if (_framecount == _frametotal & _delaycounter == ImgDelay)
                //    _hero = hero;
            }
        }

        public override void Draw(Graphics g, int x, int y)
        {
            base.Draw(g, x, y);
            //if(_hero != null)
            //{
            //    _hero.State = new RunState(_hero, this.Direction);
            //    _hero.State.Enter(_hero);
            //}
        }

        public override void Enter(Hero hero)
        {
            base.Enter(hero);
            //_hero = null;
        }

        public JumpState(Hero h, HeroDirection d) : base("Jump", h.Width + GameWorld.TILES_WIDTH * 1/3, h.Height + GameWorld.TILES_HEIGHT * 1 / 8, d)
        {
            
        }
    }
}
