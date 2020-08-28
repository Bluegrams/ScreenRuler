using System;

namespace ScreenRuler
{
    /// <summary>
    /// Models a marking line on the ruler.
    /// </summary>
    public struct Marker
    {
        public static readonly Marker Default = new Marker();

        public float Value;
        public bool Vertical;

        public Marker(float value, bool vertical)
        {
            this.Value = value;
            this.Vertical = vertical;
        }

        public static bool operator ==(Marker x, Marker y)
        {
            return x.Value == y.Value && x.Vertical == y.Vertical;
        }

        public static bool operator !=(Marker x, Marker y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Marker other)
            {
                return this.Value == other.Value && this.Vertical == other.Vertical;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public string DisplayString
        {
            get
            {
                if (!Vertical) return String.Format("⇄ {0,6} px", Value);
                else return String.Format("⇅ {0,6} px", Value);
            }
        }

        public static Marker FromString(string s)
        {
            string v = s.Substring(0, s.Length - 1);
            string t = s.Substring(s.Length - 1, 1);
            float value = float.Parse(v);
            bool vertical = t == "v" ? true : t == "h" ? false : throw new ArgumentException();
            return new Marker(value, vertical);
        }

        public override string ToString()
        {
            string type = Vertical ? "v" : "h";
            return $"{Value}{type}";
        }
    }
}
