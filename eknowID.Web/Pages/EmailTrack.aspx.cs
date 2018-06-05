using eknowID.Services;
using System;
using System.Web;

namespace eknowID.Pages
{
    public partial class EmailTrack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if-modified-since header to determine if receiver has requested the image in last 24 hours
            if (checkIfRequested(this.Context.Request))
            {
                //receiver had already requested the image, hence send back a not modified result
                Response.StatusCode = 304;
                Response.SuppressContent = true;
            }
            else
            {
                Guid assessmentId;
                if (!string.IsNullOrEmpty(Request.QueryString["AssessmentId"]) && Guid.TryParse(Request.QueryString["AssessmentId"], out assessmentId))
                {
                    //The email with assessmentId has been opened, so log that in database
                    //Update email open status by applicant 
                    var packageService = new PackageService();
                    packageService.UpdateEmailTrackStatus(assessmentId);
                }                
            }
        }

        private bool checkIfRequested(HttpRequest req)
        {
            // check if-modified-since header to check if receiver has already requested the image.
            return req.Headers["If-Modified-Since"] == null ? false : true;
        }
    }
}