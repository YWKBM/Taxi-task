using System;
using System.Collections;
using System.Linq;

namespace TitovFT210007Lab4
{
    static class ArrayExtensions
    {
        public static void Swap(this Array arr, int i, int j)
        {
            object temp = arr.GetValue(i);
            arr.SetValue(arr.GetValue(j), i);
            arr.SetValue(temp, j); 
        }
        public static void BubbleSort(this Array arr, IComparer comparer)
        {
            for (int i = arr.Length - 1; i >= 0; i--) 
            {
                for (int j = 1; j<= i; j++)
                {
                    var element1 = arr.GetValue(j);
                    var element0 = arr.GetValue(j - 1);
                    if (comparer.Compare(element1, element0) > 0)
                    {
                        arr.Swap(j - 1, j);
                    }
                }
            }
        }

    }
     class DistanseRateComparer : IComparer
    {
        public int DistanseRate(Taxi taxi)
        {
            return taxi.distRate;
        }
        public int Compare(object x, object y)
        {
            return DistanseRate((Taxi)x).CompareTo(DistanseRate((Taxi)y)); 
        }
    }
    class DistanseToZeroComparer : IComparer
    {
        public int DistanseToZero(Employee employee)
        {
            return employee.distnace;
        }

        public int Compare(object x, object y)
        {
            return DistanseToZero((Employee)x).CompareTo(DistanseToZero((Employee)y));    
        }
    }
    class Employee
    {
        public int distnace;

        public Employee(int distanse)
        {
            this.distnace = distanse;
        }
    }
    class Taxi
    {
        public int number;
        public int distRate;

        public Taxi(int number, int distRate)
        {
            this.number = number;
            this.distRate = distRate;
        }   
    }
    internal class Program
    {  
        static void Main(string[] args)
        {
            int totalSum = 0;
            
            DistanseRateComparer distanseRateToMaxComparer = new DistanseRateComparer();
            DistanseToZeroComparer distanseToZeroComparer = new DistanseToZeroComparer();

            Console.WriteLine("Enter the quantity of employes: ");
            int empsQuantity = int.Parse(Console.ReadLine());

            Employee[] emp = new Employee[empsQuantity];
            Taxi[] taxi = new Taxi[empsQuantity];

            Console.WriteLine("Enter the employes distance to home: ");
            for(int i = 0; i < empsQuantity; i++)
            {
                Console.WriteLine("Emloye's distance {0}", i + 1);
                emp[i] = new Employee(int.Parse(Console.ReadLine()));    
            }

            for (int i = 0; i < empsQuantity; i++)
            {
                Console.WriteLine("Enter the number of taxi car: ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the rate for distance: ");
                int rate = int.Parse(Console.ReadLine());
                taxi[i] = new Taxi(num, rate);
            }

            taxi.BubbleSort(distanseRateToMaxComparer);
            Array.Reverse(taxi);
            emp.BubbleSort(distanseToZeroComparer);
            

            Console.WriteLine("Taxi number | Price for distanse ");

            for (int i = 0; i < empsQuantity; i++)
            {
                totalSum += taxi[i].distRate * emp[i].distnace;
                Console.WriteLine("{0} {1}", taxi[i].number, taxi[i].distRate * emp[i].distnace);
            }

            Console.WriteLine("Total sum: {0} rub", totalSum);
            ToWord plur = new ToWord();
            Console.WriteLine(plur.DigitToWord(totalSum));
        }
    }
}
