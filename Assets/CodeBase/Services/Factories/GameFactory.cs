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
        
        private GameObject _movementAreaInstance; 

        public GameFactory(IInputService inputService, IMovementAreaDataHandlerService movementAreaDataHandlerService,
            IPlayerDataHandlerService playerDataHandlerService)
        {
            _inputService = inputService;
            _movementAreaDataHandlerService = movementAreaDataHandlerService;
            _playerDataHandlerService = playerDataHandlerService;
        }

        public void CreatePlayer()
        {
            var instance = SpawnObject("Player");

            PlayerMove playerMove = instance.GetComponent<PlayerMove>();
            playerMove.Construct(_inputService);
            playerMove.MovementSpeed = 2;

            _playerDataHandlerService.PlayerAnimation = instance.GetComponent<PlayerAnimation>();
        }

        public void CreateMovementArea()
        {
            _movementAreaInstance = SpawnObject("MovementArea");
            _movementAreaDataHandlerService.MovementAreaMove = _movementAreaInstance.GetComponent<MovementAreaMove>();
        }

        public GameObject SpawnPickupable(Vector3 at, PickupableTypeId spawnMarkerTypeId)
        {
            GameObject instance = SpawnObject("Pickupable");
            instance.transform.position = at;
            instance.transform.SetParent(_movementAreaInstance.transform);
            
            Pickupable pickupable = instance.GetComponent<Pickupable>();

            switch (spawnMarkerTypeId)
            {
                case PickupableTypeId.BoosterCoin:
                    pickupable.EffectStrategy = new BoostSpeedEffect(_movementAreaDataHandlerService);
                    break;
                case PickupableTypeId.SlowDownCoin:
                    pickupable.EffectStrategy = new SlowDownSpeedEffect(_movementAreaDataHandlerService);
                    break;
                case PickupableTypeId.FlyCoin:
                    pickupable.EffectStrategy = new FlyEffect(_playerDataHandlerService);
                    break;
            }

            return instance;
        }

        public GameObject SpawnObject(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            GameObject instance = Object.Instantiate(prefab);

            return instance;
        }
    }
}