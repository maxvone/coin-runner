using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
    public class GameBootstrap
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameBootstrap(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;

            StartGame();
        }

        private void StartGame()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}