using Microsoft.EntityFrameworkCore;
using NewsWeb.EF;
using NewsWeb.Entittes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Data
{
    public class CommentRepository
    {
        private readonly MainContext context;

        public CommentRepository(MainContext mainContext)
        {
            this.context = mainContext;
        }

        public List<Comment> GetDeactiveComments()
        {
            return context.Comments.Include(a => a.News).Where(a => !a.IsActive).ToList();
        }


        public void ActiveComment(int id)
        {
         var cm=   context.Comments.Find(id);
            cm.IsActive = true;
            context.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            var cm = context.Comments.Find(id);
            context.Comments.Remove(cm);
            context.SaveChanges();
        }

        public object GetComments()
        {
            return context.Comments.Include(a => a.News).ToList();
        }
    }
}
