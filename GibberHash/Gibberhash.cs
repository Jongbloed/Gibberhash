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
        private static uint takeNextBits(ref uint number, byte amount)
        {
            uint mask = ((1U << amount) - 1U);
            //showBits(mask).Dump();
            uint result = (number & mask);
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
            uint scrambled = mirrorOddBits((uint)(number));

            return
            Enumerable.Range(0,16)
                .Select(n => takeNextBits(ref scrambled, 30))
                .Select(uint25 => uint25 & 0xF)
            /*return new[] { 0, 4, 8, 12, 16, 0, 20, 24, 28 }.Select(shift => (byte)((scrambled >> shift) & 0xF))*/
                .Zip(new[]
                {
                    TextType.WordStart,
                    TextType.ShortVowel,
                    TextType.SoftConsonant,
                    TextType.LongVowel,
                    TextType.WordEnd,
                    TextType.ShortVowel,
                    TextType.Space,

                    TextType.WordStart,
                    TextType.ShortVowel,
                    TextType.SoftConsonant,
                    TextType.LongVowel,
                    TextType.WordEnd,
                    TextType.Space,

                    TextType.WordStart,
                    TextType.ShortVowel,
                    TextType.WordEnd
                }, 
                (uint4, syll) => syllables[(int)syll, uint4])
                .Aggregate(new StringBuilder(), (sb, syll) => sb.Append(syll))
                .ToString();
        }
    }
}
