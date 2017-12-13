namespace MyGame
{
    /// <summary>
    /// All the instances of the states of the hero are in this library.
    /// If any of the states are not used, then the instance of that state never gets created.
    /// </summary>
    public class HeroStateInstances
    {
        #region JumpState
        private static HeroState _jumpState;

        /// <summary>
        /// Get the instance of the JumpState of the hero.
        /// </summary>
        public static HeroState GetJumpState(Hero h, HeroDirection d)
        {
            if (_jumpState == null) _jumpState = new JumpState(h, d);
            else if (_jumpState.Direction != d)
                _jumpState.Direction = d;

            return _jumpState;
        }
        #endregion

        #region IdleState
        private static HeroState _idleState;
        /// <summary>
        /// Instance of the Idle state of the hero.
        /// </summary>
        public static HeroState GetIdleState(Hero h, HeroDirection d)
        {
            if (_idleState == null)
                _idleState = new IdleState(h, d);
            else if (_idleState.Direction != d)
                _idleState.Direction = d;

            return _idleState;
        }
        #endregion

        #region RunState
        private static HeroState _runState;
        /// <summary>
        /// Get the instace of the Run state of the hero
        /// </summary>
        public static HeroState GetRunState(Hero h, HeroDirection d)
        {
            if (_runState == null)
                _runState = new RunState(h, d);
            else if (_runState.Direction != d)
                _runState.Direction = d;

            return _runState;
        }

        #endregion

        #region AttackState
        private static HeroState _attackState;
        /// <summary>
        /// Get the instance of the attack state of the hero.
        /// </summary>
        public static HeroState GetAttackState(Hero h, HeroDirection d)
        {
            if (_attackState == null)
                _attackState = new AttackState(h, d);
            else if (_attackState.Direction != d)
                _attackState.Direction = d;

            return _attackState;
        }

        #endregion
    }
}
