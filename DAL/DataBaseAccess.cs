using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

/**
 * Acceso a base de datos
 */

namespace DAL
{
    public class DataBaseAccess
    {
        /**
         * Propiedad que mantiene una conexion única hacia la base de datos, impiendo que se habran multiples conexiones.
         */

        private static SqlConnection _conection;
        private static SqlConnection getConection {
            get {
                if(_conection == null)
                {
                    _conection = new SqlConnection(DAL.Properties.Settings.Default.CONEXIONDB);

                }
                else if(_conection.State == ConnectionState.Closed || _conection.State == ConnectionState.Broken)
                {
                    _conection = new SqlConnection(DAL.Properties.Settings.Default.CONEXIONDB);
                }
                return _conection;
            }
        }

        private DataBaseAccess(){}

        /**
         * Ejecuta un procedimiento almacenado simple
         * Este metodo estatico proporciona una forma sencilla de ejecutar un Stored Procedure sin que este renorne ningun valor
         */
        public static void simpleStoredProcedureRequest(String name, SPP[] parameters = null)
        {
            String storedProcedure = "dbo." + name;
            SqlCommand cmd = new SqlCommand(name, getConection);
            cmd.CommandType = CommandType.StoredProcedure;

            if(parameters != null && parameters.Length > 0)
            {
                foreach (SPP p in parameters)
                {
                    cmd.Parameters.AddWithValue("@" + p.Name, p.Value);
                }
            }
            Console.WriteLine("Command Text: " + cmd.CommandText);
            Console.WriteLine("Command To String: " + cmd.ToString());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /**
         * Advance Store Procedure
         */ 
        public static DataTable advanceStoredProcedureRequest(String name, SPP[] parameters = null)
        {

            String storedProcedure = "dbo." + name;
            SqlCommand cmd = new SqlCommand(name, getConection);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null && parameters.Length > 0)
            {
                foreach (SPP p in parameters)
                {
                    cmd.Parameters.AddWithValue("@" + p.Name, p.Value);   
                }
            }
            Console.WriteLine("Command Text: " + cmd.CommandText);
            Console.WriteLine("Command To String: " + cmd.Parameters.ToString());
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(table);

            return table;
        }

        public static DataTable poblarCmb(SqlCommand pCmd, string pName)
        {
            try
            {
                SqlDataAdapter adp;
                DataTable tempDataset = new DataTable();

                pCmd.Connection = getConection;
                pCmd.CommandText = pName;
                pCmd.CommandType = CommandType.StoredProcedure;
                pCmd.CommandTimeout = 0;

                adp = new SqlDataAdapter(pCmd);
                adp.Fill(tempDataset);

                pCmd.Connection.Close();

                return tempDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
