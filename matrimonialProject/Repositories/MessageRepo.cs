using matrimonialProject.Data;
using matrimonialProject.Infrastructure;
using matrimonialProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrimonialProject.Repositories
{
    public class MessageRepo : IMessage
    {
        private readonly ApplicationDbContext _context;
        public MessageRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Message>GetAllReceivedMessage(string userId)
        {
            return _context.Messages.Include(y => y.Sender).Where(x => x.ReceiverId == userId).ToList();
        }

        public List<Message> GetAllSentMessage(string id)
        {
            return _context.Messages.Include(y => y.Receiver).Where(x => x.SenderId == id).ToList();
        }
        public void Insert(Message message)
        {
            _context.Messages.Add(message);
        }
    }
}
