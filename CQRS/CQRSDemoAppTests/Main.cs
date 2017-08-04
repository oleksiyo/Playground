using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSDemoApp;
using CQRSDemoApp.Command;
using CQRSDemoApp.Command.InventoryCommands;
using CQRSDemoApp.Dtos;
using Xunit;

namespace CQRSDemoAppTests
{
   public class Main
    {

       public Main()
       {

       }
       [Fact]
       public void FactMethodName()
       {

            DependencyResolver resolver = new DependencyResolver();


            ICommandDispatcher dispatcher = resolver.Resolve<ICommandDispatcher>();
            var command = new CreateInventory(Guid.NewGuid(), "new inv");
            dispatcher.Execute(command);


            var repository = new MemoryRepository<Inventory>();

             var inv =  repository.GetAll();

       }
    }
}
