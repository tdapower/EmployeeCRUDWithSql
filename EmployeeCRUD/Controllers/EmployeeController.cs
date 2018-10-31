using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : IEmployeeController
    {
        SqlConnection con = new SqlConnection(@"Data source=.;Initial catalog=EmployeeCRUD;user id=sa;pwd=tdapower;Integrated security=true;");

        public System.Data.DataTable GetAllEmployees()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter("EmployeeGetAll", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Models.Employee GetEmployeeById(int EmployeeID)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter("EmployeeGetByID", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                Models.Employee emp = new Models.Employee();
                emp.EmployeeID = EmployeeID;
                emp.Name = dt.Rows[0]["Name"].ToString();
                emp.EPF = dt.Rows[0]["EPF"].ToString();
                emp.Department = dt.Rows[0]["Department"].ToString();
                emp.Designation = dt.Rows[0]["Designation"].ToString();

                return emp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void DeleteEmployeeById(int EmployeeID)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("EmployeeDeleteByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }

     
        public void SaveEmployee(Models.Employee emp)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("EmployeeCreateOrUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@EPF", emp.EPF);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}