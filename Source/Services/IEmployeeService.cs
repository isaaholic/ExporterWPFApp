﻿using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }
}
