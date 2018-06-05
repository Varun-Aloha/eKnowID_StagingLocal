using eknowID.AppCode;
using eknowID.Services;
using System;
using System.Web.UI;

using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class Dashboard : System.Web.UI.Page, IAuthenticationRequired
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            var requestorOrders = new PackageService().GetRequesterOrderDetail(SessionWrapper.LoggedUser.UserId);
            gridOrdersList.DataSource = requestorOrders.Orders;
            gridOrdersList.DataBind();
        }

        protected void gridOrdersList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridOrdersList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridOrdersList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //TableCell OrderState = e.Row.Cells[3];

                Label lblUserID = (Label)e.Row.FindControl("lblStatus");
                HyperLink rptLink = (HyperLink)e.Row.FindControl("hypReport");


                if (lblUserID.Text == "0")
                {
                    lblUserID.Text = "Pending";
                    lblUserID.CssClass = "order-status in-progress";
                    lblUserID.Visible = true;
                }

                if (lblUserID.Text == "1")
                {
                    lblUserID.Text = "Pending";
                    lblUserID.CssClass = "order-status in-progress";
                    lblUserID.Visible = true;
                }
                else if (lblUserID.Text == "2")
                {
                    lblUserID.Text = "In Progress";
                    lblUserID.CssClass = "order-status in-progress";
                    lblUserID.Visible = true;
                }
                else if (lblUserID.Text == "10")
                {
                    string navigateUrl = rptLink.Text;
                    rptLink.Text = "Ready";
                    rptLink.CssClass = "order-status in-progress";
                    rptLink.Visible = true;
                    rptLink.NavigateUrl = navigateUrl;
                }
            }
        }

        protected void gridOrdersList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}