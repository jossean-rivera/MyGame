using System.Windows.Input;

namespace MyGame
{
    public class RunRightState : HeroState
    {
        public RunRightState(string name, int heroWidth, int heroHeight) : base(name, heroWidth, heroHeight)
        {
            Direction = HeroDirection.Right;
        }

        public override HeroState HandleInput(Hero hero)
        {
            if (Keyboard.IsKeyUp(Key.Right))
                return new IdleRightState("Idle", hero.Width, hero.Height);

            //if iskeydown left then return new RunLeftState()

            return null;
        }

        public override void Update(Hero hero)
        {
            base.Update(hero);
            hero.Position.X += 5;
        }
    }
}
