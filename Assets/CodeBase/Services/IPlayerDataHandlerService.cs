using CodeBase.Player;

namespace CodeBase.Services
{
    public interface IPlayerDataHandlerService : IService
    {
        PlayerAnimation PlayerAnimation { get; set; }
    }
}