using System;

namespace CQRSDemoApp.Command.InventoryCommands
{
   public class DeleteInventory: ICommand
    {
       public Guid Id { get; }

       public DeleteInventory(Guid id)
       {
           Id = id;
       }
    }
}