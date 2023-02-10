using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.ContextData
{
    class Donanım
    {
        public int ID { get; set; }
        public string Marka { get; set;}
        public string Model { get; set; }
        public string SeriNo { get; set; }
        public string Kategori { get; set; }
        public string ArizaAciklama { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
        public bool Modife { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public DateTime ModifeDate { get; set; }

    }
}
