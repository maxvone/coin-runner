using CodeBase.Services;
using CodeBase.Services.Factories;
using CodeBase.Services.Input;

namespace CodeBase.Infrastructure.States
{
    /// <summary>
    /// The first state of the game
    /// This state represents DI context in terms of different DI frameworks.
    /// It's goal to Register Services in the Service Locator.
    /// And after loading service to transfer game into the next state. 
    /// </summary>
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly AllServices _services;

        public BootstrapState(IGameStateMachine gameStateMachine, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;

            RegisterServices();
        }

        public void Enter() => 
            _gameStateMachine.Enter<LoadLevelState>();

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IMovementAreaDataHandlerService>(new MovementAreaDataHandlerServiceService());
            _services.RegisterSingle<IPlayerDataHandlerService>(new PlayerDataHandlerService());
            RegisterStaticDataService();
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IInputService>(),
                _services.Single<IMovementAreaDataHandlerService>(), 
                _services.Single<IPlayerDataHandlerService>(),
                _services.Single<IAssetProvider>()));
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);

            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
        }

        public void Exit(){}
    }
}