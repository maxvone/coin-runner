using CodeBase.Services;
using Cysharp.Threading.Tasks;

namespace CodeBase.Pickupables.Effects
{
    public class BoostSpeedEffect : IEffectStrategy
    {
        private IMovementAreaDataHandlerService _movementAreaDataHandlerService;


        public async void Execute()
        {
            _movementAreaDataHandlerService = AllServices.Container.Single<IMovementAreaDataHandlerService>();
            _movementAreaDataHandlerService.MovementAreaMove.Speed *= 2;

            await UniTask.Delay(10000);
            
            _movementAreaDataHandlerService.MovementAreaMove.Speed /= 2;
        }
        
        
    }
}