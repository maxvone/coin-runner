using CodeBase.Services;
using CodeBase.Services.Factories;
using CodeBase.Services.Input;

namespace CodeBase.Infrastructure.States
{
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

        public void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IMovementAreaDataHandler>(new MovementAreaDataHandler());
            RegisterStaticDataService();
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IInputService>(),
                _services.Single<IMovementAreaDataHandler>()));
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }

        public void Exit()
        {
        }
    }
}