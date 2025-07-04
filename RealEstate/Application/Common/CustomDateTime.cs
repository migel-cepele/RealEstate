namespace RealEstate.API.Application.Common
{
    public static class CustomDateTime
    {
        /// <summary>
        /// Gets the current DateTime in the specified timezone.
        /// </summary>
        /// <param name="timeZoneId">The timezone ID (e.g., "Central European Standard Time", "UTC", "Eastern Standard Time").</param>
        /// <returns>DateTime in the specified timezone.</returns>
        public static DateTime GetNow(string timeZoneId = "Central European Standard Time")
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        }
    }
}
