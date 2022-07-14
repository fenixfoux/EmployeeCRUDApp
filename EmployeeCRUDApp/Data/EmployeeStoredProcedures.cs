using EmployeeCRUDApp.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDApp.Data
{
    public class EmployeeStoredProcedures
    {
        //private string _ConnectionString
        //{
        //    get
        //    {
        //        return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    }
        //}
        private string _ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.106.16)(PORT=1521)))(CONNECT_DATA=(SID=sdb)));User ID=DBIRSAN;Password=howlongispi;Pooling=true;";
        private OracleConnection conn;
        private OracleCommand cmd;

        public async Task<string> Add_new_userAsync(Employee employee)
        {
            string result_registration = null;
            await using (conn = new OracleConnection(_ConnectionString))
            {
                await conn.OpenAsync();
                try
                {
                    cmd = new OracleCommand("ADD_EMPLOYEE", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //the result parametr is required to be first on the list of parametres
                    OracleParameter resultParam = new OracleParameter("@Result", OracleDbType.Varchar2, 900);
                    resultParam.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(resultParam);
                    cmd.Parameters.Add("P_FIRSTNAME", employee.FIRSTNAME);
                    cmd.Parameters.Add("P_LASTNAME", employee.LASTNAME);
                    cmd.Parameters.Add("P_MOBILENUMBER", employee.MOBILENUMBER);
                    cmd.Parameters.Add("P_EMAIL", employee.EMAIL);
                    cmd.Parameters.Add("P_ADDRESSLINE1", employee.ADDRESSLINE1);
                    cmd.Parameters.Add("P_ADDRESSLINE2", employee.ADDRESSLINE2);
                    cmd.Parameters.Add("P_CITY", employee.CITY);
                    cmd.Parameters.Add("P_COUNTRY", employee.COUNTRY);
                    cmd.ExecuteNonQuery();

                    if(resultParam.Value != DBNull.Value)
                    {
                        OracleString ret = (OracleString)resultParam.Value;
                        result_registration = ret.ToString();
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error : " + ex);
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    await conn.CloseAsync();
                    await conn.DisposeAsync();
                }
            }
            return result_registration;
        }
    }
}
