using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class PerformanceOptimizationExample
{
    static void Main(string[] args)
    {
        int n = 1000000;
        List<int> numbers = new List<int>();

        // Fill the list
        for (int i = 0; i < n; i++)
            numbers.Add(i);

        Stopwatch stopwatch = new Stopwatch();

        // ----------------------------
        // 1. Inefficient approach: using string concatenation in loop
        // ----------------------------
        stopwatch.Start();
        string result = "";
        for (int i = 0; i < 10000; i++)
        {
            result += i; // Inefficient, creates many intermediate strings
        }
        stopwatch.Stop();
        Console.WriteLine("Inefficient string concatenation time: " + stopwatch.ElapsedMilliseconds + " ms");

        // ----------------------------
        // 2. Optimized approach: using StringBuilder
        // ----------------------------
        stopwatch.Restart();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < 10000; i++)
        {
            sb.Append(i);
        }
        stopwatch.Stop();
        Console.WriteLine("Optimized StringBuilder time: " + stopwatch.ElapsedMilliseconds + " ms");

        // ----------------------------
        // 3. Inefficient LINQ: multiple enumerations
        // ----------------------------
        stopwatch.Restart();
        var evens1 = numbers.Where(x => x % 2 == 0).Where(x => x % 5 == 0).ToList();
        stopwatch.Stop();
        Console.WriteLine("Inefficient LINQ time: " + stopwatch.ElapsedMilliseconds + " ms");

        // ----------------------------
        // 4. Optimized LINQ: combine predicates
        // ----------------------------
        stopwatch.Restart();
        var evens2 = numbers.Where(x => x % 2 == 0 && x % 5 == 0).ToList();
        stopwatch.Stop();
        Console.WriteLine("Optimized LINQ time: " + stopwatch.ElapsedMilliseconds + " ms");

        // ----------------------------
        // 5. Using local variable instead of repeated calculation
        // ----------------------------
        stopwatch.Restart();
        int sum = 0;
        int count = numbers.Count; // Local variable
        for (int i = 0; i < count; i++)
        {
            sum += numbers[i];
        }
        stopwatch.Stop();
        Console.WriteLine("Loop with local variable time: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}