using System;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    /// <summary>
    /// This class contains information about spawn markers on the scene.
    /// </summary>
    [Serializable]
    public class PickupableSpawnerStaticData
    {
        public Vector3 Position;
        public PickupableTypeId TypeId;
        public GameObject Prefab;

        public PickupableSpawnerStaticData(PickupableTypeId typeId, Vector3 position, GameObject prefab)
        {
            TypeId = typeId;
            Position = position;
            Prefab = prefab;
        }
    }
}