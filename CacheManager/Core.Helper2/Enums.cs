

namespace Core.Helper2
{
    public enum MerIndicatorVersions
    {
        NULL = 0,
        MER_2_0 = 1,
        MER_2_3 = 2,
    }

    public enum ReportStatus
    {
        Completed,
        InProgress,
        Error
    }


    public enum ReportTypes
    {
        Dashboard,
        PerformanceDashboard,
        TX_NEW_CURR,
        HTC_MOH,
        PMTCT_MOH,
        GlobalManagement,
        PatientsByProtocole,
        PatientsOnTreatment_MOH,
        HTS_Standard_Entry_Point,
        HTS_DATIM_Entry_Point,
        HTS_Facility_Entry_Point,
        PMTCT_STAT,
        PMTCT_EID_HEI_POS,
        TB_STAT,
        PMTCT_ART,
        TB_ART,
        TX_TB,
        ART_OUTCOME,
        SITE_ARCHEIVEMENTS,
        SITE_ARCHEIVEMENTS_By_Age_And_SEX,
        ART_OUTCOMEBYSITE,
        TX_ML,
        TX_RET,
        TX_PVLS,
        HTS_Index_Datim,
        HTS_Index_Facility,
        TX_CURR_Comparison,
        VoucherInitiative,
        NinetyNinetyNinety,
        ARTAppointment,
        HomeDashboard,
        ArtAppointmentBySite,
        PatientTrackingReport,
        TargetAchievementReport,
        HTSByDatimEntryPointReport,
        StaffPerformanceReport,
        TX_RTT
    }
}
