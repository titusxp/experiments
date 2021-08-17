using System;
using System.Collections.Generic;

namespace Alerts.Models.Dama
{
    public partial class Artbaseline
    {
        public Artbaseline()
        {
            ARTVisit = new HashSet<ARTVisit>();
        }

        public string Reference { get; set; }
        public DateTime EnrollentDate { get; set; }
        public string Artcode { get; set; }
        public string ExistingArtcode { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? ArtstartDate { get; set; }
        public string EligibilityCriteria { get; set; }
        public string Address { get; set; }
        public string Profession { get; set; }
        public string ContactPerson { get; set; }
        public string ContactTelephone { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Bmi { get; set; }
        public string ClinicalStage { get; set; }
        public string Cd4 { get; set; }
        public string PregnancyAge { get; set; }
        public string Child { get; set; }
        public string FeedingOption { get; set; }
        public string Tbscreening { get; set; }
        public DateTime? InhstartDate { get; set; }
        public DateTime? InhstopDate { get; set; }
        public DateTime? TbtheraphyStartDate { get; set; }
        public DateTime? TbtheraphyStopDate { get; set; }
        public string ViralHepatites { get; set; }
        public string ViralHepatitesType { get; set; }
        public string Artsite { get; set; }
        public string Artconso { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastChangeDate { get; set; }
        public DateTime? Cd4date { get; set; }
        public bool IsDeleted { get; set; }
        public string TestedInThisFacility { get; set; }
        public DateTime? DateOfTest { get; set; }
        public bool IsTransferredIn { get; set; }
        public bool OfflineChangesPending { get; set; }
        public bool CloudPushPending { get; set; }
        public string RegisterCode { get; set; }
        public string LastChangedBy { get; set; }
        public string CaseManagerCode { get; set; }
        public string BarCode { get; set; }
        public string Kptype { get; set; }
        public string UniqueHospitalCode { get; set; }
        public string WasPatientRetested { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string ClientPcs { get; set; }
        public string ApsStaffCode { get; set; }
        public bool IsPregnant { get; set; }

        public virtual ICollection<ARTVisit> ARTVisit { get; set; }
    }
}
