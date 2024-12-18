Ерос, [18.12.2024 18:02]
// Library of Classes
using System;

namespace LabWorkLibrary
{
    public class Liquid
    {
        public string Name { get; set; }
        public double Density { get; set; }
        public double SurfaceTension { get; set; }

        public Liquid() { }

        public Liquid(string name, double density, double surfaceTension)
        {
            Name = name;
            Density = density;
            SurfaceTension = surfaceTension;
        }

        public Liquid(Liquid other)
        {
            Name = other.Name;
            Density = other.Density;
            SurfaceTension = other.SurfaceTension;
        }

        public void ChangeDensity(double newDensity)
        {
            Density = newDensity;
        }

        public void ChangeSurfaceTension(double newSurfaceTension)
        {
            SurfaceTension = newSurfaceTension;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}, Density: {Density}, Surface Tension: {SurfaceTension}");
        }
    }

    public class Alcohol : Liquid
    {
        public double Strength { get; set; }

        public Alcohol() { }

        public Alcohol(string name, double density, double surfaceTension, double strength) : base(name, density, surfaceTension)
        {
            Strength = strength;
        }

        public Alcohol(Alcohol other) : base(other)
        {
            Strength = other.Strength;
        }

        public void ChangeStrength(double newStrength)
        {
            Strength = newStrength;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Strength: {Strength}");
        }
    }

    public class Petrol : Liquid
    {
        public double OctaneNumber { get; set; }

        public Petrol() { }

        public Petrol(string name, double density, double surfaceTension, double octaneNumber) : base(name, density, surfaceTension)
        {
            OctaneNumber = octaneNumber;
        }

        public Petrol(Petrol other) : base(other)
        {
            OctaneNumber = other.OctaneNumber;
        }

        public void ChangeOctaneNumber(double newOctaneNumber)
        {
            OctaneNumber = newOctaneNumber;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Octane Number: {OctaneNumber}");
        }
    }

    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        public Fraction(Fraction other)
        {
            Numerator = other.Numerator;
            Denominator = other.Denominator;
        }

        private void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        Ерос, [18.12.2024 18:02]
public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return b > a;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return a > b  a == b;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return a < b  a == b;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public double ToDouble()
        {
            return (double)Numerator / Denominator;
        }

        public override bool Equals(object obj)
        {
            return obj is Fraction fraction && this == fraction;
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }
    }
}

namespace LabWork
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Work with Liquids");
                Console.WriteLine("2. Work with Fractions");
                Console.WriteLine("3. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        HandleLiquids();
                        break;
                    case "2":
                        HandleFractions();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void HandleLiquids()
        {
            var liquids = new Liquid[]
            {
                new Alcohol("Ethanol", 0.789, 22.3, 95),
                new Petrol("Premium Gasoline", 0.72, 20.2, 98)
            };

            foreach (var liquid in liquids)
            {
                liquid.ShowInfo();
            }
        }

        static void HandleFractions()
        {
            var fraction1 = new Fraction(3, 4);
            var fraction2 = new Fraction(5, 6);

            Console.WriteLine($"Fraction 1: {fraction1}");
            Console.WriteLine($"Fraction 2: {fraction2}");

            Console.WriteLine($"Sum: {fraction1 + fraction2}");
            Console.WriteLine($"Difference: {fraction1 - fraction2}");
            Console.WriteLine($"Product: {fraction1 * fraction2}");
            Console.WriteLine($"Quotient: {fraction1 / fraction2}");

            Console.WriteLine($"Fraction 1 as double: {fraction1.ToDouble()}");
        }
    }
}