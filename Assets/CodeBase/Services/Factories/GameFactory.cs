using CodeBase.Player;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Services.Factories
{
    public class GameFactory : IGameFactory
    {
        public GameObject MovementArea { get; private set; }
        private readonly IInputService _inputService;

        public GameFactory(IInputService inputService)
        {
            _inputService = inputService;
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
        }

        public GameObject SpawnPickupable()
        {
            GameObject instance = SpawnObject("Pickupable");
            instance.transform.SetParent(MovementArea.transform);

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