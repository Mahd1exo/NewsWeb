using Microsoft.EntityFrameworkCore;
using NewsWeb.EF;
using NewsWeb.Entittes;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NewsWeb.Data
{
    public class CategoryRepository
    {
        private readonly MainContext context;

        public CategoryRepository(MainContext context)
        {
            this.context = context;
        }
        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
        public void deleteCategory(int id)
        {
            var cm = context.Categories.Find(id);
            context.Categories.Remove(cm);
            context.SaveChanges();
        }

        public List<Category> GetCategory()
        {
            return context.Categories.Include(a=>a.News).ToList();
        }
    }
}
