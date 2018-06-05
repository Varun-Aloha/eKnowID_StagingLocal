using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom.XMLClasses;
using EknowIDModel;
using TazWorksCom.HelperClasses;

namespace TazWorksCom.WrapperClasses
{
    public class OrderStateWrapper
    {
        private BackgroundReports _backgroundReports;

        public OrderStateWrapper(BackgroundReports backgroundReports)
        {
            _backgroundReports = backgroundReports;
        }

        public OrderState GetOrderStatus()
        {
            OrderState orderState = new OrderState();

            if (_backgroundReports != null || _backgroundReports.BackgroundReportPackage != null)
            {
                if (!String.IsNullOrEmpty(_backgroundReports.BackgroundReportPackage.ReportURL))
                {
                    orderState.URL = _backgroundReports.BackgroundReportPackage.ReportURL;
                }
                orderState.TazWorksOrderId = Convert.ToInt32(_backgroundReports.BackgroundReportPackage.OrderId);
                orderState.OrderId = Convert.ToInt32(_backgroundReports.BackgroundReportPackage.ReferenceId);
                orderState.TazWorksStatus = (int)Enum.Parse(typeof(TazWorksStatus), _backgroundReports.BackgroundReportPackage.ScreeningStatus.OrderStatus.Substring(2).ToUpper());
                orderState.InsertTime = DateTime.Now;
            }

            return orderState;
        }

        public OrderState GetEnquiryOrderStatus(int orderId, string URL)
        {
            OrderState orderState = new OrderState();

            if (_backgroundReports != null || _backgroundReports.BackgroundReportPackage != null)
            {
                orderState.URL = (!String.IsNullOrEmpty(_backgroundReports.BackgroundReportPackage.ReportURL)) ? _backgroundReports.BackgroundReportPackage.ReportURL : URL;
                orderState.OrderId = (!String.IsNullOrEmpty(_backgroundReports.BackgroundReportPackage.ReferenceId)) ? Convert.ToInt32(_backgroundReports.BackgroundReportPackage.ReferenceId) : orderId;
                orderState.TazWorksOrderId = Convert.ToInt32(_backgroundReports.BackgroundReportPackage.OrderId);
                orderState.TazWorksStatus = (int)Enum.Parse(typeof(TazWorksStatus), _backgroundReports.BackgroundReportPackage.ScreeningStatus.OrderStatus.Substring(2).ToUpper());
                orderState.InsertTime = DateTime.Now;  
            }

            return orderState;
        }


    }
}
