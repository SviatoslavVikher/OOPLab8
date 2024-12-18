using System;

namespace LongCodeExample
{
    // Клас Liquid (рідина)
    public class Liquid
    {
        public string Name { get; set; }
        public double Density { get; private set; } // Густина
        public double SurfaceTension { get; private set; } // Поверхневий натяг

        // Конструктор за замовчуванням
        public Liquid()
        {
            Name = "Default Liquid";
            Density = 1.0;
            SurfaceTension = 0.072;
        }

        // Конструктор з параметрами
        public Liquid(string name, double density, double surfaceTension)
        {
            Name = name;
            Density = density;
            SurfaceTension = surfaceTension;
        }

        // Конструктор копіювання
        public Liquid(Liquid liquid)
        {
            Name = liquid.Name;
            Density = liquid.Density;
            SurfaceTension = liquid.SurfaceTension;
        }

        // Метод зміни густини
        public void ChangeDensity(double newDensity)
        {
            Density = newDensity;
        }

        // Метод зміни поверхневого натягу
        public void ChangeSurfaceTension(double newSurfaceTension)
        {
            SurfaceTension = newSurfaceTension;
        }

        // Віртуальний метод для виводу інформації
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Liquid: {Name}, Density: {Density}, Surface Tension: {SurfaceTension}");
        }
    }

    // Клас Alcohol (спирт)
    public class Alcohol : Liquid
    {
        public double Strength { get; private set; } // Міцність у %

        // Конструктор за замовчуванням
        public Alcohol() : base()
        {
            Strength = 0.0;
        }

        // Конструктор з параметрами
        public Alcohol(string name, double density, double surfaceTension, double strength)
            : base(name, density, surfaceTension)
        {
            Strength = strength;
        }

        // Конструктор копіювання
        public Alcohol(Alcohol alcohol) : base(alcohol)
        {
            Strength = alcohol.Strength;
        }

        // Метод зміни міцності
        public void ChangeStrength(double newStrength)
        {
            Strength = newStrength;
        }

        // Перевизначений метод ShowInfo()
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Alcohol Strength: {Strength}%");
        }
    }

    // Клас Petrol (бензин)
    public class Petrol : Liquid
    {
        public int OctaneNumber { get; private set; } // Октанове число

        // Конструктор за замовчуванням
        public Petrol() : base()
        {
            OctaneNumber = 0;
        }

        // Конструктор з параметрами
        public Petrol(string name, double density, double surfaceTension, int octaneNumber)
            : base(name, density, surfaceTension)
        {
            OctaneNumber = octaneNumber;
        }

        // Конструктор копіювання
        public Petrol(Petrol petrol) : base(petrol)
        {
            OctaneNumber = petrol.OctaneNumber;
        }

        // Метод зміни октанового числа
        public void ChangeOctaneNumber(int newOctaneNumber)
        {
            OctaneNumber = newOctaneNumber;
        }

        // Перевизначений метод ShowInfo()
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Petrol Octane Number: {OctaneNumber}");
        }
    }

    // Клас Fraction (дроби)
    public class Fraction
    {
        public int Numerator { get; private set; } // Чисельник
        public int Denominator { get; private set; } // Знаменник

        // Конструктор за замовчуванням
        public Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }

        // Конструктор з параметрами
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        // Конструктор копіювання
        public Fraction(Fraction fraction)
        {
            Numerator = fraction.Numerator;
            Denominator = fraction.Denominator;
        }

        // Метод для скорочення дробу
        private void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        // Найбільший спільний дільник
        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        // Перевизначений метод ToString()
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        // Арифметичні оператори
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

        // Порівняння
        public static bool operator >(Fraction a, Fraction b)
        {
            return (double)a > (double)b;
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return (double)a < (double)b;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        // Перетворення до double
        public static explicit operator double(Fraction fraction)
        {
            return (double)fraction.Numerator / fraction.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction fraction)
                return this == fraction;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }
    }

    // Основна програма
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Демонстрація роботи з рідинами");
                Console.WriteLine("2. Демонстрація роботи з дробами");
                Console.WriteLine("3. Вихід");
                Console.Write("Оберіть дію: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DemonstrateLiquids();
                        break;
                    case "2":
                        DemonstrateFractions();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }

        static void DemonstrateLiquids()
        {
            Liquid water = new Liquid("Water", 1.0, 0.072);
            Alcohol ethanol = new Alcohol("Ethanol", 0.789, 0.022, 95.0);
            Petrol petrol = new Petrol("Petrol", 0.71, 0.02, 92);

            Liquid[] liquids = { water, ethanol, petrol };

            foreach (var liquid in liquids)
            {
                liquid.ShowInfo();
                Console.WriteLine();
            }
        }

        static void DemonstrateFractions()
        {
            Fraction f1 = new Fraction(3, 4);
            Fraction f2 = new Fraction(5, 6);

            Console.WriteLine($"Fraction 1: {f1}");
            Console.WriteLine($"Fraction 2: {f2}");
            Console.WriteLine($"Sum: {f1 + f2}");
            Console.WriteLine($"Difference: {f1 - f2}");
            Console.WriteLine($"Product: {f1 * f2}");
            Console.WriteLine($"Quotient: {f1 / f2}");
            Console.WriteLine($"Fraction 1 as double: {(double)f1}");
        }
    }
}
