using PruebaWindowsForms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace PruebaWindowsForms.DataRead
{
    public static class Operations
    {
        public static string error;

        public static List<Cliente> Read() {
            List<Cliente> lst = null;

            using (TESTEntities db = new TESTEntities())
            {
                lst = (from d in db.Cliente select d).ToList();

                return lst;
            }
        }
        public static void Insert(string nombres, string apellidos, string direccion) {
            Cliente cliente = new Cliente();
            
            if (nombres=="" || apellidos ==""||direccion=="")
            {
                nombres = null;
                apellidos = null;
                direccion = null;
            }
            using (TESTEntities db = new TESTEntities())
            {
                cliente.Nombres = nombres;
                cliente.Apellidos = apellidos;
                cliente.Direccion = direccion;

                db.Cliente.Add(cliente);
                db.SaveChanges();
            }
            
            
        }
        public static void Update(int id,string nombres, string apellidos, string direccion) {
            Cliente cliente = new Cliente();

            if (nombres == "" || apellidos == "" || direccion == "")
            {
                nombres = null;
                apellidos = null;
                direccion = null;
            }
            using (TESTEntities db = new TESTEntities())
            {
                cliente = db.Cliente.Find(id);

                
                cliente.Nombres = nombres;
                cliente.Apellidos = apellidos;
                cliente.Direccion = direccion;

                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Delete(int id) {
            Cliente cliente = new Cliente();
            using (TESTEntities db = new TESTEntities())
            {
                cliente = db.Cliente.Find(id);
                db.Cliente.Remove(cliente);

                db.SaveChanges();
            }
        }
    }
}
