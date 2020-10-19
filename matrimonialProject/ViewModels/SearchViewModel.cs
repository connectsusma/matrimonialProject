using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrimonialProject.ViewModels
{
    public class SearchViewModel
    {
        //public SearchCategory SearchCategory { get; set; }
        public int Selected { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public List<UserViewModel> Users { get; set; }

    }
}
