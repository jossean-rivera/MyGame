using System.Drawing;
using System.Windows.Input;

namespace MyGame
{
    public class RunState : HeroState
    {
        //TEMP field
        private const int vel = 5;
        public override HeroState HandleInput(Hero h)
        {
            switch (Direction)
            {
                case HeroDirection.Right:
                    if (Keyboard.IsKeyUp(Key.Right))
                        return new IdleState(h, HeroDirection.Right);
                    break;
                case HeroDirection.Left:
                    if (Keyboard.IsKeyUp(Key.Left))
                        return new IdleState(h, HeroDirection.Left);
                    break;
            }

            if (Keyboard.IsKeyDown(Key.A))
                return new JumpState(h, this.Direction);

            return null;
        }

        public override void Update(Hero hero)
        {
            base.Update(hero);
            switch (Direction)
            {
                case HeroDirection.Right:
                    hero.Position.X += vel;
                    break;
                case HeroDirection.Left:
                    hero.Position.X -= vel;
                    break;
            }
        }

        public override void Draw(Graphics g, int x, int y)
        {
            base.Draw(g, x, y);
            //g.DrawRectangle(Pens.Red, x, y, ImgWidth, ImgHeigh);
        }

        public RunState(Hero h, HeroDirection d) : base("Run", h.Width, h.Height, d)
        {

        }
    }
}
