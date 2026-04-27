using System;
using System.Text.Json;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Hobbies { get; set; }
}

class SerializationExample
{
    static void Main(string[] args)
    {
        // ----------------------------
        // 1. Create an object
        // ----------------------------
        Person person = new Person
        {
            Name = "Alice",
            Age = 25,
            Hobbies = new List<string> { "Reading", "Gaming", "Traveling" }
        };

        // ----------------------------
        // 2. Serialize object to JSON
        // ----------------------------
        string jsonString = JsonSerializer.Serialize(person);
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(jsonString);

        // ----------------------------
        // 3. Deserialize JSON to object
        // ----------------------------
        Person deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine("\nDeserialized Object:");
        Console.WriteLine($"Name: {deserializedPerson.Name}");
        Console.WriteLine($"Age: {deserializedPerson.Age}");
        Console.WriteLine("Hobbies: " + string.Join(", ", deserializedPerson.Hobbies));
    }
}