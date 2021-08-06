using Domain.Entities;
using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Managers
{
    public interface IInventoryManager : IBaseManager<Inventory>
    {

    }

    public class InventoryManager : BaseManager<Inventory>, IInventoryManager
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryManager(IInventoryRepository inventoryRepository, IMapper mapper) : base(inventoryRepository, mapper)
        {
            _inventoryRepository = inventoryRepository;
        }
    }
}
