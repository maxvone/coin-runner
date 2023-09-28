using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Static Data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public List<PickupableSpawnerStaticData> PickupablesSpawners;
    }
}