namespace Tai.Authentications.Guards
{
    internal static class Guard
    {
        internal static string CheckStringValueOnNullEmptyAndWhiteSpace(string input, string exceptionMessage)
            => string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)
                ? throw new Exception(exceptionMessage)
                : input;

        internal static void CheckStringOnNullEmptyAndWhiteSpace(string input, string exceptionMessage)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                throw new Exception(exceptionMessage);
        }

        internal static void CheckForPasswordLength(string password, string message)
        {
            if(password.Length < 8)
                throw new Exception(message);
        }

        internal static DateTime CheckForCorrectDate(this DateTime createDate, DateTime input, string message)
            => createDate > input
                ? throw new Exception(message)
                : input; 

        internal static DateTime CheckForNullInDate(this DateTime? input)
            => input.HasValue 
                ? input.Value 
                : throw new Exception("Пустая дата.");
    }
}
