using EknowIDData.Helper;
using EknowIDLib;
using EknowIDModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TazWorksCom;
using TazWorksCom.HelperClasses;

namespace eknowId.StatusEnquiryService {
    public partial class StatusEnquiryService : ServiceBase {

        private Timer Schedular;
        public StatusEnquiryService() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            WriteErrorLog("eKnowId Order Status enquiry Service started");
            this.ScheduleService();
        }

        protected override void OnStop() {
            WriteErrorLog("eKnowId Order Status enquiry Service stopped");
            this.Schedular.Dispose();

            var sendWithAttachment = new Email() {
                To = Constant.DeveloperEmail,
                From = Constant.FromEmailAddress,
                Subject = Constant.DeveloperEmailSubject,
                DisplayName = Constant.DeveloperEmailDisplayName,
                Attachment = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, ("Logs\\LogFile_" + DateTime.Now.ToString("MMddyyyy") + ".log")),
            };

            SendMail.SendWithAttachment(sendWithAttachment);

            //using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("StatusEnquiryService")) {
            //    serviceController.Start();
            //}
        }

        public void ScheduleService() {
            try {

                Schedular = new Timer(new TimerCallback(SchedularCallback));
                //Set the Default Time.
                DateTime scheduledTime = DateTime.MinValue;

                int intervalHours = Convert.ToInt32(ConfigurationManager.AppSettings["ServiceTimeInterval"]);
                scheduledTime = DateTime.Now.AddHours(intervalHours);               

                if (DateTime.Now > scheduledTime) {
                    //If Scheduled Time is passed set Schedule for the next Interval.
                    scheduledTime = scheduledTime.AddHours(intervalHours);
                }

                TimeSpan timeSpan = scheduledTime.Subtract(DateTime.Now);
                string schedule = string.Format("{0} day(s) {1} hour(s) {2} minute(s) {3} seconds(s)", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

                WriteErrorLog("eKnowId Order Status enquiry Service scheduled to run after: " + schedule);
                WriteErrorLog("*====================================================================================*");

                //Get the difference in Minutes between the Scheduled and Current Time.
                int dueTime = Convert.ToInt32(timeSpan.TotalMilliseconds);

                //Change the Timer's Due Time.
                Schedular.Change(dueTime, Timeout.Infinite);
            } catch (Exception ex) {
                WriteErrorLog(string.Format("eKnowId Order Status enquiry Service Error on: \t\n{0} \t\n{1} ", ex.Message, ex.StackTrace));
                //Stop the Windows Service.
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("StatusEnquiryService")) {
                    if (serviceController.Status == ServiceControllerStatus.Running) {
                        serviceController.Stop();
                    }
                }
            }
        }

        private void SchedularCallback(object e) {
            
            WriteErrorLog("eKnowId Order Status enquiry service started processing all the orders...");
            var exceptions = new ConcurrentQueue<Exception>();

            try {
                ConstructRequest con = new ConstructRequest();

                ////Get the List of Pending Order Ids 
                List<int> pendingOrderId = OrderStatusHelper.GetPendingOrders();
                OrderState pendingOrder;
                if (pendingOrderId.Any()) {
                    WriteErrorLog("eKnowId Order Status enquiry service found " + pendingOrderId.Count() + " pending Orders");

                    //For Each Record in order Id Check for the Response 
                    foreach (int orderId in pendingOrderId) {
                        try {
                            pendingOrder = new OrderState();

                            //Get Last Order Status of the orderID
                            pendingOrder = OrderStatusHelper.GetOrderState(orderId);
                            WriteErrorLog("eKnowId Order Status enquiry service received Last Order Status of the orderID: " + orderId + " as " + pendingOrder.TazWorksStatus);

                            if (pendingOrder.TazWorksStatus != 10 && pendingOrder.TazWorksStatus != 4) {
                                // Send the Xml Reponse and Receive the Status Enquiry and Save it to DataBase
                                OrderState newOrderState = con.XMLStatusEnquiry(orderId);
                                WriteErrorLog("eKnowId Order Status enquiry service Sent Xml Reponse, Received Status Enquiry and Saved it to DataBase for orderID: " + orderId);

                                if (newOrderState.TazWorksStatus == (int)TazWorksStatus.READY || newOrderState.TazWorksStatus == (int)TazWorksStatus.COMPLETED) {
                                    //Create the Pdf If Status is Complete
                                    CreatePDF pdf = new CreatePDF(orderId);
                                    pdf.UrlTOPDF(newOrderState.URL);
                                    WriteErrorLog("eKnowId Order Status enquiry service created pdf for orderID: " + orderId);

                                    //Send Mail To the User 
                                    if (SendMail.Sendmail(newOrderState.OrderId, true)) {
                                        // Mail Sent                                    
                                        WriteErrorLog("Email Sent to user");
                                    } else {   // Mail Not Sent
                                        WriteErrorLog("Failed to send email");
                                    }
                                }
                            }
                        } catch (Exception Ex) {
                            exceptions.Enqueue(Ex);
                        }
                    }
                    WriteErrorLog("eKnowId Order Status enquiry service processed " + pendingOrderId.Count() + "pending Orders");
                    if (0 < exceptions.Count) {
                        WriteErrorLog(new AggregateException(exceptions).Flatten().Message);
                    }
                }
                this.ScheduleService();
            } catch (Exception) {
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("StatusEnquiryService")) {
                    if (serviceController.Status == ServiceControllerStatus.Running) {
                        serviceController.Stop();
                    }
                }
            }
        }

        public static void WriteErrorLog(string message) {
            StreamWriter streamWriter = null;
            try {
                if (!Directory.Exists(string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "Logs"))) {
                    Directory.CreateDirectory(string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "Logs"));
                }
                streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + ("Logs\\LogFile_" + DateTime.Now.ToString("MMddyyyy") + ".log"), true);
                streamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString(), message));
                streamWriter.Flush();
                streamWriter.Close();
            } catch {
            }
        }
    }
}
