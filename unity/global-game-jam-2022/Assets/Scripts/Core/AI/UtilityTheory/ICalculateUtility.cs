namespace Core.AI.UtilityTheory
{
    public interface ICalculateUtility<out T>
    {
        public T CalculateUtility();
    }
}