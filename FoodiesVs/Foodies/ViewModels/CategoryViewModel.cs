using Foodies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public SelectList Parents { get; set; }
    }
}
