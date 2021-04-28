using Microsoft.EntityFrameworkCore;
using ServiceRDSMysqlAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRDSMysqlAWS.Data
{
    public class DepartamentoContext:DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext> options) : base(options) { }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
