using EknowIDData.Helper;
using EknowIDLib;
using EknowIDModel;
using log4net;
using System;
using System.Collections.Generic;
using TazWorksCom;
using TazWorksCom.HelperClasses;

namespace EknowIDStatusEnquiry
{
    class Program
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Info("Starting the application...");
            Console.WriteLine("Starting the application...");
            try
            {

                #region Main
                ConstructRequest con = new ConstructRequest();

                //Get the List of Pending Order Ids 
                List<int> pendingOrderId = OrderStatusHelper.GetPendingOrders();
                OrderState pendingOrder;

                //For Each Record in order Id Check for the Response 
                foreach (int orderId in pendingOrderId)
                {
                    try
                    {
                        pendingOrder = new OrderState();

                        //Get Last Order Status of the orderID
                        pendingOrder = OrderStatusHelper.GetOrderState(orderId);

                        if (pendingOrder.TazWorksStatus != 10 && pendingOrder.TazWorksStatus != 4)
                        {
                            // Send the Xml Reponse and Receive the Status Enquiry and Save it to DataBase
                            OrderState newOrderState = con.XMLStatusEnquiry(orderId);

                            if (newOrderState.TazWorksStatus == (int)TazWorksStatus.READY || newOrderState.TazWorksStatus == (int)TazWorksStatus.COMPLETED)
                            {
                                //Create the Pdf If Status is Complete
                                CreatePDF pdf = new CreatePDF(orderId);
                                pdf.UrlTOPDF(newOrderState.URL);


                                //Send Mail To the User 
                                if (SendMail.Sendmail(newOrderState.OrderId, true))
                                {
                                    // Mail Sent
                                    Console.WriteLine("Mail Sent...");
                                }
                                else
                                {   // Mail Not Sent
                                    Console.Write("Not Sent...");

                                }
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        log.Error(Ex.Message);
                        Console.WriteLine(Ex.Message);
                    }
                }
                #endregion

                log.Info("Stop the application...");
                Console.WriteLine("Stop the application...");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}