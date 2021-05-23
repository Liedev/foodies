using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class IndexCategoryViewModel
    {
        public string CategorySearch { get; set; }
        public List<Category> Categories { get; set; }
    }
}
