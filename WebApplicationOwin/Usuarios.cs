using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationOwin
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }

        public List<Usuarios> listaUsers()
        {
            var lista = new List<Usuarios>();
            lista.Add(new Usuarios { Id = 1, Nombre = "jhon", Rol = "Root" });
            lista.Add(new Usuarios { Id = 2, Nombre = "marymar", Rol = "Persona,Cliente" });
            lista.Add(new Usuarios { Id = 3, Nombre = "paula", Rol = "Persona" });
            return lista;
        }
    }
}