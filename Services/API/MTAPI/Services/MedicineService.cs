using AutoMapper;
using AutoMapper.Configuration.Conventions;
using MTAPI.Data.Models;
using MTAPI.Data.UnitOfWork;
using MTAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTAPI.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public List<MedicineView> GetAllMedicines()
        {
            var medicineLst =  this._unitOfWork.MedicineRespository.GetAll();
            return this._mapper.Map<List<MedicineView>>(medicineLst);
        }

        public async Task<MedicineViewWithNotes> GetMedicineByKeyAsync(int id)
        {
            var medicine = await this._unitOfWork.MedicineRespository.GetByKeyAsync(id);
            return this._mapper.Map<MedicineViewWithNotes>(medicine);
        }

        public  int SaveMedicineDetails(MedicineViewWithNotes mvWithNotes)
        {
            var medicine = this._mapper.Map<Medicine>(mvWithNotes);
            this._unitOfWork.MedicineRespository.AddAsync(medicine);
            return this._unitOfWork.Complete();
            
        }

        public async Task<int> UpdateMedicineDetails(MedicineViewWithNotes mvWithNotes)
        {
            var medicine = await this._unitOfWork.MedicineRespository.GetByKeyAsync(mvWithNotes.Id);
            medicine.Brand = mvWithNotes.Brand;
            medicine.ExpiryDate = mvWithNotes.ExpiryDate;
            medicine.Name = mvWithNotes.Name;
            medicine.Notes = mvWithNotes.Notes;
            medicine.Price = mvWithNotes.Price;
            medicine.Quantity = mvWithNotes.Quantity;

           return await this._unitOfWork.CompleteAsync();
        }
    }
}
