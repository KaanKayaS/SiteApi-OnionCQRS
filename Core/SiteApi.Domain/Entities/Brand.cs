using SiteApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Domain.Entities
{
    public class Brand :EntityBase
    {
        public Brand()
        {
            
        }
        public Brand(string name)       // nesne oluştururken zorunlu alanları bu ctor sayesinde görcez kolaylık sağlıcak
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
