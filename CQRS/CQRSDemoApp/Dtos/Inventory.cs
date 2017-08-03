using System;

namespace CQRSDemoApp.Dtos
{
    public class Inventory: IIdentity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}