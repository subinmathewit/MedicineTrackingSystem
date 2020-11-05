using MTAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTAPI.Services
{
    public interface IMedicineService
    {
        public List<MedicineView> GetAllMedicines();
        public Task<MedicineViewWithNotes> GetMedicineByKeyAsync(int id);
        public int SaveMedicineDetails(MedicineViewWithNotes mvWithNotes);
        public Task<int> UpdateMedicineDetails(MedicineViewWithNotes mvWithNotes);
    }
}
