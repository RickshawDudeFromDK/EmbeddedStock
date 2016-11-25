using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbeddedStock.Services
{
    public interface IEmailService
    {
        void SendEmails(List<string> recipients);
    }
}
