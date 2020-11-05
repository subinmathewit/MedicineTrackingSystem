using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTAPI.ViewModel
{
   
    public class MedicineView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; } 
            
    }

    public class MedicineViewWithNotes:MedicineView
    {
        public string Notes { get; set; }
    }
}
