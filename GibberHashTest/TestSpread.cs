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

        private const int MaxTestValue = ushort.MaxValue;
        private Dictionary<string, List<uint>> _spreadDictionary = new Dictionary<string, List<uint>>(MaxTestValue);

        [TestMethod]
        public void Spread_NoMoreThanTwo()
        {
            _spreadDictionary.Clear();
            string gibberHash;
            for(uint i = 0 ; i < MaxTestValue ; i++)
            {
                gibberHash = i.ToGibberHash();
                if (_spreadDictionary.ContainsKey(gibberHash))
                    _spreadDictionary[gibberHash] = Tuple.Create(_spreadDictionary[gibberHash].Item1, _spreadDictionary[gibberHash].Item2+1);
                else
                    _spreadDictionary.Add(gibberHash, Tuple.Create(i, 1));
            }
            int maxSpread = _spreadDictionary.Max(kvp => kvp.Value.Item2);
            Assert.IsTrue(maxSpread <= 2);
        }
        [TestMethod]
        public void Spread_NoMoreThanMD5()
        {
            _spreadDictionary.Clear();
            string md5Hash;
            using(var md5 = System.Security.Cryptography.MD5.Create())
                for (uint i = 0 ; i < MaxTestValue ; i++)
                {
                    md5Hash = BitConverter.ToString(md5.ComputeHash(new []{ (byte)(i), (byte)(i>>8), (byte)(i>>16), (byte)(i>>24), })).Replace("-", "");

                    if (_spreadDictionary.ContainsKey(md5Hash))
                        _spreadDictionary[md5Hash] = Tuple.Create(_spreadDictionary[md5Hash].Item1, _spreadDictionary[md5Hash].Item2 + 1);
                    else
                        _spreadDictionary.Add(md5Hash, Tuple.Create(i, 1));
                }
            int md5MaxSpread = _spreadDictionary.Max(kvp => kvp.Value.Item2);

            _spreadDictionary.Clear();
            string gibberHash;
            for (uint i = 0 ; i < MaxTestValue ; i++)
            {
                gibberHash = ((uint)i).ToGibberHash();
                if (_spreadDictionary.ContainsKey(gibberHash))
                    _spreadDictionary[gibberHash] = Tuple.Create(_spreadDictionary[gibberHash].Item1, _spreadDictionary[gibberHash].Item2 + 1);
                else
                    _spreadDictionary.Add(gibberHash, Tuple.Create(i, 1));
            }
            int gibberishSpread = _spreadDictionary.Max(kvp => kvp.Value.Item2);

            string duplications = String.Join("\n", _spreadDictionary.Where(kvp => kvp.Value.Item2 == 2).Select(kvp => $"{kvp.Value.Item1} => {kvp.Key}"));
            string triplications = String.Join("\n", _spreadDictionary.Where(kvp => kvp.Value.Item2 == 3).Select(kvp => $"{kvp.Value.Item1} => {kvp.Key}"));
            string quadruplications = String.Join("\n", _spreadDictionary.Where(kvp => kvp.Value.Item2 == 4).Select(kvp => $"{kvp.Value.Item1} => {kvp.Key}"));
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
            for (uint i = 0 ; i < MaxTestValue ; i++)
            {
                checksum = Checksum(i.ToString()).ToString();

                if (_spreadDictionary.ContainsKey(checksum))
                    _spreadDictionary[checksum] = Tuple.Create(_spreadDictionary[checksum].Item1, _spreadDictionary[checksum].Item2 + 1);
                else
                    _spreadDictionary.Add(checksum, Tuple.Create(i, 1));
            }
            int chksMaxSpread = _spreadDictionary.Max(kvp => kvp.Value.Item2);

            _spreadDictionary.Clear();
            string gibberHash;
            for (uint i = 0 ; i < MaxTestValue ; i++)
            {
                gibberHash = ((uint)i).ToGibberHash();
                if (_spreadDictionary.ContainsKey(gibberHash))
                    _spreadDictionary[gibberHash] = Tuple.Create(_spreadDictionary[gibberHash].Item1, _spreadDictionary[gibberHash].Item2 + 1);
                else
                    _spreadDictionary.Add(gibberHash, Tuple.Create(i, 1));
            }
            int gibberishSpread = _spreadDictionary.Max(kvp => kvp.Value.Item2);
            Assert.IsTrue(gibberishSpread <= chksMaxSpread);
        }
    }
}
