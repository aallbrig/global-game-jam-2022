namespace Core.Combat.Ammo
{
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
}