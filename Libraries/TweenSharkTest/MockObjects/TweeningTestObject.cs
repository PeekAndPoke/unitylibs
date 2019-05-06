using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TweenSharkTest.MockObjects
{
    class TweeningTestObject
    {
        public float FloatValue;
        public double DoubleValue;

        public sbyte SbyteValue;
        public short ShortValue;
        public int IntValue;
        public int IntProperty { get; set; }
        public long LongValue;

        public byte ByteValue;
        public ushort UshortValue;
        public uint UintValue;
        public ulong UlongValue;

        public GenericParameterHelper GenericValue = null;

        public GenericParameterHelper GenericProperty { get; set; }
    }
}