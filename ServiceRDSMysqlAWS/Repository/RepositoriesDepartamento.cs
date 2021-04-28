using ServiceRDSMysqlAWS.Data;
using ServiceRDSMysqlAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRDSMysqlAWS.Repository
{
    public class RepositoriesDepartamento
    {

        public DepartamentoContext context;

        public RepositoriesDepartamento(DepartamentoContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetAllDepartamento()
        {
            return this.context.Departamentos.ToList();
        }

        public Departamento GetDepartamento(int id)
        {
            return this.context.Departamentos.SingleOrDefault(x => x.DeptNo == id);
        }
    }
}
