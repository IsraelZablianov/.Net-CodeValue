using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            if(MailArrived != null)
            {
                MailArrived(this, e);
            }
        }

        public void SimulateMailArrived(string titleAndBodySeparatedByComma)
        {
            string[] titleAndBody = titleAndBodySeparatedByComma.Split(',');
            OnMailArrived(new MailArrivedEventArgs(titleAndBody[0], titleAndBody[1]));
        }
    }
}
