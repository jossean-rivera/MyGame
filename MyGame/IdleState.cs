using System.Windows.Input;

namespace MyGame
{
    public class IdleState : HeroState
    {
        public override HeroState HandleInput(Hero h)
        {
            if (Keyboard.IsKeyDown(Key.Right))
                return HeroStateInstances.GetRunState(h, HeroDirection.Right);

            else if (Keyboard.IsKeyDown(Key.Left))
                return HeroStateInstances.GetRunState(h, HeroDirection.Left);

            else if (Keyboard.IsKeyDown(Key.A))
                return HeroStateInstances.GetJumpState(h, this.Direction);
            else if (Keyboard.IsKeyDown(Key.S))
                return HeroStateInstances.GetAttackState(h, this.Direction);


            return null;
        }

        public IdleState(Hero h, HeroDirection d) : base("Idle", h.Width, h.Height, d)
        {
            
        }
    }
}
