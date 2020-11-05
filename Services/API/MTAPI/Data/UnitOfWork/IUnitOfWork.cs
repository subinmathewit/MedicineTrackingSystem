
using MTAPI.Data.Models;
using MTAPI.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTAPI.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Medicine> MedicineRespository { get; } 
       
        int Complete();
        Task<int> CompleteAsync();
    }
}
