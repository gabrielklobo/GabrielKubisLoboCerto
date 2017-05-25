using Models.Tables;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL.Tables
{
    public class CategoryDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Category> getCategoriesbyName() { return context.Categories.OrderBy(b => b.Name); }
        public Category getCategorytById(long id) { return context.Categories.Where(c => c.CategoryId == id).First(); }
        public void InsertCategory(Category category) { if (category.CategoryId == null) { context.Categories.Add(category); } else { context.Entry(category).State = EntityState.Modified; } context.SaveChanges(); }
        public Category deletCategoryById(long id) { Category category = getCategorytById(id); context.Categories.Remove(category); context.SaveChanges(); return category; }
    }
}
