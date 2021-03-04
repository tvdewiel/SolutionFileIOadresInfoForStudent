using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ReadAdresInfoLib
{
    public class Data : IComparable<Data>
    {
        public string provincie;
        public string gemeente;
        public string straatnaam;

        public Data(string provincie, string gemeente, string straatnaam)
        {
            this.provincie = provincie;
            this.gemeente = gemeente;
            this.straatnaam = straatnaam;
        }

        public int CompareTo(Data other)
        {
            return other.straatnaam.CompareTo(this.straatnaam);
            //return this.straatnaam.CompareTo(other.straatnaam);
        }

        public override bool Equals(object obj)
        {
            return obj is Data data &&
                   provincie == data.provincie &&
                   gemeente == data.gemeente &&
                   straatnaam == data.straatnaam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(provincie, gemeente, straatnaam);
        }

        public override string ToString()
        {
            return $"{provincie},{gemeente},{straatnaam}";
        }
    }
}
