using matrimonialProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrimonialProject.Infrastructure
{
 public   interface IMessage
    {
        void Insert(Message message);
        List<Message> GetAllSentMessage(string id);
        List<Message> GetAllReceivedMessage(string userId);
    }
}
