
using MTAPI.Data;
using MTAPI.Data.Models;
using MTAPI.Data.UnitOfWork;
using MTAPI.Repository;
using MTAPI.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicineTrackingContext _context;
        private IRepository<Medicine> _medicineRepository;
     

        public UnitOfWork(MedicineTrackingContext context)
        {
            this._context = context;
        }
        public IRepository<Medicine> MedicineRespository => this._medicineRepository == null ? new Repository<Medicine>(this._context) : this._medicineRepository;

     

        public int Complete()
        {
            return this._context.SaveChanges();

        }

        public async Task<int> CompleteAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
