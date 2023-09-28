using CodeBase.MovementArea;

namespace CodeBase.Services
{
    public interface IMovementAreaDataHandlerService : IService
    {
        MovementAreaMove MovementAreaMove { get; set; }
    }
}