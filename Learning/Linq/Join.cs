// JOIN
// Combines elements from two collections on a shared key

var employees = new[]
{
    new { EmployeeID = 1, Name = "Greta", DepartmentID = 101 },
    new { EmployeeID = 2, Name = "Olle", DepartmentID = 102 },
    new { EmployeeID = 3, Name = "Charlie", DepartmentID = 103 }
};

var departments = new[]
{
    new { DepartmentID = 101, DepartmentName = "Finance" },
    new { DepartmentID = 102, DepartmentName = "Marketing" },
    new { DepartmentID = 103, DepartmentName = "Engineering" }
};

var result = employees.Join(departments, emp => emp.DepartmentID,   //Outer key selector employee department
    dep => dep.DepartmentID,                                        //Inner key selector department DepartmentID
    (emp, dep) => new { emp.Name, dep.DepartmentName });            //Results in a new list with Name from employees and DepartmentName from departments
