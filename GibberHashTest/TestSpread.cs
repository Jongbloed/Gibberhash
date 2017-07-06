using System;
using System.Linq;
using System.Collections.Generic;
using Jongbloed.Experiments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GibberHashTest
{
    [TestClass]
    public class TestSpread
    {
        private static int Checksum(string self)
        {
            int checksum = 0;

            foreach (byte b in System.Text.Encoding.Default.GetBytes(self))
                unchecked
                {
                    checksum += b;
                }
            return checksum & 0xFF;
        }

        private const int MaxTestValue = ushort.MaxValue * 16;
        private Dictionary<string, List<int>> _spreadDictionary = new Dictionary<string, List<int>>(MaxTestValue);

        [TestMethod]
        public void Spread_NoMoreThanTwo()
        {
            _spreadDictionary.Clear();
            string gibberHash;
            for(int i = 0 ; i < MaxTestValue ; i++)
            {
                gibberHash = i.ToGibberHash();
                if (_spreadDictionary.ContainsKey(gibberHash))
                    _spreadDictionary[gibberHash].Add(i);
                else
                    _spreadDictionary.Add(gibberHash, new List<int> { i });
            }
            int maxSpread = _spreadDictionary.Max(kvp => kvp.Value.Count);
            Assert.IsTrue(maxSpread <= 2);
        }
        [TestMethod]
        public void Spread_NoMoreThanMD5()
        {
            _spreadDictionary.Clear();
            string md5Hash;
            using(var md5 = System.Security.Cryptography.MD5.Create())
                for (int i = 0 ; i < MaxTestValue ; i++)
                {
                    md5Hash = BitConverter.ToString(md5.ComputeHash(new []{ (byte)(i), (byte)(i>>8), (byte)(i>>16), (byte)(i>>24), })).Replace("-", "");

                    if (_spreadDictionary.ContainsKey(md5Hash))
                        _spreadDictionary[md5Hash].Add(i);
                    else
                        _spreadDictionary.Add(md5Hash, new List<int> { i });
                }
            int md5MaxSpread = _spreadDictionary.Max(kvp => kvp.Value.Count);

            _spreadDictionary.Clear();
            string gibberHash;
            for (int i = 0 ; i < MaxTestValue ; i++)
            {
                gibberHash = i.ToGibberHash();
                if(i > 16352 && i < 16586) System.Diagnostics.Debug.WriteLine(gibberHash);
                if (_spreadDictionary.ContainsKey(gibberHash))
                    _spreadDictionary[gibberHash].Add(i);
                else
                    _spreadDictionary.Add(gibberHash, new List<int> { i });
            }
            int gibberishSpread = _spreadDictionary.Max(kvp => kvp.Value.Count);

            string duplications = String.Join("\n", _spreadDictionary.Where(kvp => kvp.Value.Count == 2).Select(kvp => $"({String.Join(", ", kvp.Value)}) => {kvp.Key}"));
            string triplications = String.Join("\n", _spreadDictionary.Where(kvp => kvp.Value.Count == 3).Select(kvp => $"({String.Join(", ", kvp.Value)}) => {kvp.Key}"));
            string quadruplications = String.Join("\n", _spreadDictionary.Where(kvp => kvp.Value.Count == 4).Select(kvp => $"({String.Join(", ", kvp.Value)}) => {kvp.Key}"));
            Assert.IsTrue(gibberishSpread <= md5MaxSpread);
            Assert.IsTrue(duplications.Length == 0);
            Assert.IsTrue(triplications.Length == 0);
            Assert.IsTrue(quadruplications.Length == 0);
        }
        [TestMethod]
        public void Spread_NoMoreThanChecksum()
        {
            _spreadDictionary.Clear();
            string checksum;
            for (int i = 0 ; i < MaxTestValue ; i++)
            {
                checksum = Checksum(i.ToString()).ToString();

                if (_spreadDictionary.ContainsKey(checksum))
                    _spreadDictionary[checksum].Add(i);
                else
                    _spreadDictionary.Add(checksum, new List<int> { i });
            }
            int chksMaxSpread = _spreadDictionary.Max(kvp => kvp.Value.Count);

            _spreadDictionary.Clear();
            string gibberHash;
            for (int i = 0 ; i < MaxTestValue ; i++)
            {
                gibberHash = i.ToGibberHash();
                if (_spreadDictionary.ContainsKey(gibberHash))
                    _spreadDictionary[gibberHash].Add(i);
                else
                    _spreadDictionary.Add(gibberHash, new List<int> { i });
            }
            int gibberishSpread = _spreadDictionary.Max(kvp => kvp.Value.Count);
            Assert.IsTrue(gibberishSpread <= chksMaxSpread);
        }
    }
}
