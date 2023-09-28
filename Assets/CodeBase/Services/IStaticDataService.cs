using CodeBase.StaticData.Levels;

namespace CodeBase.Services.Factories
{
    public interface IStaticDataService : IService
    {
        void Load();
        LevelStaticData ForLevel(string sceneKey);
        PlayerStaticData PlayerStaticData { get; }
        MovementAreaStaticData MovementAreaStaticData { get; }
    }
}