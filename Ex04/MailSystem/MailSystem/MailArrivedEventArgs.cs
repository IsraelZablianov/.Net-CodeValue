using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailArrivedEventArgs : EventArgs
    {
        private string title;
        private string body;

        public MailArrivedEventArgs(string inputTitle, string inputBody)
        {
            title = inputTitle;
            body = inputBody;
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }
        }
    }
}
