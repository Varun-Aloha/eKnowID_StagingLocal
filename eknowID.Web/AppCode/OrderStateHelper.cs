using System;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using TazWorksCom;
using EknowIDModel;

namespace eknowID.AppCode
{
    public class OrderStateHelper
    {
        private bool _taskIsRunning = false;
        private OrderState orderstate;
        private void saveOrderStateTask(int orderID, int userID)
        {
            ConstructRequest con = new ConstructRequest();
            con.GetResponse(orderID, userID);
        }

        private void GetOrderStatusEnquiry(int orderID, int userID)
        {
            ConstructRequest con = new ConstructRequest();
            orderstate = con.XMLStatusEnquiry(orderID, userID);
        }

        private delegate void saveOrderStateDelegate(int orderID, int userID);
        private delegate void saveOrderStatusEnquiry(int orderID, int userID);

        public void saveOrderStateAsync(int orderID, int userID)
        {
            saveOrderStateDelegate orderStateDelegate = new saveOrderStateDelegate(saveOrderStateTask);
            AsyncCallback completedCallback = new AsyncCallback(taskCompletedCallback);

            lock (_sync)
            {
                orderStateDelegate.BeginInvoke(orderID, userID, completedCallback, null);
                _taskIsRunning = true;
            }
        }

        private readonly object _sync = new object();

        private void taskCompletedCallback(IAsyncResult ar)
        {
            saveOrderStateDelegate orderStateDelegate = (saveOrderStateDelegate)((AsyncResult)ar).AsyncDelegate;
            AsyncOperation async = (AsyncOperation)ar.AsyncState;

            // finish the asynchronous operation
            orderStateDelegate.EndInvoke(ar);
        }

        public void saveOrderStatusEnquiryAsync(int orderID, int userID)
        {
            saveOrderStatusEnquiry orderStatusEnquiryDelegate = new saveOrderStatusEnquiry(GetOrderStatusEnquiry);
            AsyncCallback enquiryCompletedCallback = new AsyncCallback(enquiryTaskCompletedCallback);

            lock (_sync)
            {
                orderStatusEnquiryDelegate.BeginInvoke(orderID, userID, enquiryCompletedCallback, null);
                _taskIsRunning = true;
            }
        }

        private void enquiryTaskCompletedCallback(IAsyncResult ar)
        {
            saveOrderStatusEnquiry orderStatusEnquiryDelegate = (saveOrderStatusEnquiry)((AsyncResult)ar).AsyncDelegate;
            AsyncOperation async = (AsyncOperation)ar.AsyncState;

            // finish the asynchronous operation
            orderStatusEnquiryDelegate.EndInvoke(ar);
        }
    }
}