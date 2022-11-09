using ApiHospitales.Models;
using ApiHospitales.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHospitales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalesController : ControllerBase
    {
        private RepositoryHospitales repo;

        public HospitalesController(RepositoryHospitales repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Hospital>> GetHospitales()
        {
            return this.repo.GetHospitales();
        }

        [HttpGet("{id}")]
        public ActionResult<Hospital> GetHospital(int id)
        {
            return this.repo.FindHospital(id);
        }

        //PODEMOS TENER MULTIPLES METODOS POST, PUT O DELETE
        //INSERTAR CON OBJETO
        [HttpPost]
        public void InsertDepartamento(Hospital hospital)
        {
            this.repo.InsertHospital(hospital.IdHospital, hospital.Nombre
                , hospital.Direccion, hospital.Telefono, hospital.Camas);
        }

        [HttpPut]
        public void UpdateDepartamento(Hospital hospital)
        {
            this.repo.UpdateHospital(hospital.IdHospital, hospital.Nombre
                , hospital.Direccion, hospital.Telefono, hospital.Camas);
        }

        [HttpDelete("{id}")]
        public void DeleteHospital(int id)
        {
            this.repo.DeleteHospital(id);
        }
    }
}
