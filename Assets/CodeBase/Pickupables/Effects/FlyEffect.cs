using CodeBase.Services;
using Cysharp.Threading.Tasks;

namespace CodeBase.Pickupables.Effects
{
    public class FlyEffect : IEffectStrategy
    {
        private IPlayerDataHandlerService _playerDataHandlerService;

        public FlyEffect(IPlayerDataHandlerService playerDataHandlerService) => 
            _playerDataHandlerService = playerDataHandlerService;

        public async void Execute()
        {
            _playerDataHandlerService.PlayerAnimation.PlayFly();
            
            await UniTask.Delay(10000);
            
            _playerDataHandlerService.PlayerAnimation.ReturnToMove();
        }
    }
}