using System.Text;

namespace CourseWorkWeb.Core.Converts
{
    public static class ByteConverter
    {
        public static byte[] StringToBytes(string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        public static string BytesToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
