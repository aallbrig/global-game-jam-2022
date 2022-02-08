namespace Core.Combat.Ammo
{
    public interface IConfigurePistolRounds
    {
        public int MaxRounds { get; }

        public int CurrentRounds { get; }

        public int Damage { get; }
    }
}