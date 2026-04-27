using System;

namespace MoqExample
{
    // Logger interface
    public interface ILoggerService
    {
        void Log(string message);
    }

    // Employee service depends on ILoggerService
    public class EmployeeService
    {
        private readonly ILoggerService _logger;

        public EmployeeService(ILoggerService logger)
        {
            _logger = logger;
        }

        public string AddEmployee(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _logger.Log("Failed to add employee: Name is empty");
                return "Failed";
            }

            _logger.Log($"Employee '{name}' added successfully");
            return "Success";
        }
    }
}