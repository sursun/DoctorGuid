using Gms.Domain;

namespace Gms.Infrastructure
{
    public interface ITerminalRepository : IRepositoryBase<Terminal>
    {
        Terminal GetBy(string mac);
    }
}
