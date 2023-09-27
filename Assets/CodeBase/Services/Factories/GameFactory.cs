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
        public GameObject MovementArea { get; private set; }
        private readonly IInputService _inputService;
        private readonly IMovementAreaDataHandler _movementAreaDataHandler;

        public GameFactory(IInputService inputService, IMovementAreaDataHandler movementAreaDataHandler)
        {
            _inputService = inputService;
            _movementAreaDataHandler = movementAreaDataHandler;
        }

        public void CreatePlayer()
        {
            var instance = SpawnObject("Player");

            PlayerMove playerMove = instance.GetComponent<PlayerMove>();
            playerMove.Construct(_inputService);
            playerMove.MovementSpeed = 2;
        }

        public void CreateMovementArea()
        {
            MovementArea = SpawnObject("MovementArea");
            _movementAreaDataHandler.MovementAreaMove = MovementArea.GetComponent<MovementAreaMove>();
        }

        public GameObject SpawnPickupable(Vector3 at, PickupableTypeId spawnMarkerTypeId)
        {
            GameObject instance = SpawnObject("Pickupable");
            instance.transform.position = at;
            instance.transform.SetParent(MovementArea.transform);
            
            Pickupable pickupable = instance.GetComponent<Pickupable>();

            switch (spawnMarkerTypeId)
            {
                case PickupableTypeId.BoosterCoin:
                    pickupable.EffectStrategy = new BoostSpeedEffect();
                    break;
                case PickupableTypeId.SlowDownCoin:
                    pickupable.EffectStrategy = new SlowDownSpeedEffect();
                    break;
                case PickupableTypeId.FlyCoin:
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