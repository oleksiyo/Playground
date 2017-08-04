using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSDemoApp.Dtos;

namespace CQRSDemoApp.Query.InventoryQuery
{
   public class FindInventoryByNameQuery : IQuery<Inventory[]>
    {
       public string SearchName { get; }

       public FindInventoryByNameQuery(string name)
       {
           SearchName = name;
       }

    }
}