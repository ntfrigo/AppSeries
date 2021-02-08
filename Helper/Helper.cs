using System;

namespace Ntf.Series.Helper
{
    public static class Helper
    {
        public static string ToFormatStr(this string text, int columns)
        {
            return $"{text.PadRight(15, '.')}: ";
        }
        public static string ToFormatStrLine(this string nome, object valor)
        {
            return $"{nome.PadRight(15, '.')}: {valor}{Environment.NewLine}";
        }
    }
}
