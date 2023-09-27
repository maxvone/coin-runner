using CodeBase.Services;
using CodeBase.Services.Factories;

namespace CodeBase.Pickupables.Effects
{
    public class SlowDownSpeedEffect : IEffectStrategy
    {
        private IMovementAreaDataHandlerService _movementAreaDataHandlerService;
        public void Execute()
        {
            _movementAreaDataHandlerService = AllServices.Container.Single<IMovementAreaDataHandlerService>();
            _movementAreaDataHandlerService.MovementAreaMove.Speed /= 2;
        }
    }
}