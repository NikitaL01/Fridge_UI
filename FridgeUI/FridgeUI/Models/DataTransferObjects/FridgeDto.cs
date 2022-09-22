using System;

namespace FridgeUI.Models.DataTransferObjects
{
    public class FridgeDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? OwnerName { get; set; }
    }
}
