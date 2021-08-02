using Domain.Entities;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Managers
{
    public interface IInventoryManager : IBaseManager<Inventory>
    {

    }

    public class InventoryManager : BaseManager<Inventory>, IInventoryManager
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryManager(IInventoryRepository inventoryRepository) : base(inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
    }
}
