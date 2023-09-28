using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.Spawners
{
    /// <summary>
    /// This class is responsible for setting information about pickupables on the scene.
    /// This markers are being collected by static data
    /// </summary>
    public class PickupableSpawnMarker : MonoBehaviour
    {
        [field: SerializeField] public PickupableTypeId TypeId { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}
