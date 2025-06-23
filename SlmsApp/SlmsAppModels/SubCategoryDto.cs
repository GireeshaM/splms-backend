using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class SubCategoryDto
    {
        public int SubCategoriesId { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
