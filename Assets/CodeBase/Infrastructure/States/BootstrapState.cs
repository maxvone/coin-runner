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
        }
        
        public void Enter()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IGameFactory>(new GameFactory());

            IInputService inputService = _services.Single<IInputService>();
        }

        public void Exit() {}
    }
}