using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alerts.Models.Dama
{
    public class ARTVisitViewModel
    {
        public string BaselineCode { get; set; }
        public string Refline { get; set; }
        public DateTime? NextAppointmentDate { get; set; }
        public string PatientStatus { get; set; }
        public string Artsite { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }

        //public virtual Artbaseline BaselineCodeNavigation { get; set; }
    }

    public partial class ARTVisit
    {
        public string BaselineCode { get; set; }
        public string Refline { get; set; }
        public DateTime TransDate { get; set; }
        public string Artcode { get; set; }
        public string Tbscreening { get; set; }
        public string PrevRegimen { get; set; }
        public string PrevTreatmentLine { get; set; }
        public string TreatmentLine { get; set; }
        public string Arvregimen { get; set; }
        public string Cotrimoxazole { get; set; }
        public string PatientStatus { get; set; }
        public string PregnancyStatus { get; set; }
        public DateTime? NextAppointmentDate { get; set; }
        public string Artsite { get; set; }
        public string Artconso { get; set; }
        public string SubstitutionReason { get; set; }
        public string SessionCode { get; set; }
        public string Dstatus { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastChangeDate { get; set; }
        public bool IsDeleted { get; set; }
        public string DispensationReference { get; set; }
        public bool OfflineChangesPending { get; set; }
        public bool CloudPushPending { get; set; }
        public string Inhgiven { get; set; }
        public string LastChangedBy { get; set; }
        public string SourceSitecode { get; set; }
        public string DiedStatus { get; set; }
        public string TransferSiteCode { get; set; }
        public string TransferType { get; set; }
        public string DefaulterOutCome { get; set; }
        public string IsMultiVisit { get; set; }
        public int? NumberOfDays { get; set; }
        public string IsPregnant { get; set; }
        public string CaseManagerReference { get; set; }
        public string NurseReference { get; set; }
        public string DoctorReference { get; set; }
        public string ClientPcs { get; set; }

        public virtual Artbaseline BaselineCodeNavigation { get; set; }
    }
}
