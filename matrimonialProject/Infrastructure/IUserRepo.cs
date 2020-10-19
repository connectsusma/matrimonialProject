using matrimonialProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrimonialProject.Infrastructure
{
   public interface IUserRepo
    {
        IList<ApplicationUser> GetAll();
        ApplicationUser GetById(string Id);
        IList<ApplicationUser> GetAllMales();
        IList<ApplicationUser> GetAllFemales();
        IList<ApplicationUser> GetAgeUser(int min,int max);
        IList<ApplicationUser> UserBySalary(int v1,int v2); 


    }
}
