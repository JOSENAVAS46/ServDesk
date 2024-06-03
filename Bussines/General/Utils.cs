namespace ServDesk.Bussines.General
{
    public class Utils
    {
        public static string GenerateCode(string str, int num)
        {
            return str + num.ToString("D7");
        }

    }
}
