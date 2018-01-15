using System;
using System.Collections.Generic;
using System.Linq;

//Implement the following extension methods for the classes, implementing
//the interface IEnumerable<T> : Sum(), Min(), Max(), Average().

public static class IEnumerableExtensionMethods
{
    public static T Min<T>(this IEnumerable<T> dataSet) where T : IComparable
    {
        T minValue = dataSet.First();
        foreach (T item in dataSet)
        {
            if (item.CompareTo(minValue) < 0)
            {
                minValue = item;
            }
        }

        return minValue;
    }

    public static T Max<T>(this IEnumerable<T> dataSet) where T : IComparable
    {
        T maxValue = dataSet.First();
        foreach (T item in dataSet)
        {
            if (item.CompareTo(maxValue) > 0)
            {
                maxValue = item;
            }
        }

        return maxValue;
    }

    public static decimal Sum<T>(this IEnumerable<T> dataSet)
    {
        decimal sumInput = 0;
        try
        {
            foreach (T item in dataSet)
            {
                sumInput += Convert.ToDecimal(item);
            }
        }
        catch (FormatException formatCheck)
        {
            throw new ArgumentException("The provided value was not in valid format", formatCheck);
        }

        catch (InvalidCastException castCheck)
        {
            throw new ArgumentException("Your input could not be converted", castCheck);
        }

        return sumInput;
    }

    public static decimal Average<T>(this IEnumerable<T> collection)
    {
        decimal sum = collection.Sum();
        decimal average = sum / collection.Count();
        return average;
    }

    public static void DataOperations()
    {
        Console.WriteLine("Please enter digits separated with a comma: ");
        string readData = Console.ReadLine();
        char[] separator = { ',' };
        string[] datToStrArr = readData.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        int[] intArr = new int[datToStrArr.Length];

        for (int index = 0; index < datToStrArr.Length; index++)
        {
            
            try
            {
                intArr[index] = int.Parse(datToStrArr[index]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Provide input is not valid");
                break;
            }
        }

        int min = intArr.Min();
        int max = intArr.Max();
        decimal sum = intArr.Sum();
        decimal average = intArr.Average();
        Console.WriteLine("The results of the data operations are: ");
        Console.WriteLine(" Min = {0}\n Max = {1}\n Sum = {2}\n Average = {3}", min, max, sum, average);
    }

    
}

class MainProgram
{
    public static void Main(string[] args)
    {
        IEnumerableExtensionMethods.DataOperations();
    }
}
