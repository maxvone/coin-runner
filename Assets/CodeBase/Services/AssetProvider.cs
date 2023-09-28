using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Services
{
    public class AssetProvider : IAssetProvider
    {
        public AssetsReferences AssetReferences { get; }

        public AssetProvider() => 
            AssetReferences = Resources.Load<AssetsReferences>("StaticData/AssetReferences");
    }
}