using CodeBase.Services;
using CodeBase.Services.Factories;

namespace CodeBase.Pickupables.Effects
{
    public class BoostSpeedEffect : IEffectStrategy
    {
        private IMovementAreaDataHandler _movementAreaDataHandler;

        public void Execute()
        {
            _movementAreaDataHandler = AllServices.Container.Single<IMovementAreaDataHandler>();
            _movementAreaDataHandler.MovementAreaMove.Speed *= 2;
        }
        
        
    }
}