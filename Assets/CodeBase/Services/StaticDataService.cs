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
    /// - Player Speed
    /// - Movement Area Speed
    /// Game was oriented for manual level creation. So this the place to keep static data about the level
    /// </summary>
    public class StaticDataService : IStaticDataService
    {
        private const string LevelsDataPath = "StaticData/Levels";
        private const string PlayerDataPath = "StaticData/PlayerData";
        private const string MovementAreaDataPath = "StaticData/MovementAreaData";

        private Dictionary<string, LevelStaticData> _levels;
        public PlayerStaticData PlayerStaticData { get; private set; }
        public MovementAreaStaticData MovementAreaStaticData { get; private set; }

        public void Load()
        {
            _levels = Resources
                .LoadAll<LevelStaticData>(LevelsDataPath)
                .ToDictionary(x => x.LevelKey, x => x);

            PlayerStaticData = Resources.Load<PlayerStaticData>(PlayerDataPath);
            MovementAreaStaticData = Resources.Load<MovementAreaStaticData>(MovementAreaDataPath);
        }

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;
    }
}