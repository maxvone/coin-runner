using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Services
{
    /// <summary>
    /// This Service is responsible for Keeping references to the game prefabs such as:
    /// - Player
    /// - Pickupable
    /// - Movement Area
    /// </summary>
    public class AssetProvider : IAssetProvider
    {
        public AssetsReferences AssetReferences { get; }

        public AssetProvider() => 
            AssetReferences = Resources.Load<AssetsReferences>("StaticData/AssetReferences");
    }
}