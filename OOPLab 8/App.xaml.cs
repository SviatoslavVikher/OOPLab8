#include <iostream>
#include <string>
#include <vector>
#include <numeric> // Для std::gcd

using

namespace std
{
    // Базовий клас Liquid (рідина)
    internal class Liquid
    {
        protected:
        string name;
        double density;           // Густина
        double surfaceTension;    // Поверхневий натяг

        public:
        // Конструктор за замовчуванням
        Liquid() : name("Default Liquid"), density(1.0), surfaceTension(0.072) { }

        // Конструктор з параметрами
        Liquid(const string& name, double density, double surfaceTension)
            : name(name), density(density), surfaceTension(surfaceTension) { }

        // Конструктор копіювання
        Liquid(const Liquid& other)
            : name(other.name), density(other.density), surfaceTension(other.surfaceTension) { }

        // Метод зміни густини
        void changeDensity(double newDensity)
        {
            density = newDensity;
        }

        // Метод зміни поверхневого натягу
        void changeSurfaceTension(double newSurfaceTension)
        {
            surfaceTension = newSurfaceTension;
        }

        // Віртуальний метод для виводу інформації
        virtual void showInfo() const {
            cout << "Liquid: " << name << ", Density: " << density << ", Surface Tension: " << surfaceTension << endl;
        }

    // Віртуальний деструктор
    virtual ~Liquid() { }
}}
;

// Похідний клас Alcohol (спирт)
internal class Alcohol : public Liquid
{
    double strength; // Міцність у %

public:
    // Конструктор за замовчуванням
    Alcohol() : Liquid(), strength(0.0) { }

// Конструктор з параметрами
Alcohol(const string& name, double density, double surfaceTension, double strength)
        : Liquid(name, density, surfaceTension), strength(strength) { }

// Конструктор копіювання
Alcohol(const Alcohol& other) : Liquid(other), strength(other.strength) { }

// Метод зміни міцності
void changeStrength(double newStrength)
{
    strength = newStrength;
}

// Перевизначений метод для виводу інформації
void showInfo() const override {
        Liquid::showInfo();
cout << "Alcohol Strength: " << strength << "%" << endl;
    }
};

// Похідний клас Petrol (бензин)
internal class Petrol : public Liquid
{
    int octaneNumber; // Октанове число

public:
    // Конструктор за замовчуванням
    Petrol() : Liquid(), octaneNumber(0) { }

// Конструктор з параметрами
Petrol(const string& name, double density, double surfaceTension, int octaneNumber)
        : Liquid(name, density, surfaceTension), octaneNumber(octaneNumber) { }

// Конструктор копіювання
Petrol(const Petrol& other) : Liquid(other), octaneNumber(other.octaneNumber) { }

// Метод зміни октанового числа
void changeOctaneNumber(int newOctaneNumber)
{
    octaneNumber = newOctaneNumber;
}

// Перевизначений метод для виводу інформації
void showInfo() const override {
        Liquid::showInfo();
cout << "Petrol Octane Number: " << octaneNumber << endl;
    }
};

// Клас Fraction (дроби)
internal class Fraction
{
    int numerator;   // Чисельник
    int denominator; // Знаменник

    // Метод для скорочення дробу
    void simplify()
    {
        int gcd = std::gcd(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    public:
    // Конструктор за замовчуванням
    Fraction() : numerator(1), denominator(1) { }

    // Конструктор з параметрами
    Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw invalid_argument("Denominator cannot be zero.");
        this->numerator = numerator;
        this->denominator = denominator;
        simplify();
    }

    // Конструктор копіювання
    Fraction(const Fraction& other)
        : numerator(other.numerator), denominator(other.denominator) { }

    // Перевизначений оператор +
    Fraction operator +(const Fraction& other) const {
        int num = numerator * other.denominator + other.numerator * denominator;
    int denom = denominator * other.denominator;
        return Fraction(num, denom);
}

// Перевизначений оператор -
Fraction operator -(const Fraction& other) const {
        int num = numerator * other.denominator - other.numerator * denominator;
int denom = denominator * other.denominator;
return Fraction(num, denom);
    }

    // Перевизначений оператор *
    Fraction operator *(const Fraction& other) const {
        return Fraction(numerator * other.numerator, denominator * other.denominator);
    }

    // Перевизначений оператор /
    Fraction operator /(const Fraction& other) const {
        return Fraction(numerator * other.denominator, denominator * other.numerator);
    }

    // Оператор приведення до double
    operator double() const {
        return static_cast<double>(numerator) / denominator;
    }

    // Вивід у консоль
    friend ostream& operator<<(ostream& os, const Fraction& fraction) {
        os << fraction.numerator << "/" << fraction.denominator;
return os;
    }
};

// Головна програма
int main()
{
    bool running = true;

    while (running)
    {
        cout << "\n=== Меню ===\n";
        cout << "1. Демонстрація роботи з рідинами\n";
        cout << "2. Демонстрація роботи з дробами\n";
        cout << "3. Вихід\n";
        cout << "Оберіть дію: ";
        int choice;
        cin >> choice;

        switch (choice)
        {
            case 1:
                {
                    // Демонстрація рідин
                    Liquid water("Water", 1.0, 0.072);
                    Alcohol ethanol("Ethanol", 0.789, 0.022, 95.0);
                    Petrol petrol("Petrol", 0.71, 0.02, 92);

                    vector<Liquid*> liquids = { &water, &ethanol, &petrol };
                    for (const auto&liquid : liquids) {
                liquid->showInfo();
cout << endl;
            }
            break;
        }
        case 2:
    {
        // Демонстрація дробів
        Fraction f1(3, 4);
        Fraction f2(5, 6);

        cout << "Fraction 1: " << f1 << endl;
        cout << "Fraction 2: " << f2 << endl;
        cout << "Sum: " << (f1 + f2) << endl;
        cout << "Difference: " << (f1 - f2) << endl;
        cout << "Product: " << (f1 * f2) << endl;
        cout << "Quotient: " << (f1 / f2) << endl;
        cout << "Fraction 1 as double: " << static_cast<double>(f1) << endl;
        break;
    }
case 3:
    running = false;
    break;
default:
    cout << "Невірний вибір, спробуйте ще раз." << endl;
    break;
}
    }

    return 0;
}
