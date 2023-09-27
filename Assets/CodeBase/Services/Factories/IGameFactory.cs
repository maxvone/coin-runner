using UnityEngine;

namespace CodeBase.Services.Factories
{
    public interface IGameFactory : IService
    {
        void CreatePlayer();
        void CreateMovementArea();
        GameObject SpawnPickupable();
    }
}