using CodeBase.Services.Factories;
using CodeBase.StaticData.Levels;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    /// <summary>
    /// This class is responsible for Initializing game world:
    /// - Creating Player
    /// - Creating MoveArea that handles moving pickupables
    /// - Creating Pickupables from Level Static data
    /// </summary>
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;
        private LevelStaticData _levelData;

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
            _levelData = _staticDataService.ForLevel(SceneManager.GetActiveScene().name);
            _gameFactory.CreatePlayer();
            _gameFactory.CreateMovementArea();
            _gameFactory.CreateEnvironment();
            SpawnPickupables();
        }

        private void SpawnPickupables()
        {
            foreach (var spawnMarker in _levelData.PickupablesSpawners)
                _gameFactory.SpawnPickupable(at: spawnMarker.Position, spawnMarker.TypeId, spawnMarker.Prefab);
        }

        public void Exit()
        {
        }

    }
}