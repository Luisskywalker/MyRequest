using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Capa_Entidad;

namespace Capa_Datos
{
    public class MainDAL
    {

        private const string ConnectionString = "server=DESKTOP-84I60LK\\SQLEXPRESS;database=pruebasSql;integrated security=true";

        public List<MainCLS> ShowData()
        {
            List<MainCLS> Lista = null;

            using (SqlConnection cn = new SqlConnection(ConnectionString))

                try
                {
                    //Abre la conexion
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListImgProp", cn))
                    {
                        //indica que el Comando sera un Stored Procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        //Executamos el Comando
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            Lista = new List<MainCLS>();
                            MainCLS oMainCLS;

                            while (drd.Read())
                            {


                                oMainCLS = new MainCLS();
                                oMainCLS.Id = drd.GetInt32(0);
                                oMainCLS.ImageName = drd.GetString(1);
                                oMainCLS.ImageText = drd.GetString(2);
                                oMainCLS.DateConverted = drd.GetDateTime(3);
                                Lista.Add(oMainCLS);
                            }
                        }
                    }
                    //cierra al terminar el Proceso
                    cn.Close();

                }
                catch (Exception ex)
                {
                    //Cierra en caso de una Ex.
                    string msg;
                    msg = ex.ToString();
                    cn.Close();
                }
            return Lista;
        
        }

        public int InsertaData(MainCLS oMainCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(ConnectionString))

                try
                {
                    //Abre la conexion
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspInsImgData", cn))
                    {
                        //indica que el Comando sera un Stored Procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ImageName", oMainCLS.ImageName);
                        cmd.Parameters.AddWithValue("@ImageText", oMainCLS.ImageText);
                        cmd.Parameters.AddWithValue("@DateConverted", oMainCLS.DateConverted);
                        //Regresa la cantidad de registros afectados (en este caso solo es 1)
                        rpta = cmd.ExecuteNonQuery();
                        //cierra al terminar el Proceso
                        cn.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    //Cierra en caso de una Ex.
                    rpta = 0;
                    string msg;
                    msg = ex.ToString();
                    cn.Close();
                }
            return rpta;
        }
    }
}



