using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    /// <summary>
    /// This class is responsible for keeping references of prefabs in the scriptable object
    /// </summary>
    [CreateAssetMenu(fileName = "AssetReferences", menuName = "Static Data/AssetReferences")]
    public class AssetsReferences : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public GameObject PickupablePrefab;
        public GameObject MovementAreaPrefab;
    }
}