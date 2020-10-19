  using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using matrimonialProject.Models;
using matrimonialProject.Infrastructure;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using matrimonialProject.ViewModels;

namespace matrimonialProject.Controllers
{
    public class HomeController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private IMapper _mapper;
        private readonly IProfileImage _profileImage;




     

        public HomeController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper, IProfileImage profileImage)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _profileImage = profileImage;
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user.Gender == Gender.Male)
                {
                    var onlyMales = _unitOfWork.UserRepo.GetAllMales();
                    var mappedUser = _mapper.Map<List<UserViewModel>>(onlyMales);
                    return View(mappedUser);
                }
                else
                {
                    var onlyFemales = _unitOfWork.UserRepo.GetAllFemales();
                    var mappedUser = _mapper.Map<List<UserViewModel>>(onlyFemales);
                    return View(mappedUser);
                }

            }
            else
            {
                var people = _unitOfWork.UserRepo.GetAll();
                var mappedUser = _mapper.Map<List<UserViewModel>>(people );
                return View(mappedUser);

            }
             
        }

        public IActionResult SelectedUserProfile(string id)
        {
            var userFromRepo = _unitOfWork.UserRepo.GetById(id);
            var mappedUser = _mapper.Map<UserViewModel>(userFromRepo);
            return View(mappedUser);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(MessageViewModel messages)
        {
            string receiverId = TempData["recId"].ToString();
            string senderId = _userManager.GetUserId(User);
            var mappedMessage = _mapper.Map<Message>(messages);
            mappedMessage.ReceiverId = receiverId;
            mappedMessage.SenderId = senderId;
            _unitOfWork.Message.Insert(mappedMessage);
            _unitOfWork.Save();
            return View();

        }

        public IActionResult SentMessages()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                var messages = _unitOfWork.Message.GetAllSentMessage(userId);
                var mappedMessage = _mapper.Map<List<MessageViewModel>>(messages);
                return View(mappedMessage);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ReceivedMessage()
        {
            if(User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                var messages = _unitOfWork.Message.GetAllReceivedMessage(userId);
                var mappedMessage = _mapper.Map<List<MessageViewModel>>(messages);
                return View(mappedMessage);
            }
            else
            {
                return View();
            }
        }

        public IActionResult SearchCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCategory (SearchViewModel vm)
        {
            if (vm.Selected==0)
            {
                ViewBag.ShowResults = true;
                var users = _unitOfWork.UserRepo.GetAgeUser(Convert.ToInt32(vm.Min), Convert.ToInt32(vm.Max));
                vm.Users = _mapper.Map<List<UserViewModel>>(users);
                return View(vm);
            }
            if(vm.Selected==1)
            {
                ViewBag.ShowResults = true;
                var users = _unitOfWork.UserRepo.UserBySalary(Convert.ToInt32(vm.Min), Convert.ToInt32(vm.Max));
                vm.Users = _mapper.Map<List<UserViewModel>>(users);
                return View(vm);

            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
