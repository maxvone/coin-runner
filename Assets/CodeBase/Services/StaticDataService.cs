using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Services.Factories
{
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