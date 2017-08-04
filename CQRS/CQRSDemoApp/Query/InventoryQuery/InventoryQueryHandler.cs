using System.Linq;
using CQRSDemoApp.Dtos;

namespace CQRSDemoApp.Query.InventoryQuery
{
  public class InventoryQueryHandler : IQueryHandler<FindInventoryByNameQuery, Inventory[]>
    {
        private readonly IRepository<Inventory> repository;

        public InventoryQueryHandler(IRepository<Inventory> repository)
        {
            this.repository = repository;
        }

        public Inventory[] Execute(FindInventoryByNameQuery query)
        {
            var users = repository.GetAll();
            return users
                .Where(user => user.Name.Contains(query.SearchName)).ToArray();
        }
    }
}