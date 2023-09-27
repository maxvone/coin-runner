using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.Spawners
{
    
    public class PickupableSpawnMarker : MonoBehaviour
    {
        [field: SerializeField] public PickupableTypeId TypeId { get; private set; }
    }
}
