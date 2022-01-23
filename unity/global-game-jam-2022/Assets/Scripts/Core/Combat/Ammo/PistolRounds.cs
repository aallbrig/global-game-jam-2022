namespace Core.Combat.Ammo
{
    public interface IConfigurePistolRounds
    {
        public int MaxRounds { get; }

        public int CurrentRounds { get; }

        public int Damage { get; }
    }

    public class PistolRoundConfig : IConfigurePistolRounds
    {
        public PistolRoundConfig(int maxRounds, int currentRounds, int damage)
        {
            MaxRounds = maxRounds;
            CurrentRounds = currentRounds;
            Damage = damage;
        }

        public int MaxRounds { get; }

        public int CurrentRounds { get; }

        public int Damage { get; }
    }

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