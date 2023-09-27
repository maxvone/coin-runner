namespace CodeBase.Pickupables.Effects
{
    public interface IEffectStrategy
    {
        public bool IsExecuting { get; set; }
        void Execute();
    }
}