using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages {
    public partial class ActivateUserAccount : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Request.QueryString["guid"] != null) {
                    Guid activationCode = Guid.Empty;
                    Guid.TryParse(Request.QueryString["guid"].ToString(), out activationCode);
                    if(Guid.Empty.Equals(activationCode)) {
                        activation_message.InnerText = "You have not activated your eKnowId account. Please use the activation link sent to your registered email address OR contact our support team for further help.";
                    }
                    else {

                        ISpecification<User> useSpc = new Specification<User>(u => u.ActivationCode == activationCode);
                        Repository<User> userWithActivation = new Repository<User>();
                        User users = userWithActivation.SelectAll(useSpc).FirstOrDefault();
                        users.IsActive = true;                        
                        userWithActivation.Save();

                        string userFirstName = (null != users) ? users.FirstName : "";
                        string userLastName = (null != users) ? users.LastName : "";
                        activation_message.InnerText = "Congratulations " + userFirstName + " " + userLastName + " you have successfully activated your eKnowId account. You can now login to your eKnowId account with your user name(emailId) and password";
                    }
                }
            }            
        }
    }
}