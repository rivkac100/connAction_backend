using Dal.Models;


//בס"ד

namespace BL.Models
{
    public class BlActivity
    {
   
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }

        public string ActivityDescription { get; set; } = null!;

        public double LenOfActivity { get; set; }

        public string? Location { get; set; }

        public int Price { get; set; }

        public int NightPrice { get; set; }

        public int ManagerId { get; set; }

        public string ImgPath { get; set; }
      

        //public virtual Manager Manager { get; set; } = null!;
        public List<BlOrder> Orders { get; set; } = new List<BlOrder>();
    }
}
