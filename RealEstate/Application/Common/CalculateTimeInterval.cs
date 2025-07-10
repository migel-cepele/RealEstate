using RealEstate.API.Application.Common.Constants;

namespace RealEstate.API.Application.Common
{
    public class CalculateTimeInterval
    {
        public DateTime StartDateTime {  get; set; }
        public DateTime EndDateTime { get; set; }

        public void Calculate(string timeInterval)
        {
            var now = CustomDateTime.GetNow();
            switch (timeInterval)
            {
                case var t when t == TimeIntervals.Today:
                    StartDateTime = now.Date;
                    EndDateTime = now;
                    break;
                case var t when t == TimeIntervals.Last24Hours:
                    StartDateTime = now.AddHours(-24);
                    EndDateTime = now;
                    break;
                case var t when t == TimeIntervals.Last3Days:
                    StartDateTime = now.AddDays(-3);
                    EndDateTime = now;
                    break;
                case var t when t == TimeIntervals.LastWeek:
                    StartDateTime = now.AddDays(-7);
                    EndDateTime = now;
                    break;
                case var t when t == TimeIntervals.LastMonth:
                    StartDateTime = now.AddMonths(-1);
                    EndDateTime = now;
                    break;
                case var t when t == TimeIntervals.LastYear:
                    StartDateTime = now.AddYears(-1);
                    EndDateTime = now;
                    break;
                case var t when t == TimeIntervals.Last5Years:
                    StartDateTime = now.AddYears(-5);
                    EndDateTime = now;
                    break;
                default:
                    StartDateTime = now;
                    EndDateTime = now;
                    break;
            }
        }
    }
}
