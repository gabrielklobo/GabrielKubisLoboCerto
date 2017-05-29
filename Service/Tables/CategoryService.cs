using Models.Tables;
using Persistence.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tables
{
    public class CategoryService
    {

        private CategoryDAL categoryDAL = new CategoryDAL();
        public IQueryable<Category> get() { return categoryDAL.get(); }
        public IQueryable<Category> getCategoriesByName() { return categoryDAL.getCategoriesbyName(); }
        public Category getCategorytById(long? id) { return categoryDAL.getCategorytById(id); }
        public void InsertCategory(Category category) { categoryDAL.InsertCategory(category); }
        public Category deletCategoryById(long? id) { return categoryDAL.deletCategoryById(id); }

    }
}
