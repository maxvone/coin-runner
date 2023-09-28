using CodeBase.Services;
using Cysharp.Threading.Tasks;

namespace CodeBase.Pickupables.Effects
{
    public class BoostSpeedEffect : IEffectStrategy
    {
        public string Text => "+ Speed";
        private IMovementAreaDataHandlerService _movementAreaDataHandlerService;

        public BoostSpeedEffect(IMovementAreaDataHandlerService movementAreaDataHandlerService) => 
            _movementAreaDataHandlerService = movementAreaDataHandlerService;



        public async void Execute()
        {
            _movementAreaDataHandlerService.MovementAreaMove.Speed *= 4;

            await UniTask.Delay(10000);
            
            _movementAreaDataHandlerService.MovementAreaMove.Speed /= 4;
        }
        
        
    }
}