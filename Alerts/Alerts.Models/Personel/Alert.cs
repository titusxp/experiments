using System;
using System.Collections.Generic;
using System.Text;

namespace Alerts.Models.Personel
{
    public partial class Alert
    {
        public string Reference { get; set; }
        public string Refline { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Provider { get; set; }
        public string Subject { get; set; }
        public string Bodyemail { get; set; }
        public string Bodysms { get; set; }
        public DateTime Expiration { get; set; }
        public string Estatus { get; set; }
        public DateTime? Edate { get; set; }
        public string Etime { get; set; }
        public string Sstatus { get; set; }
        public DateTime? Sdate { get; set; }
        public string Stime { get; set; }
        public string Atype { get; set; }
    }
}
