using System.Collections.Generic;
using CQRSDemoApp;
using CQRSDemoApp.Command;
using CQRSDemoApp.Dtos;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

namespace CQRSDemoAppTests
{
   public class MemoryRepositoryTests
   {
       private MemoryRepository<Inventory> memoryRepository;

       public MemoryRepositoryTests()
       {
           memoryRepository = new MemoryRepository<Inventory>();
       }
            
        [Theory, AutoMoqData]
        public void should_add_items_to_repo(
            Inventory i,
            Inventory i1,
            [Frozen] ICommand c)
        {
            memoryRepository.Add(i);
            memoryRepository.Add(i1);

           var values = memoryRepository.GetAll();

            values.ShouldAllBeEquivalentTo(new List<Inventory> {i, i1});
        }
    }
}