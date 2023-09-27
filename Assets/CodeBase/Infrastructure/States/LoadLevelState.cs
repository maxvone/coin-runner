using CodeBase.Logic.Spawners;
using CodeBase.Services;
using CodeBase.Services.Factories;
using CodeBase.StaticData.Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;

        public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory,
            IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            InitGameWorld();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            LevelStaticData levelData = _staticDataService.ForLevel(SceneManager.GetActiveScene().name);
            _gameFactory.CreatePlayer();
            _gameFactory.CreateMovementArea();
            SpawnPickupables(levelData);
        }

        private void SpawnPickupables(LevelStaticData levelData)
        {
            _staticDataService.ForLevel(levelData.LevelKey);
            foreach (var spawnMarker in levelData.PickupablesSpawners)
                _gameFactory.SpawnPickupable(at: spawnMarker.Position, spawnMarker.TypeId);
        }

        public void Exit()
        {
        }

    }
}