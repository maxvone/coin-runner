using CodeBase.Pickupables.Coins;
using CodeBase.Pickupables.Effects;
using CodeBase.Player;
using CodeBase.Services.Input;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Services.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IInputService _inputService;
        private readonly IMovementAreaDataHandlerService _movementAreaDataHandlerService;
        private readonly IPlayerDataHandlerService _playerDataHandlerService;
        private readonly IAssetProvider _assetProvider;

        private GameObject _movementAreaInstance; 

        public GameFactory(IInputService inputService, IMovementAreaDataHandlerService movementAreaDataHandlerService,
            IPlayerDataHandlerService playerDataHandlerService, IAssetProvider assetProvider)
        {
            _inputService = inputService;
            _movementAreaDataHandlerService = movementAreaDataHandlerService;
            _playerDataHandlerService = playerDataHandlerService;
            _assetProvider = assetProvider;
        }

        public void CreatePlayer()
        {
            var instance = SpawnObject(_assetProvider.AssetReferences.PlayerPrefab);

            PlayerMove playerMove = instance.GetComponent<PlayerMove>();
            playerMove.Construct(_inputService);
            playerMove.MovementSpeed = 2;

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
            
            _movementAreaDataHandlerService.MovementAreaMove = _movementAreaInstance.GetComponent<MovementAreaMove>();
        }

        public GameObject SpawnPickupable(Vector3 at, PickupableTypeId spawnMarkerTypeId)
        {
            GameObject instance = SpawnObject(_assetProvider.AssetReferences.PickupablePrefab);
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

    }
}