using ApiHospitales.Data;
using ApiHospitales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHospitales.Repositories
{
    public class RepositoryHospitales
    {
        private HospitalContext context;

        public RepositoryHospitales(HospitalContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            return this.context.Hospitales.ToList();
        }

        public Hospital FindHospital(int id)
        {
            return this.context.Hospitales.FirstOrDefault(z => z.IdHospital == id);
        }

        public void InsertHospital(int id
            , string nombre
            , string direccion
            , string telefono
            , int camas)
        {
            Hospital hospital = new Hospital();
            hospital.IdHospital = id;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            this.context.Hospitales.Add(hospital);
            this.context.SaveChanges();
        }

        public void UpdateHospital(int id
            , string nombre
            , string direccion
            , string telefono
            , int camas)
        {
            Hospital hospital = this.FindHospital(id);
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            this.context.SaveChanges();
        }

        public void DeleteHospital(int id)
        {
            Hospital hospital = this.FindHospital(id);
            this.context.Hospitales.Remove(hospital);
            this.context.SaveChanges();
        }
    }
}
