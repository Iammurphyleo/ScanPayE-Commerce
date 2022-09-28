using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EmailServices
{
    public interface IMailServices
    {
        void SendingMail(string MessageSending, string MessageBody, string MessageTitle);
    }
}
