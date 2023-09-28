using System.Collections.Generic;
using System.Linq;
using CodeBase.Services.Factories;
using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Services
{
    /// <summary>
    /// Service responsible for Loading Level static data such as:
    /// - Pickupables positions
    /// Game was oriented for manual level creation. So this the place to keep static data about the level
    /// </summary>
    public class StaticDataService : IStaticDataService
    {
        private const string LevelsDataPath = "StaticData/Levels";

        private Dictionary<string, LevelStaticData> _levels;

        public void Load()
        {
            _levels = Resources
                .LoadAll<LevelStaticData>(LevelsDataPath)
                .ToDictionary(x => x.LevelKey, x => x);
        }

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;
    }
}