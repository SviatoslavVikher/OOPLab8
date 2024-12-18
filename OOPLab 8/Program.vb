#include <iostream>
#include <String>
#include <vector>

Using namespace std;

// Базовий клас Liquid
Class Liquid {
Protected
    String name;
    Double density;
    Double surfaceTension;

Public: 
    // Конструктор за замовчуванням
    Liquid() : name("Невідома рідина"), density(0.0), surfaceTension(0.0) {}

    // Конструктор з параметрами
    Liquid(string n, double d, double st) : name(n), density(d), surfaceTension(st) {}

    // Конструктор копіювання
    Liquid(const Liquid& other) : name(other.name), density(other.density), surfaceTension(other.surfaceTension) {}

    // Віртуальний метод для виведення інформації
    virtual void ShowInfo() {
        cout << "Назва: " << name << ", Густина: " << density << " кг/м?, Поверхневий натяг: " << surfaceTension << " Н/м" << endl;
    }

    // Методи для зміни густини та поверхневого натягу
    void SetDensity(Double d) { density = d; }
    void SetSurfaceTension(Double st) { surfaceTension = st; }
};

// Похідний клас Alcohol
Class Alcohol : Public Liquid {
Private
    Double strength; // Міцність спирту

Public: 
    // Конструктори
    Alcohol() : Liquid(), strength(0.0) {}
    Alcohol(string n, double d, double st, double s) : Liquid(n, d, st), strength(s) {}
    Alcohol(const Alcohol& other) : Liquid(other), strength(other.strength) {}

    // Метод зміни міцності
    void SetStrength(Double s) { strength = s; }

    // Перевизначений метод ShowInfo
    void ShowInfo() override {
        Liquid:ShowInfo();
        cout << "Міцність: " << strength << "%" << endl;
    }
};

// Похідний клас Petrol
Class Petrol : Public Liquid {
Private:
    int octaneNumber; // Октанове число

Public: 
    // Конструктори
    Petrol() : Liquid(), octaneNumber(0) {}
    Petrol(string n, double d, double st, int o) : Liquid(n, d, st), octaneNumber(o) {}
    Petrol(const Petrol& other) : Liquid(other), octaneNumber(other.octaneNumber) {}

    // Метод зміни октанового числа
    void SetOctaneNumber(Int o) { octaneNumber = o; }

    // Перевизначений метод ShowInfo
    void ShowInfo() override {
        Liquid:ShowInfo();
        cout << "Октанове число: " << octaneNumber << endl;
    }
};

// Клас Fraction для роботи з натуральними дробами
Class Fraction {
Private:
    int numerator;   // Чисельник
    int denominator; // Знаменник

    // Метод для обчислення НСД
    int GCD(int a, int b) {
        Return b == 0 ? a : GCD(b, a % b);
    }

Public: 
    // Конструктори
    Fraction() : numerator(0), denominator(1) {}
    Fraction(int n, int d) : numerator(n), denominator(d == 0 ? 1 : d) { Reduce(); }
    Fraction(const Fraction& other) : numerator(other.numerator), denominator(other.denominator) {}

    // Метод для скорочення дробу
    void Reduce() {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // Операції унарні
    Fraction Operator +() Const { Return *this; }
    Fraction operator-() const { return Fraction(-numerator, denominator); }

    // Операції бінарні
    Fraction operator+(const Fraction& other) const {
        Return Fraction(numerator * other.denominator + other.numerator * denominator, denominator * other.denominator);
    }

    Fraction operator-(const Fraction& other) const {
        Return Fraction(numerator * other.denominator - other.numerator * denominator, denominator * other.denominator);
    }

    Fraction operator*(const Fraction& other) const {
        Return Fraction(numerator * other.numerator, denominator * other.denominator);
    }

    Fraction operator/(const Fraction& other) const {
        Return Fraction(numerator * other.denominator, denominator * other.numerator);
    }

    // Операції порівняння
    bool operator==(const Fraction& other) const {
        Return numerator * other.denominator == other.numerator * denominator;
    }

    bool operator! = (const Fraction& other) const { return !(*this == other); }
    bool operator>(const Fraction& other) const { return numerator * other.denominator > other.numerator * denominator; }
    bool operator<(const Fraction& other) const { return numerator * other.denominator < other.numerator * denominator; }

    // Приведення типу до double
    Operator double() Const { Return static_cast<Double>(numerator) / denominator; }

    // Метод для виведення дробу у вигляді рядка
    String ToString() const {
        Return to_string(numerator) + "/" + to_string(denominator);
    }
};

int main() {
    int option;
    cout << "Оберiть опцiю:\n1. Робота з рiдинами\n2. Робота з дробами\n";
    cin >> option;

    If (option == 1) {
        vector<Liquid*> liquids;
        liquids.push_back(new Alcohol("Етанол", 0.789, 22.0, 96.0));
        liquids.push_back(new Petrol("Бензин", 0.745, 21.8, 95));

        for (auto liquid : liquids) {
            liquid->ShowInfo();
            cout <<endl;
        }

        for (auto liquid : liquids) {
            delete liquid;
        }
    } else if (option == 2) {
        Fraction f1(2, 3), f2(3, 4);
        cout << "f1 = " <<f1.ToString() << ", f2 = " <<f2.ToString() <<endl;

        Fraction sum = f1 + f2;
        cout << "Сума: " <<sum.ToString() <<endl;

        Fraction diff = f1 - f2;
        cout << "Різниця: " <<diff.ToString() <<endl;

        Fraction product = f1 * f2;
        cout << "Добуток: " <<product.ToString() <<endl;

        Fraction division = f1 / f2;
        cout << "Частка: " <<division.ToString() <<endl;

        cout << "f1 > f2: " << (f1 > f2 ? "Так" : "Ні") <<endl;
        cout << "f1 як десяткове: " <<static_cast<double>(f1) <<endl;
    } else {
        cout << "Неправильний вибiр!" <<endl;
    }

    return 0;
}
#include <iostream>
#include <string>
#include <vector>

using namespace std;

// Базовий клас Liquid
class Liquid {
protected:
    string name;
    double density;
    double surfaceTension;

public:
    // Конструктор за замовчуванням
    Liquid() : name("Невідома рідина"), density(0.0), surfaceTension(0.0) {}

    // Конструктор з параметрами
    Liquid(string n, double d, double st) : name(n), density(d), surfaceTension(st) {}

    // Конструктор копіювання
    Liquid(const Liquid& other) : name(other.name), density(other.density), surfaceTension(other.surfaceTension) {}

    // Віртуальний метод для виведення інформації
    virtual void ShowInfo() {
        cout << "Назва: " <<name << ", Густина: " <<density << " кг/м?, Поверхневий натяг: " <<surfaceTension << " Н/м" <<endl;
    }

    // Методи для зміни густини та поверхневого натягу
    void SetDensity(double d) { density = d; }
    void SetSurfaceTension(double st) { surfaceTension = st; }
};

// Похідний клас Alcohol
Class Alcohol : Public Liquid {
Private
    Double strength; // Міцність спирту

Public: 
    // Конструктори
    Alcohol() : Liquid(), strength(0.0) {}
    Alcohol(string n, double d, double st, double s) : Liquid(n, d, st), strength(s) {}
    Alcohol(const Alcohol& other) : Liquid(other), strength(other.strength) {}

    // Метод зміни міцності
    void SetStrength(Double s) { strength = s; }

    // Перевизначений метод ShowInfo
    void ShowInfo() override {
        Liquid:ShowInfo();
        cout << "Міцність: " << strength << "%" << endl;
    }
};

// Похідний клас Petrol
Class Petrol : Public Liquid {
Private:
    int octaneNumber; // Октанове число

Public: 
    // Конструктори
    Petrol() : Liquid(), octaneNumber(0) {}
    Petrol(string n, double d, double st, int o) : Liquid(n, d, st), octaneNumber(o) {}
    Petrol(const Petrol& other) : Liquid(other), octaneNumber(other.octaneNumber) {}

    // Метод зміни октанового числа
    void SetOctaneNumber(int o) { octaneNumber = o; }

    // Перевизначений метод ShowInfo
    void ShowInfo() override {
        Liquid:ShowInfo();
        cout << "Октанове число: " << octaneNumber << endl;
    }
};

// Клас Fraction для роботи з натуральними дробами
Class Fraction {
Private:
    int numerator;   // Чисельник
    int denominator; // Знаменник

    // Метод для обчислення НСД
    int GCD(int a, int b) {
        Return b == 0 ? a : GCD(b, a % b);
    }

Public: 
    // Конструктори
    Fraction() : numerator(0), denominator(1) {}
    Fraction(int n, int d) : numerator(n), denominator(d == 0 ? 1 : d) { Reduce(); }
    Fraction(const Fraction& other) : numerator(other.numerator), denominator(other.denominator) {}

    // Метод для скорочення дробу
    void Reduce() {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // Операції унарні
    Fraction Operator +() Const { Return *this; }
    Fraction operator-() const { return Fraction(-numerator, denominator); }

    // Операції бінарні
    Fraction operator+(const Fraction& other) const {
        Return Fraction(numerator * other.denominator + other.numerator * denominator, denominator * other.denominator);
    }

    Fraction operator-(const Fraction& other) const {
        Return Fraction(numerator * other.denominator - other.numerator * denominator, denominator * other.denominator);
    }

    Fraction operator*(const Fraction& other) const {
        Return Fraction(numerator * other.numerator, denominator * other.denominator);
    }

    Fraction operator/(const Fraction& other) const {
        Return Fraction(numerator * other.denominator, denominator * other.numerator);
    }

    // Операції порівняння
    bool operator==(const Fraction& other) const {
        Return numerator * other.denominator == other.numerator * denominator;
    }

    bool operator! = (const Fraction& other) const { return !(*this == other); }
    bool operator>(const Fraction& other) const { return numerator * other.denominator > other.numerator * denominator; }
    bool operator<(const Fraction& other) const { return numerator * other.denominator < other.numerator * denominator; }

    // Приведення типу до double
    Operator double() Const { Return static_cast<Double>(numerator) / denominator; }

    // Метод для виведення дробу у вигляді рядка
    String ToString() const {
        Return to_string(numerator) + "/" + to_string(denominator);
    }
};

int main() {
    int option;
    cout << "Оберiть опцiю:\n1. Робота з рiдинами\n2. Робота з дробами\n";
    cin >> option;

    If (option == 1) {
        vector<Liquid*> liquids;
        liquids.push_back(new Alcohol("Етанол", 0.789, 22.0, 96.0));
        liquids.push_back(new Petrol("Бензин", 0.745, 21.8, 95));

        for (auto liquid : liquids) {
            liquid->ShowInfo();
            cout <<endl;
        }

        for (auto liquid : liquids) {
            delete liquid;
        }
    } else if (option == 2) {
        Fraction f1(2, 3), f2(3, 4);
        cout << "f1 = " <<f1.ToString() << ", f2 = " <<f2.ToString() <<endl;

        Fraction sum = f1 + f2;
        cout << "Сума: " <<sum.ToString() <<endl;

        Fraction diff = f1 - f2;
        cout << "Різниця: " <<diff.ToString() <<endl;

        Fraction product = f1 * f2;
        cout << "Добуток: " <<product.ToString() <<endl;

        Fraction division = f1 / f2;
        cout << "Частка: " <<division.ToString() <<endl;

        cout << "f1 > f2: " << (f1 > f2 ? "Так" : "Ні") <<endl;
        cout << "f1 як десяткове: " <<static_cast<double>(f1) <<endl;
    } else {
        cout << "Неправильний вибiр!" <<endl;
    }

    return 0;
}
