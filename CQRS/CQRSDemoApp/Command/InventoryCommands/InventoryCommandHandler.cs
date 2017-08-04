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
            throw new NotImplementedException();
        }

        public void Execute(DeleteInventory command)
        {
            throw new NotImplementedException();
        }
    }
}