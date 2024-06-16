using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        [Display(Name = "Image")]
        public IFormFile? ImgFile { get; set; }
        public decimal Price { get; set; }
        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        public string Img { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }=new List<SelectListItem>();
    }
}
