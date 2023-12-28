using Project.Interfaces;

namespace Project
{
    public class Curator : IPerson, ICloneable, ITest
    {
        public int Income { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override int Age { get; set; }
        public Curator(string name, string surname, int age, int income)
        {
            FirstName = name;
            LastName = surname;
            Age = age;
            Income = income;
        }
        public object Clone()
        {
            return new Curator(FirstName, LastName, Age, Income);
        }
        public void IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Невiрний тип");
        }
        public void NormalAge(int age)
        {
            if (age < 18 || age > 70) throw new ArgumentException("Невiрний тип");
        }
        public void Enough(int income) 
        {
            if (income < 0) throw new ArgumentException("Невiрний тип");
        }
    }
}
