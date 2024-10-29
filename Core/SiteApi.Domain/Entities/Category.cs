using SiteApi.Domain.Common;
using SiteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }
        public Category(int parentId, string name, int priorty)   // nesne oluştururken zorunlu alanları bu ctor sayesinde görcez kolaylık sağlıcak
        {
            Priorty = priorty;
            ParentId = parentId;
            Name = name;
        }

        
        public int ParentId { get; set; }

        
        public string Name { get; set; }

        
        public int Priorty { get; set; }

        public ICollection<Detail> Details { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

