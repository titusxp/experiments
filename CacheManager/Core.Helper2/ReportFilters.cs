using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Helper2
{

    public class BaseFilter
    {
        public bool FirstAndLastMinutesOfTheDay = true;
        private DateTime _endDate;
        private DateTime _startDate;
        private string _languageId = "01";
        public DateTime StartDate
        {
            get { return FirstAndLastMinutesOfTheDay ? _startDate.FirstMinuteOfTheDay() : _startDate; }
            set { _startDate = value; }
        }
        public DateTime EndDate
        {
            get { return FirstAndLastMinutesOfTheDay ? _endDate.LastMinuteOfTheDay() : _endDate; }
            set { _endDate = value; }
        }
        public string LanguageId
        {
            get { return _languageId; }
            set { _languageId = value; }
        }
        public string GetReportYear()
        {
            return StartDate.Year == EndDate.Year
                ? StartDate.Year.ToString()
                : string.Format("{0}-{1}", StartDate.Year, EndDate.Year);
        }
        public string GetReportMonth()
        {
            if (StartDate.Year == EndDate.Year)
            {
                if (StartDate.Month == EndDate.Month)
                    return StartDate.ToMonthName(LanguageId);
                return $"{StartDate.ToMonthName(LanguageId)} - {EndDate.ToMonthName(LanguageId)}";
            }

            return $"{StartDate.ToMonthName(LanguageId)} {StartDate.Year} - {EndDate.ToMonthName(LanguageId)} {EndDate.Year}";
        }
        public string GetCutOffPeriod()
        {
            string _to;
            if (LanguageId == "01")
                _to = "TO";
            else
                _to = "À";

            return string.Concat(StartDate.ToShortDateString(), " ", _to, " ", EndDate.ToShortDateString());
        }

    }

    public class JournalFilter : ReportFilter
    {
        private int _pageNumber;
        public string JournalType { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Facility { get; set; }

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value > 0 ? value : 1; }
        }

        public int PageSize { get; set; }
        public bool GetEverything { get; set; } = false;

        public int? Skip => GetEverything ? (int?)null : (PageNumber - 1) * PageSize;

        public int? Take => GetEverything ? (int?)null : PageSize;
    }

    public class ARTOutcomeJournalFilter : JournalFilter
    {
        public string Indicator { get; set; }
    }

    public class ReportFilter : BaseFilter
    {
        private int? _minAge = 0;
        private int? _maxAge = 1000;
        private MerIndicatorVersions _merIndicatorCode = MerIndicatorVersions.NULL;
        private string _sex = "";
        private List<string> _siteCodes = new List<string>();


        public ReportFilter Clone()
        {
            var newFilter = this.Map<ReportFilter, ReportFilter>();
            return newFilter;
        }

        public virtual ArtOutcomeFilter ToArtOutcomeFilter()
        {
            try
            {
                ArtOutcomeFilter artOutcomeFilter;
                if (this is ArtOutcomeFilter)
                {
                    var filter = this as ArtOutcomeFilter;
                    artOutcomeFilter = filter.Map<ArtOutcomeFilter, ArtOutcomeFilter>();
                }
                else if (this is ARTOutcomeJournalFilter)
                {
                    var filter = this as ARTOutcomeJournalFilter;
                    artOutcomeFilter = filter.Map<ARTOutcomeJournalFilter, ArtOutcomeFilter>();
                }
                else
                {
                    var filter = Clone();
                    artOutcomeFilter = filter.Map<ReportFilter, ArtOutcomeFilter>();
                }

                artOutcomeFilter.currentQuarterStartDate =
                    artOutcomeFilter.EndDate.AddMonths(-2).FirstDayCurrentMonth().FirstMinuteOfTheDay();
                artOutcomeFilter.currentQuarterEndDate = artOutcomeFilter.EndDate.LastMinuteOfTheDay();
                artOutcomeFilter.previousQuarterEndDate =
                    artOutcomeFilter.StartDate.LastDayPreviousMonth().LastMinuteOfTheDay();
                artOutcomeFilter.previousQuarterStartDate = artOutcomeFilter.previousQuarterEndDate.AddMonths(-2)
                    .FirstDayCurrentMonth().FirstMinuteOfTheDay();
                return artOutcomeFilter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual T ToOtherFilter<T>() where T : ReportFilter, new()
        {
            try
            {
                var filter = Clone();
                return filter.Map<ReportFilter, T>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<string> SiteCodes
        {
            get { return _siteCodes; }
            set
            {
                if (value != null)
                {
                    _siteCodes = value;
                }
                else
                {
                    _siteCodes = new List<string>();
                }
            }
        }

        public string Sex
        {
            get { return _sex; }
            set
            {
                switch (value?.ToLower())
                {
                    case "01":
                    case "male":
                        _sex = "01";
                        break;

                    case "02":
                    case "female":
                        _sex = "02";
                        break;
                    default:
                        _sex = "";
                        break;
                }
            }
        }

        public int? MinAge
        {
            get { return _minAge; }
            set
            {
                if (value.HasValue && value >= 0)
                {
                    _minAge = value;
                }
            }
        }

        public int? MaxAge
        {
            get { return _maxAge; }
            set
            {
                if (value.HasValue && value <= 1000)
                {
                    _maxAge = value;
                }
            }
        }

        public MerIndicatorVersions MerIndicatorCode
        {
            get { return _merIndicatorCode; }
            set { _merIndicatorCode = value; }
        }
        public DateTime? GetMinimumDateOfBirth(DateTime? anchorDate = null)
        {
            try
            {
                return GetDateOfBirth(anchorDate, MaxAge);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DateTime? GetMaximumDateOfBirth(DateTime? anchorDate = null)
        {
            try
            {
                return GetDateOfBirth(anchorDate, MinAge);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private DateTime? GetDateOfBirth(DateTime? anchorDate, int? age)
        {
            if (age.HasValue == false)
            {
                return null;
            }

            if (anchorDate.HasValue == false)
            {
                anchorDate = DateTime.Now;
            }

            return anchorDate.Value.AddYears(age.Value * -1);
        }
        public bool IsEqualTo(ReportFilter otherFilter)
        {
            return StartDate == otherFilter.StartDate
                   && EndDate == otherFilter.EndDate
                   && MerIndicatorCode == otherFilter.MerIndicatorCode
                   && LanguageId == otherFilter.LanguageId
                   && Sex == otherFilter.Sex
                   && (MinAge.HasValue == false && otherFilter.MinAge.HasValue == false || MinAge == otherFilter.MinAge)
                   && (MaxAge.HasValue == false && otherFilter.MaxAge.HasValue == false || MaxAge == otherFilter.MaxAge)
                   && (SiteCodes.Any() == false
                        && otherFilter.SiteCodes.Any() == false
                        || SiteCodes.All(s => otherFilter.SiteCodes.Any(ss => ss == s)
                                                   && SiteCodes.Count == otherFilter.SiteCodes.Count));
        }
    }

    public class ArtOutcomeFilter : ReportFilter
    {
        public DateTime currentQuarterStartDate { get; set; }
        public DateTime currentQuarterEndDate { get; set; }
        //public DateTime previousPeriodEndDate { get; set; }
        //public DateTime previousPeriodstartDate { get; set; }
        public DateTime previousQuarterEndDate { get; set; }
        public DateTime previousQuarterStartDate { get; set; }

        public override ArtOutcomeFilter ToArtOutcomeFilter()
        {
            try
            {
                var artOutcomeFilter = this.Map<ArtOutcomeFilter, ArtOutcomeFilter>();

                artOutcomeFilter.currentQuarterStartDate =
                    artOutcomeFilter.EndDate.AddMonths(-2).FirstDayCurrentMonth().FirstMinuteOfTheDay();
                artOutcomeFilter.currentQuarterEndDate = artOutcomeFilter.EndDate.LastMinuteOfTheDay();
                artOutcomeFilter.previousQuarterEndDate =
                    artOutcomeFilter.StartDate.LastDayPreviousMonth().LastMinuteOfTheDay();
                artOutcomeFilter.previousQuarterStartDate = artOutcomeFilter.previousQuarterEndDate.AddMonths(-2)
                    .FirstDayCurrentMonth().FirstMinuteOfTheDay();
                return artOutcomeFilter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ReportFilter PreviousQuarterFilter()
        {
            var newFilter = this.Map<ArtOutcomeFilter, ReportFilter>();
            newFilter.StartDate = previousQuarterStartDate;
            newFilter.EndDate = previousQuarterEndDate;
            return newFilter;
        }
        public ReportFilter CurrentsQuarterFilter()
        {
            var newFilter = this.Map<ArtOutcomeFilter, ReportFilter>();
            newFilter.StartDate = currentQuarterStartDate;
            newFilter.EndDate = currentQuarterEndDate;
            return newFilter;
        }
        public ReportFilter LTFUMonth2Filter()
        {
            var newFilter = this.Map<ArtOutcomeFilter, ReportFilter>();
            newFilter.StartDate = ltfuM2StartDate;
            newFilter.EndDate = ltfuM2EndDate;
            return newFilter;
        }
        public ReportFilter LTFUMonth3Filter()
        {
            var newFilter = this.Map<ArtOutcomeFilter, ReportFilter>();
            newFilter.StartDate = ltfuM3StartDate;
            newFilter.EndDate = ltfuM3EndDate;
            return newFilter;
        }


        public ReportFilter OnTreatmentAfterSecondDefaulterFilter()
        {
            var newFilter = this.Map<ArtOutcomeFilter, ReportFilter>();
            newFilter.StartDate = onTreatmentAfterSecondDefaultingStartDate;
            newFilter.EndDate = onTreatmentAfterSecondDefaultingEndDate;
            return newFilter;
        }
        public ReportFilter SecondDefaulterCurrentQuarterFilter()
        {
            var newFilter = this.Map<ArtOutcomeFilter, ReportFilter>();
            newFilter.StartDate = secondDefaultersCurrentQuarterStartDate;
            newFilter.EndDate = currentQuarterEndDate;
            return newFilter;
        }


        public ReportFilter SecondDefaulterPreviousQuarterFilter()
        {
            var newFilter = this.Map<ArtOutcomeFilter, ReportFilter>();
            newFilter.StartDate = secondDefaultersPreviousQuarterStartDate;
            newFilter.EndDate = previousQuarterEndDate;
            return newFilter;
        }


        /// <summary>
        /// <param name="onTreatmentAfterSecondDefaultingStartDate"></param>
        /// <param name="onTreatmentAfterSecondDefaultingEndDate"></param>
        /// !Important-
        /// Avoid changing the date. This property are being configured in the code 
        /// that generates the data patients on treatment after defaulting twice.
        /// </summary>
        public DateTime onTreatmentAfterSecondDefaultingStartDate => StartDate.FirstDayCurrentMonth().FirstMinuteOfTheDay();

        public DateTime onTreatmentAfterSecondDefaultingEndDate => EndDate.LastDayCurrentMonth().LastMinuteOfTheDay();

        public DateTime ltfuM2StartDate => currentQuarterEndDate.AddMonths(-1).FirstDayCurrentMonth().FirstMinuteOfTheDay();

        public DateTime ltfuM2EndDate =>
            currentQuarterEndDate.AddMonths(-1).LastDayCurrentMonth().LastMinuteOfTheDay();

        public DateTime ltfuM3StartDate => currentQuarterEndDate.FirstDayCurrentMonth().FirstMinuteOfTheDay();

        public DateTime ltfuM3EndDate =>
            currentQuarterEndDate.LastDayCurrentMonth().LastMinuteOfTheDay();

        public DateTime secondDefaultersCurrentQuarterStartDate => currentQuarterStartDate
            .FirstDayCurrentMonth().FirstMinuteOfTheDay();
        public DateTime secondDefaultersPreviousQuarterStartDate => previousQuarterStartDate
            .FirstDayCurrentMonth().FirstMinuteOfTheDay();
    }

    public class SalvageDispensationFilter : ReportFilter
    {
        public string RegionFrom { get; set; }
        public string DistrictFrom { get; set; }
        public string FacilityFrom { get; set; }
        public string RegionTo { get; set; }
        public string DistrictTo { get; set; }
        public string FacilityTo { get; set; }
    }

    public class StockMovementFromOneFacilityToAnotherFilter : ReportFilter
    {
        public string SourceSite { get; set; }
        public string DestinationSite { get; set; }
        public string DoneBy { get; set; }
        public string ToggleValue { get; set; }
    }

    public class BaseFilterWithMERIndicator : ReportFilter
    {
        public MerIndicatorVersions MERIndicatorVersion { get; set; }
    }

    public class StockAdjustmentFilter : ReportFilter
    {
        public string DoneBy { get; set; }
    }

    public class DatimEntryPointFilter : ReportFilter
    {
        public string SelectedIndicator { get; set; }
    }

}
