using System;

// Class handling only employee details
class Employee
{
    public string Name { get; set; }
    public int ID { get; set; }
}

// Class handling only persistence (saving to database)
class EmployeeRepository
{
    public void Save(Employee emp)
    {
        Console.WriteLine($"Saving {emp.Name} to database.");
    }
}