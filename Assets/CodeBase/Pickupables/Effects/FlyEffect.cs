using CodeBase.Services;
using Cysharp.Threading.Tasks;

namespace CodeBase.Pickupables.Effects
{
    public class FlyEffect : IEffectStrategy
    {
        private IPlayerDataHandlerService _playerDataHandlerService;

        public bool IsExecuting { get; set; }

        public async void Execute()
        {
            _playerDataHandlerService = AllServices.Container.Single<IPlayerDataHandlerService>();
            _playerDataHandlerService.PlayerAnimation.PlayFly();
            IsExecuting = true; 
            await UniTask.Delay(10000);
            
            IsExecuting = false; 
            _playerDataHandlerService.PlayerAnimation.ReturnToMove();
        }
    }
}