using CodeBase.Player;

namespace CodeBase.Services.Factories
{
    public interface IMovementAreaDataHandler : IService
    {
        MovementAreaMove MovementAreaMove { get; set; }
    }
}