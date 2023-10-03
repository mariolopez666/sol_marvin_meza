using Business.Entity.Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Data.Access.Layer
{
    public class MatriculaRepository
    {
        private readonly string connectionString;
        public MatriculaRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
        public List<Matricula> ListarMatriculas()
        {
            var lista = new List<Matricula>();
            var connection = new OracleConnection(connectionString);
            connection.Open();
            var cmd = new OracleCommand("select * from matricula", connection);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var matricula = new Matricula();
                matricula.Id = Convert.ToInt32(dr["ID"]);
                matricula.DNI = (string)dr["DNI"];
                matricula.CodAlumno = (string)dr["CodAlumno"];
                matricula.Nombres = (string)dr["Nombres"];
                matricula.Apellidos = (string)dr["Apellidos"];
                matricula.IdCursoSeccion = Convert.ToInt32(dr["IdCursoSeccion"]);
                matricula.Tipo = (string)dr["Tipo"];
                matricula.Estado = Convert.ToInt32(dr["Estado"]);
                matricula.FechaReg = Convert.ToDateTime(dr["FechaReg"]);
                matricula.FechaBaja = dr["FechaBaja"] == DBNull.Value ? null : (DateTime?)dr["FechaBaja"];


                lista.Add(matricula);
            }
            dr.Close();
            connection.Close();
            return lista;
        }

        public Matricula GetMatriculaById(int id)
        {
            var connection = new OracleConnection(connectionString);
            connection.Open();
            Matricula matricula = null;
            var cmd = new OracleCommand("select * from matricula where id = :id", connection);
            cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Int32) { Value = id });
            //cmd.CommandType = CommandType.StoredProcedure;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                matricula = new Matricula();
                matricula.Id = Convert.ToInt32(dr["ID"]);
                matricula.DNI = (string)dr["DNI"];
                matricula.CodAlumno = (string)dr["CodAlumno"];
                matricula.Nombres = (string)dr["Nombres"];
                matricula.Apellidos = (string)dr["Apellidos"];
                matricula.IdCursoSeccion = Convert.ToInt32(dr["IdCursoSeccion"]);
                matricula.Tipo = (string)dr["Tipo"];
                matricula.Estado = Convert.ToInt32(dr["Estado"]);
                matricula.FechaReg = Convert.ToDateTime(dr["FechaReg"]);
                matricula.FechaBaja = dr["FechaBaja"] == DBNull.Value ? null : (DateTime?)dr["FechaBaja"];
            }
            dr.Close();
            connection.Close();
            return matricula;
        }

        public void InsertMatricula(Matricula matricula)
        {
            var connection = new OracleConnection(connectionString);
            connection.Open();
            var cmd = new OracleCommand("insert into Matricula (DNI, CodAlumno, Nombres, Apellidos, IdCursoSeccion, Tipo, Estado, FechaReg) VALUES (:DNI, :CodAlumno, :Nombres, :Apellidos, :IdCursoSeccion, :Tipo, 1, CURRENT_DATE)", connection);
            cmd.Parameters.Add(new OracleParameter("DNI", OracleDbType.Varchar2, 11) { Value = matricula.DNI });
            cmd.Parameters.Add(new OracleParameter("CodAlumno", OracleDbType.Varchar2, 20) { Value = matricula.CodAlumno });
            cmd.Parameters.Add(new OracleParameter("Nombres", OracleDbType.Varchar2, 30) { Value = matricula.Nombres });
            cmd.Parameters.Add(new OracleParameter("Apellidos", OracleDbType.Varchar2, 30) { Value = matricula.Apellidos });
            cmd.Parameters.Add(new OracleParameter("IdCursoSeccion", OracleDbType.Int32) { Value = matricula.IdCursoSeccion });
            cmd.Parameters.Add(new OracleParameter("Tipo", OracleDbType.Varchar2, 20) { Value = matricula.Tipo });
            
            cmd.ExecuteNonQuery();
        }

        public void UpdateMatricula(Matricula matricula)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                connection.Open();
                var cmd = new OracleCommand("UPDATE Matricula SET DNI=:DNI, CodAlumno=:CodAlumno, Nombres=:Nombres, Apellidos=:Apellidos, IdCursoSeccion=:IdCursoSeccion, Tipo=:Tipo WHERE id = :id", connection);
                cmd.Parameters.Add(new OracleParameter("DNI", OracleDbType.Varchar2, 11) { Value = matricula.DNI });
                cmd.Parameters.Add(new OracleParameter("CodAlumno", OracleDbType.Varchar2, 20) { Value = matricula.CodAlumno });
                cmd.Parameters.Add(new OracleParameter("Nombres", OracleDbType.Varchar2, 30) { Value = matricula.Nombres });
                cmd.Parameters.Add(new OracleParameter("Apellidos", OracleDbType.Varchar2, 30) { Value = matricula.Apellidos });
                cmd.Parameters.Add(new OracleParameter("IdCursoSeccion", OracleDbType.Int32) { Value = matricula.IdCursoSeccion });
                cmd.Parameters.Add(new OracleParameter("Tipo", OracleDbType.Varchar2, 20) { Value = matricula.Tipo });
                cmd.Parameters.Add(new OracleParameter("id", OracleDbType.Int32) { Value = matricula.Id });

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMatricula(Matricula Matricula)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                connection.Open();
                var cmd = new OracleCommand("UPDATE Matricula SET FechaBaja=CURRENT_DATE WHERE id = :id", connection);
                cmd.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32) { Value = Matricula.Id });
                cmd.ExecuteNonQuery();
            }
        }
    }
}
