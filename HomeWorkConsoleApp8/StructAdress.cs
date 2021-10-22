using System;

namespace HomeWorkConsoleApp8
{
    [Serializable]
    public struct StructAdress
    {
        public string Street { set; get; }
        public long HouseNumber { set; get; }
        public long FlatNumber { set; get; }
    }
}
