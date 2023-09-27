using System;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [Serializable]
    public class PickupableSpawnerStaticData
    {
        public Vector3 Position;
        public PickupableTypeId TypeId;

        public PickupableSpawnerStaticData(PickupableTypeId typeId, Vector3 position)
        {
            TypeId = typeId;
            Position = position;
        }
    }
}