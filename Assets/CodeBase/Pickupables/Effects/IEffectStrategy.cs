namespace CodeBase.Pickupables.Effects
{
    /// <summary>
    /// The strategy pattern abstraction around effects of pickupables
    /// </summary>
    public interface IEffectStrategy
    {
        void Execute();
    }
}