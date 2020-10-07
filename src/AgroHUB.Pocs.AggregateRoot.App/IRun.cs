using System.Threading.Tasks;

namespace AggregateRoot.App
{
    public interface IRunner
    {
        Task Run();
    }
}