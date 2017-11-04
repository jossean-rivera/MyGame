
namespace MyGame
{
    public class AttackState : HeroState
    {
        private double velx; //VelocityX = 0.3 pixels / 1ms
        private int vely; //VelocityY = 1 pixels / 1FPS

        public override HeroState HandleInput(Hero h)
        {
            if (_framecount == _frametotal)
                return new RunState(h, Direction);

            return null;
        }

        public AttackState(Hero hero, HeroDirection direction, double x_vel = 0.15, int y_vel = 1) : base("Jump_Attack", hero.Width + (int)(GameWorld.TILES_WIDTH * 0.85), hero.Height + GameWorld.TILES_HEIGHT * 1/4, direction)
        {
            velx = x_vel;
            vely = y_vel;
        }

        public override void Update(Hero hero, double elapsed)
        {
            base.Update(hero, elapsed);
            hero.Position.X += (int)(velx * elapsed);

            if (_framecount <= _frametotal / 2)
                hero.Position.Y -= vely;
            else
                hero.Position.Y += vely;
        }
    }
}
