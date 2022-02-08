namespace Core.Combat.Ammo
{

    public class PistolRounds : Ammunition
    {
        private readonly int _damage;
        private readonly int _maxCurrentRounds;
        private int _currentRounds;
        public PistolRounds(IConfigurePistolRounds config)
        {
            _maxCurrentRounds = config.MaxRounds;
            _currentRounds = config.CurrentRounds;
            _damage = config.Damage;
        }
        public override void Decrease() => _currentRounds--;
        public override bool Empty() => _currentRounds <= 0;
        public override void Reload() => _currentRounds = _maxCurrentRounds;
        public override float Damage() => _damage;
    }

}