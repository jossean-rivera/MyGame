using System.Drawing;
using System.Windows.Input;

namespace MyGame
{
    public class JumpState : HeroState
    {
        private Key _input;
        private Hero _hero;
        private const int vely = 10; //VelocityY = 10 pixels / 1 Frame
        private const double velx = 0.3; //VelocityX = 0.3 pixels / 1ms
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

        public override void Update(Hero hero, double elapsed)
        {
            base.Update(hero, elapsed);

            if (_input == Key.Right)
                hero.Position.X += (int)(velx * elapsed);
            else if (_input == Key.Left)
                hero.Position.X -= (int)(velx * elapsed);

            if(FrameNum < 5)
            {
                //Go up
                hero.Position.Y -= vely;
            }
            else if (FrameNum <= 9)
            {
                hero.Position.Y += vely;
                if (FrameNum == 9) _hero = hero;
            }
        }

        public override void Draw(Graphics g, int x, int y)
        {
            base.Draw(g, x, y);
            if(FrameNum >= 9)
            {
                _hero.State = new RunState(_hero, this.Direction);
                _hero.State.Enter(_hero);
            }
        }

        public JumpState(Hero h, HeroDirection d) : base("Jump", h.Width, h.Height, d)
        {

        }
    }
}
