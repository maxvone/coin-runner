using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    /// <summary>
    /// This class contains static data about level:
    /// - Level Key (Which is the scene name in this project)
    /// - Pickupables Spawners data like type and position
    /// </summary>
    [CreateAssetMenu(fileName = "LevelData", menuName = "Static Data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public List<PickupableSpawnerStaticData> PickupablesSpawners;
    }
}