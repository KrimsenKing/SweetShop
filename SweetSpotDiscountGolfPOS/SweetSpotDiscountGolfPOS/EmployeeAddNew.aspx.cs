using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SweetShop;
using SweetSpotDiscountGolfPOS.ClassLibrary;

namespace SweetSpotDiscountGolfPOS
{
    public partial class EmployeeAddNew : System.Web.UI.Page
    {
        locationManager lm = new locationManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empKey"] != null)
            {
                int empNum = (Convert.ToInt32(Session["empKey"].ToString()));
                EmployeeManager empM = new EmployeeManager();
                Employee em = empM.getEmployeeByID(empNum);

                lblFirstNameDisplay.Text = em.firstName.ToString();
                lblLastNameDisplay.Text = em.lastName.ToString();
                lblJobDisplay.Text = empM.jobName(em.jobID);
                lblLocationDisplay.Text = lm.locationName(em.locationID);
                lblEmailDisplay.Text = em.emailAddress.ToString();
                lblPrimaryPhoneNumberDisplay.Text = em.primaryContactNumber.ToString();
                lblSecondaryPhoneNumberDisplay.Text = em.secondaryContactNumber.ToString();
                lblPrimaryAddressDisplay.Text = em.primaryAddress.ToString();
                lblSecondaryAddressDisplay.Text = em.secondaryAddress.ToString();
                lblCityDisplay.Text = em.city.ToString();
                lblPostalCodeDisplay.Text = em.postZip.ToString();
                lblProvinceDisplay.Text = lm.provinceName(em.provState);
                lblCountryDisplay.Text = lm.countryName(em.country);
                
            }
            else
            {
                txtFirstName.Visible = true;
                lblFirstNameDisplay.Visible = false;

                txtLastName.Visible = true;
                lblLastNameDisplay.Visible = false;

                ddlJob.Visible = true;
                lblJobDisplay.Visible = false;

                ddlLocation.Visible = true;
                lblLocationDisplay.Visible = false;

                txtEmail.Visible = true;
                lblEmailDisplay.Visible = false;

                txtPrimaryPhoneNumber.Visible = true;
                lblPrimaryPhoneNumberDisplay.Visible = false;

                txtSecondaryPhoneNumber.Visible = true;
                lblSecondaryPhoneNumberDisplay.Visible = false;

                txtPrimaryAddress.Visible = true;
                lblPrimaryAddressDisplay.Visible = false;

                txtSecondaryAddress.Visible = true;
                lblSecondaryAddressDisplay.Visible = false;
                
                txtCity.Visible = true;
                lblCityDisplay.Visible = false;

                txtPostalCode.Visible = true;
                lblPostalCodeDisplay.Visible = false;

                ddlProvince.Visible = true;
                lblProvinceDisplay.Visible = false;

                ddlCountry.Visible = true;
                lblCountryDisplay.Visible = false;

                btnSaveEmployee.Visible = false;
                btnAddEmployee.Visible = true;
                btnEditEmployee.Visible = false;
                btnCancel.Visible = true;
                btnBackToSearch.Visible = false;
            }

        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            EmployeeManager empM = new EmployeeManager();
            Employee em = new Employee();
            em.firstName = txtFirstName.Text;
            em.lastName = txtLastName.Text;
            em.jobID = ddlJob.SelectedIndex;
            em.locationID = ddlLocation.SelectedIndex;
            em.emailAddress = txtEmail.Text;
            em.primaryContactNumber = txtPrimaryPhoneNumber.Text;
            em.secondaryContactNumber = txtSecondaryPhoneNumber.Text;
            em.primaryAddress = txtPrimaryAddress.Text;
            em.secondaryAddress = txtSecondaryAddress.Text;
            em.city = txtCity.Text;
            em.postZip = txtPostalCode.Text;
            em.provState = ddlProvince.SelectedIndex;
            em.country = ddlCountry.SelectedIndex;

            Session["empKey"] = empM.addEmployee(em);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnEditEmployee_Click(object sender, EventArgs e)
        {

            txtFirstName.Text = lblFirstNameDisplay.Text;
            txtFirstName.Visible = true;
            lblFirstNameDisplay.Visible = false;

            txtLastName.Text = lblLastNameDisplay.Text;
            txtLastName.Visible = true;
            lblLastNameDisplay.Visible = false;

            ddlJob.Text = lblJobDisplay.Text;
            ddlJob.Visible = true;
            lblJobDisplay.Visible = false;

            ddlLocation.Text = lblLocationDisplay.Text;
            ddlLocation.Visible = true;
            lblLocationDisplay.Visible = false;

            txtEmail.Text = lblEmailDisplay.Text;
            txtEmail.Visible = true;
            lblEmailDisplay.Visible = false;

            txtPrimaryPhoneNumber.Text = lblPrimaryPhoneNumberDisplay.Text;
            txtPrimaryPhoneNumber.Visible = true;
            lblPrimaryPhoneNumberDisplay.Visible = false;

            txtSecondaryPhoneNumber.Text = lblSecondaryPhoneNumberDisplay.Text;
            txtSecondaryPhoneNumber.Visible = true;
            lblSecondaryPhoneNumberDisplay.Visible = false;

            txtPrimaryAddress.Text = lblPrimaryAddressDisplay.Text;
            txtPrimaryAddress.Visible = true;
            lblPrimaryAddressDisplay.Visible = false;

            txtSecondaryAddress.Text = lblSecondaryAddressDisplay.Text;
            txtSecondaryAddress.Visible = true;
            lblSecondaryAddressDisplay.Visible = false;
            
            txtCity.Text = lblCityDisplay.Text;
            txtCity.Visible = true;
            lblCityDisplay.Visible = false;

            txtPostalCode.Text = lblPostalCodeDisplay.Text;
            txtPostalCode.Visible = true;
            lblPostalCodeDisplay.Visible = false;

            ddlProvince.Text = lblProvinceDisplay.Text;
            ddlProvince.Visible = true;
            lblProvinceDisplay.Visible = false;

            ddlCountry.Text = lblCountryDisplay.Text;
            ddlCountry.Visible = true;
            lblCountryDisplay.Visible = false;

            btnSaveEmployee.Visible = true;
            btnEditEmployee.Visible = false;
            btnAddEmployee.Visible = false;
            btnCancel.Visible = true;
            btnBackToSearch.Visible = false;

        }
        protected void btnSaveEmployee_Click(object sender, EventArgs e)
        {

            EmployeeManager ssm = new EmployeeManager();
            Employee em = new Employee();
            em.employeeID = Convert.ToInt32(Session["empKey"].ToString());
            em.firstName = txtFirstName.Text;
            em.lastName = txtLastName.Text;
            em.jobID = ddlJob.SelectedIndex;
            em.locationID = ddlLocation.SelectedIndex;
            em.emailAddress = txtEmail.Text;
            em.primaryContactNumber = txtPrimaryPhoneNumber.Text;
            em.secondaryContactNumber = txtSecondaryPhoneNumber.Text;
            em.primaryAddress = txtPrimaryAddress.Text;
            em.secondaryAddress = txtSecondaryAddress.Text;
            em.city = txtCity.Text;
            em.postZip = txtPostalCode.Text;
            em.provState = ddlProvince.SelectedIndex;
            em.country = ddlCountry.SelectedIndex;
            
            ssm.updateEmployee(em);

            txtFirstName.Visible = false;
            lblFirstNameDisplay.Visible = true;
            txtLastName.Visible = false;
            lblLastNameDisplay.Visible = true;
            ddlJob.Visible = false;
            lblJobDisplay.Visible = true;
            ddlLocation.Visible = false;
            lblLocationDisplay.Visible = true;
            txtEmail.Visible = false;
            lblEmailDisplay.Visible = true;
            txtPrimaryPhoneNumber.Visible = false;
            lblPrimaryPhoneNumberDisplay.Visible = true;
            txtSecondaryPhoneNumber.Visible = false;
            lblSecondaryPhoneNumberDisplay.Visible = true;
            txtPrimaryAddress.Visible = false;
            lblPrimaryAddressDisplay.Visible = true;
            txtSecondaryAddress.Visible = false;
            lblSecondaryAddressDisplay.Visible = true;
            txtCity.Visible = false;
            lblCityDisplay.Visible = true;
            txtPostalCode.Visible = false;
            lblPostalCodeDisplay.Visible = true;
            ddlProvince.Visible = false;
            lblProvinceDisplay.Visible = true;
            ddlCountry.Visible = false;
            lblCountryDisplay.Visible = true;
            
            btnSaveEmployee.Visible = false;
            btnEditEmployee.Visible = true;
            btnCancel.Visible = false;
            btnAddEmployee.Visible = false;
            btnBackToSearch.Visible = true;

            Response.Redirect(Request.RawUrl);

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        protected void btnBackToSearch_Click(object sender, EventArgs e)
        {
            Session["empKey"] = null;
            Response.Redirect("SettingsHomePage.aspx");
        }
    }
}