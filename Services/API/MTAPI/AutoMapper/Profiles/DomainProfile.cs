using AutoMapper;
using MTAPI.Data.Models;
using MTAPI.ViewModel;

namespace MTAPI.AutoMapper.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<MedicineView, Medicine>();
            CreateMap<Medicine, MedicineView>();
           
        }
    }
}
