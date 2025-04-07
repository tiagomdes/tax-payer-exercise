using System.Globalization;
using Tax.Entities;

namespace Tax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            double total = 0.0;

            Console.Write("Enter the number of tax payer: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (type == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployess = int.Parse(Console.ReadLine());
                    list.Add(new Company(name,anualIncome, numberOfEmployess));
                }
            }

            Console.WriteLine();

            Console.WriteLine("TAXES PAID: ");
            foreach(TaxPayer taxpayer in list)
            {
                Console.WriteLine(taxpayer);
                total += taxpayer.Tax();
            }

            Console.WriteLine();

            Console.WriteLine($"TOTAL TAXES: $ {total.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
