using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {

        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (SqlConnection connection=new SqlConnection(DL.Conexion.Con()) )
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var query = "LibroAdd";

                        cmd.Connection = connection;
                        cmd.CommandText = query;
                        cmd.CommandType=CommandType.StoredProcedure;

                        connection.Open();

                        SqlParameter[] sqlParameter = new SqlParameter[10];
                        sqlParameter[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        sqlParameter[0].Value = libro.Nombre;
                        sqlParameter[1] = new SqlParameter("NumeroDePaginas", SqlDbType.Int);
                        sqlParameter[1].Value = libro.NumeroPaginas;
                        sqlParameter[2] = new SqlParameter("FechaPublicacion", SqlDbType.Date);
                        sqlParameter[2].Value = libro.FechaPublicacion;
                        sqlParameter[3] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        sqlParameter[3].Value = libro.Edicion;
                        sqlParameter[4] = new SqlParameter("IdAutor", SqlDbType.Int);
                        sqlParameter[4].Value = libro.Autor.IdAutor;
                        sqlParameter[5] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        sqlParameter[5].Value = libro.Editorial.IdEditorial;
                        sqlParameter[6] = new SqlParameter("IdGenero", SqlDbType.Int);
                        sqlParameter[6].Value = libro.Genero.IdGenero;



                        cmd.Parameters.AddRange(sqlParameter);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = ("Los datos se ingresados correctamente");
                        }

                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Ex = ex;
            }

            return result;
        }


    }
}
