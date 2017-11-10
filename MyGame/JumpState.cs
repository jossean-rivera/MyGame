using System;
using System.Drawing;
using System.Windows.Input;

namespace MyGame
{
    public class JumpState : HeroState
    {
        private Key _input;
        private const int vely = 25; //VelocityY = 10 pixels / 1 Frame
        private const double velx = 0.3; //VelocityX = 0.3 pixels / 1ms
        private const int _pixelsMetersRate = 3780; // 3780 pixls / m
        private const double _g2 = 9.81 * 3780 / 1000; //G = 0.03708 px/ms/ms
        private const double _g = 15;
        private double _temp_Vel;
        private double _temp_acc;
        private double _delta_time;


        private double _velYinit;
        private double _currentvely;
        private int _init_position_y;

        public override HeroState HandleInput(Hero h)
        {
            //if (_framecount >= _frametotal)
            //    if (Keyboard.IsKeyDown(Key.Right))
            //        return new RunState(h, HeroDirection.Right);
            //    else if (Keyboard.IsKeyDown(Key.Left))
            //        return new RunState(h, HeroDirection.Left);
            //    else
            //        return new IdleState(h, Direction);

            if (Keyboard.IsKeyUp(Key.A))
                _temp_acc = 25;
            else if (Keyboard.IsKeyDown(Key.A))
                _temp_acc = 15;

            _input = Key.Z;
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

            //if(_framecount <= _frametotal / 2)
            //{
            //    //Go up
            //    hero.Position.Y -= vely;
            //}
            //else if (_framecount <= _frametotal)
            //{
            //    //Go down
            //    hero.Position.Y += vely;
            //}
            //hero.Position.Y += (int)(_currentvely * elapsed);
            //CalculateFinalVelocity(elapsed);

            //_timecounter += elapsed;
            //if(_timecounter >= _timetomaxheight)
            //{
            //    if (GoUp)
            //        GoUp = false;

            //    _timecounter = 0;
            //}

            //if (GoUp)
            //    hero.Position.Y -= (int)(_currentvely * elapsed);
            //else
            //    hero.Position.Y += (int)(_currentvely * elapsed);

            _delta_time += elapsed / 1000;

            double a = _temp_Vel * _delta_time;
            double b = _temp_acc * _delta_time * _delta_time;
            double c = 0.5 * b;

            hero.Position.Y += (int)(a + c);
            Console.WriteLine("Y = {0}", hero.Position.Y);
            _temp_Vel += _temp_acc * _delta_time;

            if(hero.Position.Y >= _init_position_y)
            {
                hero.Position.Y = _init_position_y;
                hero.State = new IdleState(hero, Direction);
                hero.State.Enter(hero);
            }
        }

        public override void Enter(Hero hero)
        {
            base.Enter(hero);
            _currentvely = _velYinit = 0.25; //0.25 pixls/ms
            _temp_Vel = -80;
            _temp_acc = _g;
            _delta_time = 0;
            _init_position_y = hero.Position.Y;
        }

        public JumpState(Hero h, HeroDirection d) : base("Jump", h.Width + GameWorld.TILES_WIDTH * 1/3, h.Height + GameWorld.TILES_HEIGHT * 1 / 8, d){ }
    }
}
