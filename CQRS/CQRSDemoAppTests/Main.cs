using System;
using System.Linq;
using CQRSDemoApp;
using CQRSDemoApp.Command;
using CQRSDemoApp.Command.InventoryCommands;
using CQRSDemoApp.Dtos;
using FluentAssertions;
using SimpleInjector;
using Xunit;

namespace CQRSDemoAppTests
{
    public class Main
    {
        private readonly Container resolver;

        public Main()
        {
            resolver = Resolver.Bootstrap();
        }

        [Fact]
        public void should_add_new_inventory()
        {
            ICommandDispatcher dispatcher = resolver.GetInstance<ICommandDispatcher>();
            var command = new CreateInventory(Guid.NewGuid(), "new inv");

            // Act
            dispatcher.Execute(command);

            var repository = new MemoryRepository<Inventory>();
            var inv = repository.GetAll();
            inv.First().ShouldBeEquivalentTo(new Inventory {Id = command.Id, Name = command.Name});
        }
    }
}
