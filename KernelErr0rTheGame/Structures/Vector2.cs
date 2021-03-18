using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelErr0rTheGame.Structures
{
    public struct Vector2 : IFormattable, IComparable<Vector2>, IEquatable<Vector2>
    {
        public readonly float X;
        public readonly float Y;

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);
        public static Vector2 Up => new Vector2(0, -1);
        public static Vector2 Right => new Vector2(1, 0);

        public float Magnitude;
        public Vector2 Normalized
        {
            get 
            {
                if (Magnitude == 0) return Zero;
                return new Vector2(X / Magnitude, Y / Magnitude);
            }
        }

        public Vector2(float x = 0, float y = 0)
        {
            X = x;
            Y = y;

            Magnitude = (float)Math.Sqrt((x * x) + (y * y));
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.X - b.X, a.Y - b.Y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.X * b.X, a.Y * b.X);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2(a.X * b, a.Y * b);
        public static Vector2 operator *(float a, Vector2 b) => new Vector2(a * b.X, a * b.Y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.X / b.X, a.Y / b.X);
        public static Vector2 operator /(Vector2 a, float b) => new Vector2(a.X / b, a.Y / b);
        public static Vector2 operator /(float a, Vector2 b) => new Vector2(a / b.X, a / b.Y);

        public void Deconstruct(out float x, out float y)
        {
            x = X;
            y = Y;
        }

        public string ToString(string format, IFormatProvider formatProvider) => $"({X},{Y})";

        public bool Equals(Vector2 other) => X == other.X && Y == other.Y;

        public int CompareTo(Vector2 other)
        {
            if (Magnitude > other.Magnitude) return 1;
            else if (Magnitude < other.Magnitude) return -1;
            return 0;
        }
    }
}
