namespace COVID.Utility
{
    using System.Security.Cryptography;
    using System;
    using System.Text;
    public class PartitionKeyGenerator
    {
        private readonly MD5 _md5;
        public PartitionKeyGenerator()
        {
            _md5 = MD5.Create();
        }
        public string Create(string prefix, string id, int numberOfPartitions)
        {
            var hashedValue = _md5.ComputeHash(Encoding.UTF8.GetBytes(id));
            var asInt = BitConverter.ToInt32(hashedValue, 0);
            asInt = asInt == int.MinValue ? asInt + 1 : asInt;
            return $"{prefix}{Math.Abs(asInt) % numberOfPartitions}";
        }
    }
}
