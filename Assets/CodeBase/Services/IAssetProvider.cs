using CodeBase.StaticData.Levels;

namespace CodeBase.Services
{
    public interface IAssetProvider : IService
    {
        AssetsReferences AssetReferences { get; }
    }
}