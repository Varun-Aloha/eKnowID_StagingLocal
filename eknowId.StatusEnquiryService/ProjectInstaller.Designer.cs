namespace eknowId.StatusEnquiryService {
    partial class ProjectInstaller {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.StatusEnquiryServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.StatusEnquiryServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // StatusEnquiryServiceProcessInstaller
            // 
            this.StatusEnquiryServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.StatusEnquiryServiceProcessInstaller.Password = null;
            this.StatusEnquiryServiceProcessInstaller.Username = null;
            // 
            // StatusEnquiryServiceInstaller
            // 
            this.StatusEnquiryServiceInstaller.Description = "eKnowID Order Status Enquiry Service is used to process all Pending Orders";
            this.StatusEnquiryServiceInstaller.DisplayName = "eknowId Order Status Enquiry Service";
            this.StatusEnquiryServiceInstaller.ServiceName = "StatusEnquiryService";
            this.StatusEnquiryServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.StatusEnquiryServiceProcessInstaller,
            this.StatusEnquiryServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller StatusEnquiryServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller StatusEnquiryServiceInstaller;
    }
}