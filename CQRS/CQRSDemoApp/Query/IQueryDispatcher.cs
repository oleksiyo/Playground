using System;
using SimpleInjector;

namespace CQRSDemoApp.Query
{
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }

    public class QueryDispatcher : IQueryDispatcher
    {
        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var resolver = Resolver.Bootstrap();

            if (query == null)
                throw new ArgumentNullException("query");

            var handler = resolver.GetInstance<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
                throw new NullReferenceException("not found");

            return handler.Execute(query);
        }

    }
}