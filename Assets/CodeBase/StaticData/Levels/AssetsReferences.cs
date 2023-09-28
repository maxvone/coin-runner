using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [CreateAssetMenu(fileName = "AssetReferences", menuName = "Static Data/AssetReferences")]
    public class AssetsReferences : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public GameObject PickupablePrefab;
        public GameObject MovementAreaPrefab;
    }
}