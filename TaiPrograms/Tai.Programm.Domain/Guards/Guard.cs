namespace TaiProgramms.Guards
{
    internal class Guard
    {
        public static void CheckStringOnNullOrEmptyOrWhiteSpaseOnly(string input, string exceptionMessage)
        {
            if(string.IsNullOrWhiteSpace(input))
                throw new Exception(exceptionMessage);
        }
    }
}
