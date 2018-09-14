//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Threading;
//using System.Threading.Tasks;
//using EventFlow.Aggregates;
//using EventFlow.ReadStores;
//using EventFlow.ReadStores.InMemory;
//using Simulator.Query;

//namespace Simulator.Tests
//{
//    public sealed class TestReadStore<TReadModel> : Ireadsto<TReadModel>
//        where TReadModel : class, IVersionedReadModel, new()
//    {
//        private readonly InMemoryReadStore<TReadModel> inner;

//        public TestReadStore(InMemoryReadStore<TReadModel> inner)
//        {
//            this.inner = inner;
//        }

//        public Task DeleteAllAsync(CancellationToken cancellationToken)
//        {
//            return inner.DeleteAllAsync(cancellationToken);
//        }

//        public Task DeleteAsync(string id, CancellationToken cancellationToken)
//        {
//            return inner.DeleteAsync(id, cancellationToken);
//        }

//        public Task<ReadModelEnvelope<TReadModel>> GetAsync(string id, CancellationToken cancellationToken)
//        {
//            return inner.GetAsync(id, cancellationToken);
//        }

//        public async Task UpdateAsync(IReadOnlyCollection<ReadModelUpdate> readModelUpdates,
//            IReadModelContextFactory readModelContextFactory,
//            Func<IReadModelContext, IReadOnlyCollection<IDomainEvent>, ReadModelEnvelope<TReadModel>, CancellationToken,
//                Task<ReadModelUpdateResult<TReadModel>>> updateReadModel, CancellationToken cancellationToken)
//        {
//            inner.UpdateAsync(readModelUpdates, readModelContextFactory, updateReadModel, cancellationToken);
//        }

//        public Task<IReadOnlyCollection<TReadModel>> FindAsync(
//            Expression<Func<TReadModel, bool>> predicate,
//            CancellationToken cancellationToken)
//        {
//            return inner.FindAsync(r => predicate.Compile()(r), cancellationToken);
//        }
//    }
//}