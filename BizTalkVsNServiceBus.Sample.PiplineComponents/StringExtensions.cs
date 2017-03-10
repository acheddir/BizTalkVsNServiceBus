using System.Text;

namespace BizTalkVsNServiceBus.Sample.PiplineComponents
{
    public static class StringExtensions
    {
        public static string ExceptBlanks(this string str)
        {
            var builder = new StringBuilder(str.Length);
            foreach (var c in str)
            {
                switch (c)
                {
                    case '\n':
                    case '\t':
                        break;
                    default:
                        builder.Append(c);
                        break;
                }

            }

            return builder.ToString();
        }
    }
}