using CodeBase.MovementArea;
using CodeBase.Pickupables.Coins;
using CodeBase.Pickupables.Effects;
using CodeBase.Player;
using CodeBase.Services.Input;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Services.Factories
{
    /// <summary>
    /// GameFactory is responsible for creating all objects in the world.
    /// Usually it should be divided into other factories, but in a such small game this one should be enough
    /// </summary>
    public class GameFactory : IGameFactory
    {
        private readonly IInputService _inputService;
        private readonly IMovementAreaDataHandlerService _movementAreaDataHandlerService;
        private readonly IPlayerDataHandlerService _playerDataHandlerService;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        private GameObject _movementAreaInstance; 

        public GameFactory(IInputService inputService, IMovementAreaDataHandlerService movementAreaDataHandlerService,
            IPlayerDataHandlerService playerDataHandlerService, IAssetProvider assetProvider,
            IStaticDataService staticDataService)
        {
            _inputService = inputService;
            _movementAreaDataHandlerService = movementAreaDataHandlerService;
            _playerDataHandlerService = playerDataHandlerService;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public void CreatePlayer()
        {
            var instance = SpawnObject(_assetProvider.AssetReferences.PlayerPrefab);

            PlayerMove playerMove = instance.GetComponent<PlayerMove>();
            playerMove.Construct(_inputService);
            playerMove.MovementSpeed = _staticDataService.PlayerStaticData.Speed;

            _playerDataHandlerService.PlayerAnimation = instance.GetComponent<PlayerAnimation>();
        }

        private GameObject SpawnObject(GameObject prefab)
        {
            GameObject instance = Object.Instantiate(prefab);

            return instance;
        }

        public void CreateMovementArea()
        {
            _movementAreaInstance = SpawnObject(_assetProvider.AssetReferences.MovementAreaPrefab);
            MovementAreaMove movementAreaMove = _movementAreaInstance.GetComponent<MovementAreaMove>();
            _movementAreaDataHandlerService.MovementAreaMove = movementAreaMove;
            movementAreaMove.Speed = _staticDataService.MovementAreaStaticData.Speed;
        }

        public GameObject SpawnPickupable(Vector3 at, PickupableTypeId spawnMarkerTypeId, GameObject spawnMarkerPrefab)
        {
            GameObject instance = SpawnObject(spawnMarkerPrefab);
            instance.transform.position = at;
            instance.transform.SetParent(_movementAreaInstance.transform);
            
            Pickupable pickupable = instance.GetComponent<Pickupable>();

            ApplyEffects();

            return instance;

            void ApplyEffects() =>
                pickupable.EffectStrategy = spawnMarkerTypeId switch
                {
                    PickupableTypeId.BoosterCoin => new BoostSpeedEffect(_movementAreaDataHandlerService),
                    PickupableTypeId.SlowDownCoin => new SlowDownSpeedEffect(_movementAreaDataHandlerService),
                    PickupableTypeId.FlyCoin => new FlyEffect(_playerDataHandlerService)
                };
        }

        public void CreateEnvironment()
        {
            GameObject instance = SpawnObject(_assetProvider.AssetReferences.EnvironmentPrefab);
            instance.transform.SetParent(_movementAreaInstance.transform);
        }
    }
}