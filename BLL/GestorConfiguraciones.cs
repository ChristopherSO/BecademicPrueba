using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIL.CustomExceptions;

namespace BLL
{
    public class GestorConfiguraciones
    {
        public static String getConnectionString()
        {
            try
            {
                return DAL.Properties.Settings.Default.CONEXIONDB;

            }
            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        public String getValue(string nombre)
        {
            try
            {

                return DAL.Properties.Settings.Default.CONEXIONDB;
                       
            }
            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }
    }
}
