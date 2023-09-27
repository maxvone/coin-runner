using CodeBase.Services;
using CodeBase.Services.Factories;
using Cysharp.Threading.Tasks;

namespace CodeBase.Pickupables.Effects
{
    public class SlowDownSpeedEffect : IEffectStrategy
    {
        private IMovementAreaDataHandlerService _movementAreaDataHandlerService;
        public async void Execute()
        {
            _movementAreaDataHandlerService = AllServices.Container.Single<IMovementAreaDataHandlerService>();
            _movementAreaDataHandlerService.MovementAreaMove.Speed /= 2;
            
            await UniTask.Delay(10000);
            
            _movementAreaDataHandlerService.MovementAreaMove.Speed *= 2;
        }
    }
}