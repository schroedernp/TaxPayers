using System.Globalization;
using TaxpayersProject.Entities;

List<TaxPayer> list = new List<TaxPayer>();

Console.Write("Enter the number of tax payers: ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    Console.Write("Individual or company (i/c)? ");
    char ch = char.Parse(Console.ReadLine());
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Anual income: ");
    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    if(ch == 'i')
    {
        Console.Write("Health expenditures: ");
        double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        list.Add(new Individual(name, anualIncome, healthExpenditures));
    }
    else
    {
        Console.Write("Number of employees: ");
        int numberOfEmployees = int.Parse(Console.ReadLine());
        list.Add(new Company(name, anualIncome, numberOfEmployees));
    }
}

Console.WriteLine();
Console.WriteLine("TAXES PAID: ");
double sum = 0.0;
foreach (TaxPayer taxPayer in list)
{
    Console.WriteLine(taxPayer.Name + ": $ "+ taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
    sum += taxPayer.Tax();
}
Console.WriteLine();
Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));


