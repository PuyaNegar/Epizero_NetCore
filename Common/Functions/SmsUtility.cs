using System;

namespace Common.Functions
{
    public static class SmsUtility
    {
        public static long TimeStampSeconds => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

        public static long TimeStampMilliseconds => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

        public static string GetBase64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
