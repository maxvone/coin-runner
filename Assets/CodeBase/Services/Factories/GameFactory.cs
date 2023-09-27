using CodeBase.Player;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Services.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IInputService _inputService;

        public GameFactory(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void CreatePlayer()
        {
            var playerPrefab = Resources.Load<GameObject>("Player");
            GameObject playerInstance = Object.Instantiate(playerPrefab);
            
            PlayerMove playerMove = playerInstance.GetComponent<PlayerMove>();
            playerMove.Construct(_inputService);
            playerMove.MovementSpeed = 2;
        }
    }
}