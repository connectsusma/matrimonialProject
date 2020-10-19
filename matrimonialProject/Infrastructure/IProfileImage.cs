using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrimonialProject.Infrastructure
{
    public interface IProfileImage 
    {
        void UploadImage(IFormFile file);


    }
}
 