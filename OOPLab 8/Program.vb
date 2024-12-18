#include <iostream>
#include <String>
#include <vector>

Using namespace std;

// ������� ���� Liquid
Class Liquid {
Protected
    String name;
    Double density;
    Double surfaceTension;

Public: 
    // ����������� �� �������������
    Liquid() : name("������� �����"), density(0.0), surfaceTension(0.0) {}

    // ����������� � �����������
    Liquid(string n, double d, double st) : name(n), density(d), surfaceTension(st) {}

    // ����������� ���������
    Liquid(const Liquid& other) : name(other.name), density(other.density), surfaceTension(other.surfaceTension) {}

    // ³��������� ����� ��� ��������� ����������
    virtual void ShowInfo() {
        cout << "�����: " << name << ", �������: " << density << " ��/�?, ����������� �����: " << surfaceTension << " �/�" << endl;
    }

    // ������ ��� ���� ������� �� ������������ ������
    void SetDensity(Double d) { density = d; }
    void SetSurfaceTension(Double st) { surfaceTension = st; }
};

// �������� ���� Alcohol
Class Alcohol : Public Liquid {
Private
    Double strength; // ̳����� ������

Public: 
    // ������������
    Alcohol() : Liquid(), strength(0.0) {}
    Alcohol(string n, double d, double st, double s) : Liquid(n, d, st), strength(s) {}
    Alcohol(const Alcohol& other) : Liquid(other), strength(other.strength) {}

    // ����� ���� ������
    void SetStrength(Double s) { strength = s; }

    // �������������� ����� ShowInfo
    void ShowInfo() override {
        Liquid:ShowInfo();
        cout << "̳�����: " << strength << "%" << endl;
    }
};

// �������� ���� Petrol
Class Petrol : Public Liquid {
Private:
    int octaneNumber; // �������� �����

Public: 
    // ������������
    Petrol() : Liquid(), octaneNumber(0) {}
    Petrol(string n, double d, double st, int o) : Liquid(n, d, st), octaneNumber(o) {}
    Petrol(const Petrol& other) : Liquid(other), octaneNumber(other.octaneNumber) {}

    // ����� ���� ���������� �����
    void SetOctaneNumber(Int o) { octaneNumber = o; }

    // �������������� ����� ShowInfo
    void ShowInfo() override {
        Liquid:ShowInfo();
        cout << "�������� �����: " << octaneNumber << endl;
    }
};

// ���� Fraction ��� ������ � ������������ �������
Class Fraction {
Private:
    int numerator;   // ���������
    int denominator; // ���������

    // ����� ��� ���������� ���
    int GCD(int a, int b) {
        Return b == 0 ? a : GCD(b, a % b);
    }

Public: 
    // ������������
    Fraction() : numerator(0), denominator(1) {}
    Fraction(int n, int d) : numerator(n), denominator(d == 0 ? 1 : d) { Reduce(); }
    Fraction(const Fraction& other) : numerator(other.numerator), denominator(other.denominator) {}

    // ����� ��� ���������� �����
    void Reduce() {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // �������� �����
    Fraction Operator +() Const { Return *this; }
    Fraction operator-() const { return Fraction(-numerator, denominator); }

    // �������� �����
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

    // �������� ���������
    bool operator==(const Fraction& other) const {
        Return numerator * other.denominator == other.numerator * denominator;
    }

    bool operator! = (const Fraction& other) const { return !(*this == other); }
    bool operator>(const Fraction& other) const { return numerator * other.denominator > other.numerator * denominator; }
    bool operator<(const Fraction& other) const { return numerator * other.denominator < other.numerator * denominator; }

    // ���������� ���� �� double
    Operator double() Const { Return static_cast<Double>(numerator) / denominator; }

    // ����� ��� ��������� ����� � ������ �����
    String ToString() const {
        Return to_string(numerator) + "/" + to_string(denominator);
    }
};

int main() {
    int option;
    cout << "����i�� ���i�:\n1. ������ � �i������\n2. ������ � �������\n";
    cin >> option;

    If (option == 1) {
        vector<Liquid*> liquids;
        liquids.push_back(new Alcohol("������", 0.789, 22.0, 96.0));
        liquids.push_back(new Petrol("������", 0.745, 21.8, 95));

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
        cout << "����: " <<sum.ToString() <<endl;

        Fraction diff = f1 - f2;
        cout << "г�����: " <<diff.ToString() <<endl;

        Fraction product = f1 * f2;
        cout << "�������: " <<product.ToString() <<endl;

        Fraction division = f1 / f2;
        cout << "������: " <<division.ToString() <<endl;

        cout << "f1 > f2: " << (f1 > f2 ? "���" : "ͳ") <<endl;
        cout << "f1 �� ���������: " <<static_cast<double>(f1) <<endl;
    } else {
        cout << "������������ ���i�!" <<endl;
    }

    return 0;
}
#include <iostream>
#include <string>
#include <vector>

using namespace std;

// ������� ���� Liquid
class Liquid {
protected:
    string name;
    double density;
    double surfaceTension;

public:
    // ����������� �� �������������
    Liquid() : name("������� �����"), density(0.0), surfaceTension(0.0) {}

    // ����������� � �����������
    Liquid(string n, double d, double st) : name(n), density(d), surfaceTension(st) {}

    // ����������� ���������
    Liquid(const Liquid& other) : name(other.name), density(other.density), surfaceTension(other.surfaceTension) {}

    // ³��������� ����� ��� ��������� ����������
    virtual void ShowInfo() {
        cout << "�����: " <<name << ", �������: " <<density << " ��/�?, ����������� �����: " <<surfaceTension << " �/�" <<endl;
    }

    // ������ ��� ���� ������� �� ������������ ������
    void SetDensity(double d) { density = d; }
    void SetSurfaceTension(double st) { surfaceTension = st; }
};

// �������� ���� Alcohol
Class Alcohol : Public Liquid {
Private
    Double strength; // ̳����� ������

Public: 
    // ������������
    Alcohol() : Liquid(), strength(0.0) {}
    Alcohol(string n, double d, double st, double s) : Liquid(n, d, st), strength(s) {}
    Alcohol(const Alcohol& other) : Liquid(other), strength(other.strength) {}

    // ����� ���� ������
    void SetStrength(Double s) { strength = s; }

    // �������������� ����� ShowInfo
    void ShowInfo() override {
        Liquid:ShowInfo();
        cout << "̳�����: " << strength << "%" << endl;
    }
};

// �������� ���� Petrol
Class Petrol : Public Liquid {
Private:
    int octaneNumber; // �������� �����

Public: 
    // ������������
    Petrol() : Liquid(), octaneNumber(0) {}
    Petrol(string n, double d, double st, int o) : Liquid(n, d, st), octaneNumber(o) {}
    Petrol(const Petrol& other) : Liquid(other), octaneNumber(other.octaneNumber) {}

    // ����� ���� ���������� �����
    void SetOctaneNumber(int o) { octaneNumber = o; }

    // �������������� ����� ShowInfo
    void ShowInfo() override {
        Liquid:ShowInfo();
        cout << "�������� �����: " << octaneNumber << endl;
    }
};

// ���� Fraction ��� ������ � ������������ �������
Class Fraction {
Private:
    int numerator;   // ���������
    int denominator; // ���������

    // ����� ��� ���������� ���
    int GCD(int a, int b) {
        Return b == 0 ? a : GCD(b, a % b);
    }

Public: 
    // ������������
    Fraction() : numerator(0), denominator(1) {}
    Fraction(int n, int d) : numerator(n), denominator(d == 0 ? 1 : d) { Reduce(); }
    Fraction(const Fraction& other) : numerator(other.numerator), denominator(other.denominator) {}

    // ����� ��� ���������� �����
    void Reduce() {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // �������� �����
    Fraction Operator +() Const { Return *this; }
    Fraction operator-() const { return Fraction(-numerator, denominator); }

    // �������� �����
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

    // �������� ���������
    bool operator==(const Fraction& other) const {
        Return numerator * other.denominator == other.numerator * denominator;
    }

    bool operator! = (const Fraction& other) const { return !(*this == other); }
    bool operator>(const Fraction& other) const { return numerator * other.denominator > other.numerator * denominator; }
    bool operator<(const Fraction& other) const { return numerator * other.denominator < other.numerator * denominator; }

    // ���������� ���� �� double
    Operator double() Const { Return static_cast<Double>(numerator) / denominator; }

    // ����� ��� ��������� ����� � ������ �����
    String ToString() const {
        Return to_string(numerator) + "/" + to_string(denominator);
    }
};

int main() {
    int option;
    cout << "����i�� ���i�:\n1. ������ � �i������\n2. ������ � �������\n";
    cin >> option;

    If (option == 1) {
        vector<Liquid*> liquids;
        liquids.push_back(new Alcohol("������", 0.789, 22.0, 96.0));
        liquids.push_back(new Petrol("������", 0.745, 21.8, 95));

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
        cout << "����: " <<sum.ToString() <<endl;

        Fraction diff = f1 - f2;
        cout << "г�����: " <<diff.ToString() <<endl;

        Fraction product = f1 * f2;
        cout << "�������: " <<product.ToString() <<endl;

        Fraction division = f1 / f2;
        cout << "������: " <<division.ToString() <<endl;

        cout << "f1 > f2: " << (f1 > f2 ? "���" : "ͳ") <<endl;
        cout << "f1 �� ���������: " <<static_cast<double>(f1) <<endl;
    } else {
        cout << "������������ ���i�!" <<endl;
    }

    return 0;
}
