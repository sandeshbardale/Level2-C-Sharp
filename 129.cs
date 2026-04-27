using System;
using System.Collections.Generic;
using System.Linq;

class GroupByExample
{
    static void Main(string[] args)
    {
        // Creating a list of strings
        List<string> names = new List<string>()
        {
            "Alice", "Bob", "Anil", "Brian", "Charlie", "Chandu"
        };

        // Grouping names by first letter
        var groupedNames = names.GroupBy(name => name[0]);

        Console.WriteLine("Grouped Names:");

        foreach (var group in groupedNames)
        {
            Console.WriteLine("\nGroup: " + group.Key);

            foreach (var name in group)
            {
                Console.WriteLine(name);
            }
        }
    }
}