using EmployeeCRUD.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeCRUD.Views
{
    public partial class Employee : System.Web.UI.Page
    {
        IEmployeeController EmployeeController=new EmployeeController();
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                btnDelete.Enabled = false;
                btnDelete.Attributes.Add("onClick","if(confirm('Are you sure to delete?','Confirmation')){}else{return false;}");
                FillGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                Models.Employee emp = new Models.Employee();
                emp.EmployeeID = (hfEmployeeID.Value == "" ? 0 : Convert.ToInt32(hfEmployeeID.Value));
                emp.Name = txtName.Text;
                emp.EPF = txtEPF.Text;
                emp.Department = txtDepartment.Text;
                emp.Designation = txtDesignation.Text;


                EmployeeController.SaveEmployee(emp);

                Clear();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                if (hfEmployeeID.Value == "")
                {
                    lblMessage.Text = "Saved successfully";
                }
                else
                {
                    lblMessage.Text = "Updated successfully";
                }

                FillGrid();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error while saving!";
            }


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeController.DeleteEmployeeById(Convert.ToInt32(hfEmployeeID.Value));
                FillGrid();
                Clear();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Deleted successfully";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error while deleting!";
            }


        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfEmployeeID.Value = "";
            txtName.Text = "";
            txtEPF.Text = "";
            txtDepartment.Text = "";
            txtDesignation.Text = "";

            lblMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        public void FillGrid()
        {
           
            grdEmployees.DataSource = EmployeeController.GetAllEmployees();
            grdEmployees.DataBind();

        }



        protected void lnkView_Click(object sender, EventArgs e)
        {
            int EmployeeId = Convert.ToInt32((sender as LinkButton).CommandArgument);

            Models.Employee emp = EmployeeController.GetEmployeeById(EmployeeId);
        

            hfEmployeeID.Value =   emp.EmployeeID.ToString();
            txtName.Text = emp.Name;
            txtEPF.Text = emp.EPF;
            txtDepartment.Text =emp.Department ;
            txtDesignation.Text =emp.Designation;


            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

    }
}