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
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IInputService>(), 
                _services.Single<IMovementAreaDataHandler>()));
            
        }

        public void Exit() {}
    }
}