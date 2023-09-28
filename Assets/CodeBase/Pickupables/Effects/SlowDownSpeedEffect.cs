using CodeBase.Services;
using Cysharp.Threading.Tasks;

namespace CodeBase.Pickupables.Effects
{
    public class SlowDownSpeedEffect : IEffectStrategy
    {
        public string Text => "- Speed";
        private IMovementAreaDataHandlerService _movementAreaDataHandlerService;

        public SlowDownSpeedEffect(IMovementAreaDataHandlerService movementAreaDataHandlerService)
        {
            _movementAreaDataHandlerService = movementAreaDataHandlerService;
        }


        public async void Execute()
        {
            _movementAreaDataHandlerService.MovementAreaMove.Speed /= 2;
            
            await UniTask.Delay(10000);
            
            _movementAreaDataHandlerService.MovementAreaMove.Speed *= 2;
        }
    }
}