using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EmpleadoCapaNegocio
    {
        public IEnumerable<Empleado> Empleados
        {
            get
            {
                List<Empleado> empleados = new List<Empleado>();

                using (SqlConnection con = new SqlConnection(conexion()))
                {
                    SqlCommand cmd = new SqlCommand("getAllEmpleados", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Empleado empleado = new Empleado();
                        empleado.EmpleadoId = Convert.ToInt32(rdr["EmpleadoId"]);
                        empleado.Nombre = rdr["Nombre"].ToString();
                        empleado.Genero = rdr["Genero"].ToString();
                        empleado.Ciudad = rdr["Ciudad"].ToString();
                        empleado.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);

                        empleados.Add(empleado);
                    }
                    con.Close();
                }
                return empleados;
            }
        }

        public void AddEmpleado(Empleado empleado)
        {
            using (SqlConnection con = new SqlConnection(conexion()))
            {
                SqlCommand cmd = new SqlCommand("addEmpleado", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = empleado.Nombre;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = empleado.Genero;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = empleado.Ciudad;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = empleado.FechaNacimiento;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Empleado SelectEmpleado(int id)
        {
            Empleado empleado = new Empleado();

            empleado = Empleados.Single(emp => emp.EmpleadoId == id);

            return empleado;
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            using (SqlConnection con = new SqlConnection(conexion()))
            {
                SqlCommand cmd = new SqlCommand("updateEmpleado", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = empleado.EmpleadoId;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = empleado.Nombre;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = empleado.Genero;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = empleado.Ciudad;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = empleado.FechaNacimiento;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteEmpleado(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion()))
            {
                SqlCommand cmd = new SqlCommand("deleteEmpleado", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public IEnumerable<Empleado> shearchEmpleado(string shearchNombre)
        {
            List<Empleado> empleados = new List<Empleado>();

            using (SqlConnection con = new SqlConnection(conexion()))
            {
                SqlCommand cmd = new SqlCommand("shearchEmpleado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNombre = new SqlParameter();
                paramNombre.ParameterName = "@nom";
                paramNombre.Value = shearchNombre;
                cmd.Parameters.Add(paramNombre);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.EmpleadoId = Convert.ToInt32(rdr["EmpleadoId"]);
                    empleado.Nombre = rdr["Nombre"].ToString();
                    empleado.Genero = rdr["Genero"].ToString();
                    empleado.Ciudad = rdr["Ciudad"].ToString();
                    empleado.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);

                    empleados.Add(empleado);
                }
                con.Close();
                return empleados;
            }
        }

        private String conexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmpleadoContext"].ConnectionString;
            return connectionString;
        }
    }
}