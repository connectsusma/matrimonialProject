using AutoMapper;
using matrimonialProject.Models;
using matrimonialProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrimonialProject.Automapper
{
    public class MyProfile:Profile
    {
        public MyProfile()
        {
            CreateMap<ApplicationUser, SearchViewModel>();
            CreateMap<ApplicationUser, UserViewModel> ();
            CreateMap<MessageViewModel, Message>();
            CreateMap<Message, MessageViewModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Receiver.Name));
            CreateMap<Message, MessageViewModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Sender.Name));

        }
    }
    

    
}
