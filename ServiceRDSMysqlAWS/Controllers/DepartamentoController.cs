using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceRDSMysqlAWS.Models;
using ServiceRDSMysqlAWS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRDSMysqlAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private RepositoriesDepartamento repo;

        public DepartamentoController(RepositoriesDepartamento repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public List<Departamento> GetAllDept()
        {
            return this.repo.GetAllDepartamento();
        }

        [HttpGet("{id}")]
        public Departamento GetDept(int id)
        {
            return this.repo.GetDepartamento(id);
        }
    }
}
