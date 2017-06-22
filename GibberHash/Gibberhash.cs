using System;
using System.Linq;
using System.Text;

namespace Jongbloed.Experiments
{
    public static class GibberHash
    {
        
        private static string[] starts = {  "S",  "M",  "P",    "W",  "R",   "T",    "S",  "D",   "F",   "G",   "H",  "K",   "L",   "V",   "B",    "N"};
        private static string[] shorts = {  "o", "oe",  "e",    "a", "eh", "och",  "ach",  "i", "oeh",  "ou", "ugh", "uh",   "u",  "ie","isch", "ieuw"};
        private static string[] longs =  { "au", "oo", "aa",   "oe", "ou",  "eu",  "aai", "la",  "ei", "ooi",  "ij", "ee",  "ui",  "aï",   "y",  "eeu"};
        private static string[] soft =   { "ng", "er",  "x",    "l", "dz",   "s",    "n",  "m",  "ls", "cch",   "h",  "ñ",  "sh",   "g",  "ks",  "ter"};
        private static string[] ends =   { "we","der","tum","schap", "el","heid",   "io","sus",  "uw", "ert", "sch", "ly","nter",  "er","stra",  "tel"};

        private static void wrapShiftRight(ref uint number, byte amount)
        {
            amount %= 32;
            number = (uint)((number >> amount) | ((number & ((1 << amount) - 1)) << (32 - amount)));
        }
        private static ulong takeNextBits(ref uint number, byte amount)
        {
            ulong result = (ulong)(number & ((1 << amount) - 1));
            wrapShiftRight(ref number, amount);
            return result;
        }
        private enum TextType : byte
        {
            WordStart = 0,
            ShortVowel = 1,
            LongVowel = 2,
            SoftConsonant = 3,
            WordEnd = 4,
            Space = 5
        }
        public static string ToGibberHash(this uint number)
        {
            uint shiftOrderBase = ~number;
            wrapShiftRight(ref shiftOrderBase, (byte)(((number ^ 0x65) + ((number & 0x6500) >> 8) + ((number ^ 0x650000) >> 16) + ((number & 0x65000000) >> 24)) & 0xF));

            var type_index = new[] { 0, 3, 6, 9, 13, 16, 20, 24, 28 }
                .Select(shift => Tuple.Create((byte)takeNextBits(ref shiftOrderBase, (byte)((shiftOrderBase & 0x7) + 1)), (byte)takeNextBits(ref shiftOrderBase, 3), (byte)((number >> shift) & 0xF)))
                .OrderBy(order_type_index => order_type_index.Item1)
                .Select(order_type_index => new { type = order_type_index.Item2, index = order_type_index.Item3 }).ToArray();

            var sb = new StringBuilder();
            TextType lastType = TextType.WordStart;
            for (int i = 0 ; i < type_index.Length ; i++)
            {
                var ti = type_index[i];

                switch (lastType)
                {
                case TextType.WordStart:
                    if (i + 1 < type_index.Length)
                        sb.Append(starts[ti.index]);
                    break;
                case TextType.ShortVowel:
                    sb.Append(shorts[ti.index]);
                    break;
                case TextType.LongVowel:
                    sb.Append(longs[ti.index]);
                    break;
                case TextType.SoftConsonant:
                    sb.Append(soft[ti.index]);
                    break;
                case TextType.WordEnd:
                    sb.Append(ends[ti.index]).Append(' ');
                    break;
                case TextType.Space:
                    sb.Append(' ');
                    break;
                }
                switch (lastType)
                {
                case TextType.WordStart:
                    if ((ti.type & 1) > 0)
                        lastType = TextType.LongVowel;
                    else
                        lastType = TextType.ShortVowel;
                    break;
                case TextType.ShortVowel:
                    if ((ti.type & 2) > 0)
                    {
                        if ((ti.type & 1) > 0)
                            lastType = TextType.WordEnd;
                        else
                            lastType = TextType.SoftConsonant;
                    }
                    else
                    {
                        if ((ti.type & 1) > 0)
                            lastType = TextType.Space;
                        else
                            lastType = TextType.WordEnd;
                    }
                    break;
                case TextType.LongVowel:
                    if ((ti.type & 1) > 0)
                        lastType = TextType.SoftConsonant;
                    else
                        lastType = TextType.WordEnd;
                    break;
                case TextType.SoftConsonant:
                    if ((ti.type & 1) > 0)
                        lastType = TextType.WordEnd;
                    else
                        lastType = TextType.ShortVowel;
                    break;
                case TextType.WordEnd:
                case TextType.Space:
                    lastType = TextType.WordStart;
                    break;
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
