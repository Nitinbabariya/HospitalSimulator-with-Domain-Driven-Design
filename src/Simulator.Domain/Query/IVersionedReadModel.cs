using EventFlow.ReadStores;

namespace Simulator.Query
{
    public interface IVersionedReadModel : IReadModel
    {
        string Id { get; }
        long? Version { get; set; }
    }
}