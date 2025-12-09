/**********************
 *Annick Nshimirimana
*12/07/2025
*Handles all CRUD operations for Employee objects
*including adding, reading, updating, and deleting
*employees stored in the in-memory list.*/



using Microsoft.Data.Sqlite;
using System.Collections.Generic;

public class EmployeeRepository
{
    private readonly string connectionString = "Data Source=Employee.db";

    public EmployeeRepository()
    {
        using var conn = new SqliteConnection(connectionString);
        conn.Open();

        string createEmployeeTable = @"
            CREATE TABLE IF NOT EXISTS Employees (
                EmployeeID INTEGER PRIMARY KEY,
                Name TEXT NOT NULL,
                Street TEXT,
                City TEXT,
                State TEXT,
                Zip TEXT,
                Type TEXT NOT NULL,
                HourlyRate REAL,
                HoursWorked INTEGER,
                Salary REAL
            );
        ";

        using var cmd = new SqliteCommand(createEmployeeTable, conn);
        cmd.ExecuteNonQuery();
    }

    // CREATE
    public void AddEmployee(Employee e)
    {
        using var conn = new SqliteConnection(connectionString);
        conn.Open();

        string sql = @"
            INSERT INTO Employees
            (EmployeeID, Name, Street, City, State, Zip, Type, HourlyRate, HoursWorked, Salary)
            VALUES (@id, @name, @street, @city, @state, @zip, @type, @rate, @hours, @salary);
        ";

        using var cmd = new SqliteCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id", e.EmployeeID);
        cmd.Parameters.AddWithValue("@name", e.Name);
        cmd.Parameters.AddWithValue("@street", e.Address.Street);
        cmd.Parameters.AddWithValue("@city", e.Address.City);
        cmd.Parameters.AddWithValue("@state", e.Address.State);
        cmd.Parameters.AddWithValue("@zip", e.Address.Zip);

        if (e is HourlyEmployee h)
        {
            cmd.Parameters.AddWithValue("@type", "Hourly");
            cmd.Parameters.AddWithValue("@rate", h.HourlyRate);
            cmd.Parameters.AddWithValue("@hours", h.HoursWorked);
            cmd.Parameters.AddWithValue("@salary", DBNull.Value);
        }
        else if (e is SalariedEmployee s)
        {
            cmd.Parameters.AddWithValue("@type", "Salaried");
            cmd.Parameters.AddWithValue("@rate", DBNull.Value);
            cmd.Parameters.AddWithValue("@hours", DBNull.Value);
            cmd.Parameters.AddWithValue("@salary", s.Salary);
        }

        cmd.ExecuteNonQuery();
    }

    // READ ALL
    public List<Employee> GetAllEmployees()
    {
        List<Employee> list = new();

        using var conn = new SqliteConnection(connectionString);
        conn.Open();

        string sql = "SELECT * FROM Employees";
        using var cmd = new SqliteCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string type = reader.GetString(reader.GetOrdinal("Type"));

            Employee emp =
                type == "Hourly"
                ? new HourlyEmployee
                {
                    HourlyRate = reader["HourlyRate"] == DBNull.Value ? 0 : reader.GetDecimal(reader.GetOrdinal("HourlyRate")),
                    HoursWorked = reader["HoursWorked"] == DBNull.Value ? 0 : reader.GetInt32(reader.GetOrdinal("HoursWorked"))
                }
                : new SalariedEmployee
                {
                    Salary = reader["Salary"] == DBNull.Value ? 0 : reader.GetDecimal(reader.GetOrdinal("Salary"))
                };

            emp.EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID"));
            emp.Name = reader.GetString(reader.GetOrdinal("Name"));
            emp.Address = new Address
            {
                Street = reader["Street"]?.ToString() ?? "",
                City = reader["City"]?.ToString() ?? "",
                State = reader["State"]?.ToString() ?? "",
                Zip = reader["Zip"]?.ToString() ?? ""
            };

            list.Add(emp);
        }

        return list;
    }

    // READ BY ID
    public Employee? GetEmployeeById(int id)
    {
        using var conn = new SqliteConnection(connectionString);
        conn.Open();

        string sql = "SELECT * FROM Employees WHERE EmployeeID = @id";
        using var cmd = new SqliteCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id", id);
        using var r = cmd.ExecuteReader();

        if (!r.Read()) return null;

        string type = r.GetString(r.GetOrdinal("Type"));

        Employee emp =
            type == "Hourly"
            ? new HourlyEmployee
            {
                HourlyRate = r["HourlyRate"] == DBNull.Value ? 0 : r.GetDecimal(r.GetOrdinal("HourlyRate")),
                HoursWorked = r["HoursWorked"] == DBNull.Value ? 0 : r.GetInt32(r.GetOrdinal("HoursWorked"))
            }
            : new SalariedEmployee
            {
                Salary = r["Salary"] == DBNull.Value ? 0 : r.GetDecimal(r.GetOrdinal("Salary"))
            };

        emp.EmployeeID = r.GetInt32(r.GetOrdinal("EmployeeID"));
        emp.Name = r.GetString(r.GetOrdinal("Name"));
        emp.Address = new Address
        {
            Street = r["Street"]?.ToString() ?? "",
            City = r["City"]?.ToString() ?? "",
            State = r["State"]?.ToString() ?? "",
            Zip = r["Zip"]?.ToString() ?? ""
        };

        return emp;
    }

    // UPDATE
    public bool UpdateEmployee(Employee e)
    {
        using var conn = new SqliteConnection(connectionString);
        conn.Open();

        string sql = @"
            UPDATE Employees SET
                Name=@name,
                Street=@street,
                City=@city,
                State=@state,
                Zip=@zip,
                HourlyRate=@rate,
                HoursWorked=@hours,
                Salary=@salary
            WHERE EmployeeID=@id;
        ";

        using var cmd = new SqliteCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id", e.EmployeeID);
        cmd.Parameters.AddWithValue("@name", e.Name);
        cmd.Parameters.AddWithValue("@street", e.Address.Street);
        cmd.Parameters.AddWithValue("@city", e.Address.City);
        cmd.Parameters.AddWithValue("@state", e.Address.State);
        cmd.Parameters.AddWithValue("@zip", e.Address.Zip);

        if (e is HourlyEmployee h)
        {
            cmd.Parameters.AddWithValue("@rate", h.HourlyRate);
            cmd.Parameters.AddWithValue("@hours", h.HoursWorked);
            cmd.Parameters.AddWithValue("@salary", DBNull.Value);
        }
        else if (e is SalariedEmployee s)
        {
            cmd.Parameters.AddWithValue("@rate", DBNull.Value);
            cmd.Parameters.AddWithValue("@hours", DBNull.Value);
            cmd.Parameters.AddWithValue("@salary", s.Salary);
        }

        return cmd.ExecuteNonQuery() > 0;
    }

    // DELETE
    public bool DeleteEmployee(int id)
    {
        using var conn = new SqliteConnection(connectionString);
        conn.Open();

        string sql = "DELETE FROM Employees WHERE EmployeeID=@id";
        using var cmd = new SqliteCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id", id);
        return cmd.ExecuteNonQuery() > 0;
    }
}
