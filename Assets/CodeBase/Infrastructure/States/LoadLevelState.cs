using CodeBase.Services;
using CodeBase.Services.Factories;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            _gameFactory.CreatePlayer();
            _gameFactory.CreateMovementArea();
            SpawnPickupables();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void SpawnPickupables()
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject pickupable = _gameFactory.SpawnPickupable();
                int randomX = Random.Range(-5, 5);
                pickupable.transform.position += new Vector3(randomX, 0, i * 15);
            } 
        }

        public void Exit()
        {
        }

    }
}