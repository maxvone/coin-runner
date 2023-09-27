using CodeBase.Services;

namespace CodeBase.Pickupables.Effects
{
    public class FlyEffect : IEffectStrategy
    {
        private IPlayerDataHandlerService _playerDataHandlerService;

        public void Execute()
        {
            _playerDataHandlerService = AllServices.Container.Single<IPlayerDataHandlerService>();
            _playerDataHandlerService.PlayerAnimation.PlayFly();
        }
    }
}