using System;
using System.Linq;
using System.Text;

namespace Jongbloed.Experiments
{
    public static class GibberHash
    {
        private enum TextType : byte
        {
            WordStart = 0,
            ShortVowel = 1,
            LongVowel = 2,
            SoftConsonant = 3,
            WordEnd = 4,
            Space = 5
        }

        private static string[,] syllables = { {  "S",  "M",  "P",    "W",  "R",   "T",    "S",  "D",   "F",   "G",   "H",  "K",   "L",   "V",   "B",    "N" },
                                               {  "o", "oe",  "e",    "a", "eh", "och",  "ach",  "i", "oeh",  "ou", "ugh", "uh",   "u",  "ie","isch", "ieuw" },
                                               { "au", "oo", "aa",   "oe", "ou",  "eu",  "aai", "la",  "ei", "ooi",  "ij", "ee",  "ui",  "aï",   "y",  "eeu" },
                                               { "ng", "er",  "x",    "l", "dz",   "s",    "n",  "m",  "ls", "cch",   "h",  "ñ",  "sh",   "g",  "ks",  "ter" },
                                               { "we","der","tum","schap", "el","heid",   "io","sus",  "uw", "ert", "sch", "ly","nter",  "er","stra",  "tel" },
                                               { " " , " " , " " ,   " " , " " ,  " " ,   " " , " " ,  " " ,  " " ,  " " , " " ,  " " ,  " " ,  " " ,    " " } };

        private static void wrapShiftRight(ref uint number, byte amount)
        {
            amount %= 32;
            number = (uint)((number >> amount) | ((number & ((1 << amount) - 1)) << (32 - amount)));
        }
        //void Main()
        //{
        //    uint test = (uint)new Random().Next();
        //    showBits(test).Dump();

        //    byte shift;
        //    while ((shift = byte.Parse(Console.ReadLine())) > 0)
        //    {
        //        wrapShiftRight(ref test, shift);
        //        showBits(test).Dump();
        //    }
        //}
        private static ulong takeNextBits(ref uint number, byte amount)
        {
            ulong result = (ulong)(number & ((1 << amount) - 1));
            wrapShiftRight(ref number, amount);
            return result;
        }
        //void Main()
        //{
        //    uint test = (uint)new Random().Next();
        //    showBits(test).Dump();

        //    byte shift;
        //    while ((shift = byte.Parse(Console.ReadLine())) > 0)
        //    {
        //        showBits(takeNextBits(ref test, shift)).Dump();
        //    }
        //}
        private static string showBits(uint number) =>
            "32   28   24   20   16   12   8    4  1\n" +
            Enumerable.Range(0, sizeof(uint) * 8).Reverse()
                .Aggregate(new StringBuilder(), (sb, i) => sb.Append(Convert.ToInt32((number & (1U << i)) > 0)).Append(i > 0 && (i) % 4 == 0 ? " " : ""))
                .Append('\n').Append(number.ToString().PadLeft(39, ' ')).ToString();
        private static string visualizeBits(uint number) =>
            Enumerable.Range(0, sizeof(uint) * 8).Reverse()
                .Aggregate(new StringBuilder($"{(sizeof(uint) * 8)} "),
                           (sb, i) => sb.Append((number & (1U << i)) > 0 ? '◍' : '◎')
                                        .Append(i > 0 && i % 8 == 0
                                                    ? $" {i} "
                                                    : (i > 0 && i % 4 == 0
                                                        ? " "
                                                        : "")))
                .Append(" ⊏ ")
                .Append(number.ToString().PadLeft(uint.MaxValue.ToString().Length, ' '))
                .ToString();
        private static uint mirrorOddBits(uint subject)
        {
            const byte
                sizeInBits = (sizeof(uint) * 8),
                halfSizeInBits = sizeInBits / 2;

            for (byte i = 0 ; i < halfSizeInBits ; i += 2)
            {
                uint bitFlag = (1U << i);

                uint mirrorBitFlag = (1U << (sizeInBits - i - 1));

                //showBits((bitFlag | mirrorBitFlag)).Dump();

                uint newBit = subject & mirrorBitFlag;
                uint newMirrorBit = subject & bitFlag;

                if (newBit > 0U)
                    subject |= bitFlag;
                else
                    subject &= ~bitFlag;
                if (newMirrorBit > 0U)
                    subject |= mirrorBitFlag;
                else
                    subject &= ~mirrorBitFlag;
            }
            return subject;
        }
        //void Main()
        //{
        //    uint test = 0x000000F0U;//(uint) new Random().Next();
        //    showBits(test).Dump();
        //    showBits(mirrorOddBits(test)).Dump();
        //    showBits(mirrorOddBits(mirrorOddBits(test))).Dump();

        //    Enumerable.Range(2300, 6).Select(Convert.ToUInt32).ToList().ForEach(ui => ("" + ui + " -> " + mirrorOddBits(ui)).Dump());
        //}
        public static string ToGibberHash(this int number)
        {
            uint scrambled = mirrorOddBits(Convert.ToUInt32(number));

            return new[] { 0, 4, 8, 12, 16, 0, 20, 24, 28 }.Select(shift => (byte)((scrambled >> shift) & 0xF))
                .Zip(new[]
                {
                    TextType.WordStart,
                    TextType.ShortVowel,
                    TextType.SoftConsonant,
                    TextType.ShortVowel,
                    TextType.WordEnd,
                    TextType.Space,
                    TextType.WordStart,
                    TextType.LongVowel,
                    TextType.SoftConsonant,
                    TextType.WordEnd
                }, (halfByte, textType) => syllables[(int)textType, halfByte])
                .Aggregate(new StringBuilder(), (sb, syll) => sb.Append(syll))
                .ToString();
        }
        //public static string ToGibberHash(this uint number)
        //{
        //    uint shiftOrderBase = ~number;
        //    wrapShiftRight(ref shiftOrderBase, (byte)(((number ^ 0x65) + ((number ^ 0x6500) >> 8) + ((number ^ 0x650000) >> 16) + ((number ^ 0x65000000) >> 24)) ));

        //    var type_index = new[] { 0, 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28 }
        //        .Select(shift => Tuple.Create((byte)takeNextBits(ref shiftOrderBase, (byte)((shiftOrderBase & 0x7) + 1)), (byte)takeNextBits(ref shiftOrderBase, 3), (byte)((number >> shift) & 0xF)))
        //        .OrderBy(order_type_index => order_type_index.Item1)
        //        .Select(order_type_index => new { type = order_type_index.Item2, index = order_type_index.Item3 }).ToArray();

        //    var sb = new StringBuilder();
        //    TextType lastType = TextType.WordStart;
        //    for (int i = 0 ; i < type_index.Length ; i++)
        //    {
        //        var ti = type_index[i];

        //        switch (lastType)
        //        {
        //        case TextType.WordStart:
        //            if (i + 1 < type_index.Length)
        //                sb.Append(starts[ti.index]);
        //            break;
        //        case TextType.ShortVowel:
        //            sb.Append(shorts[ti.index]);
        //            break;
        //        case TextType.LongVowel:
        //            sb.Append(longs[ti.index]);
        //            break;
        //        case TextType.SoftConsonant:
        //            sb.Append(soft[ti.index]);
        //            break;
        //        case TextType.WordEnd:
        //            sb.Append(ends[ti.index]).Append(' ');
        //            break;
        //        case TextType.Space:
        //            sb.Append(' ');
        //            break;
        //        }
        //        switch (lastType)
        //        {
        //        case TextType.WordStart:
        //            if ((ti.type & 1) > 0)
        //                lastType = TextType.LongVowel;
        //            else
        //                lastType = TextType.ShortVowel;
        //            break;
        //        case TextType.ShortVowel:
        //            if ((ti.type & 2) > 0)
        //            {
        //                if ((ti.type & 1) > 0)
        //                    lastType = TextType.WordEnd;
        //                else
        //                    lastType = TextType.SoftConsonant;
        //            }
        //            else
        //            {
        //                if ((ti.type & 1) > 0)
        //                    lastType = TextType.Space;
        //                else
        //                    lastType = TextType.WordEnd;
        //            }
        //            break;
        //        case TextType.LongVowel:
        //            if ((ti.type & 1) > 0)
        //                lastType = TextType.SoftConsonant;
        //            else
        //                lastType = TextType.WordEnd;
        //            break;
        //        case TextType.SoftConsonant:
        //            if ((ti.type & 1) > 0)
        //                lastType = TextType.WordEnd;
        //            else
        //                lastType = TextType.ShortVowel;
        //            break;
        //        case TextType.WordEnd:
        //        case TextType.Space:
        //            lastType = TextType.WordStart;
        //            break;
        //        }
        //    }
        //    return sb.ToString().TrimEnd();
        //}
    }
}
