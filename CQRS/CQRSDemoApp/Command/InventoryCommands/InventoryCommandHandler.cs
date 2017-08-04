using System;
using CQRSDemoApp.Dtos;

namespace CQRSDemoApp.Command.InventoryCommands
{
    public class InventoryCommandHandler : 
        ICommandHandler<CreateInventory>,
        ICommandHandler<DeleteInventory>
    {
        private readonly IRepository<Inventory> repository;

        public InventoryCommandHandler(IRepository<Inventory> repository)
        {
            this.repository = repository;
        }

        public void Execute(CreateInventory command)
        {
            var item = new Inventory {Id = command.Id,  Name = command.Name};
            repository.Add(item);
        }

        public void Execute(DeleteInventory command)
        {
            throw new NotImplementedException();
        }
    }
}