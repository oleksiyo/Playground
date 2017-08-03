using System;

namespace CQRSDemoApp.Command.InventoryCommands
{
   public class CreateInventory: ICommand
    {
        public Guid Id { get; }
        public string Name { get; }

        public CreateInventory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}