using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NewsWeb.EF;
using NewsWeb.Entittes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Data
{
    public class TagRepository
    {
        private readonly MainContext context;

        public TagRepository(MainContext context)
        {
            this.context = context;
        }
        public void AddTag(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
        }
        public void RemoveTag(int id)
        {
            var cm = context.Tags.Find(id);
            context.Tags.Remove(cm);
            context.SaveChanges();
        }
        public List<Tag> GetTags()
        {
            return context.Tags.Include(a => a.NewsTag).ToList();

        }


        public void AddTagForNewNews(string tags, int id)
        {
            string[] spearator = { ",", "." };
            string[] words = tags.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            List<Tag> Ids = new List<Tag>();
            for (int i = 0; i < words.Length; i++)
            {

                if (context.Tags.Where(a => a.Name == words[i]).Any())
                {
                    Tag tag = context.Tags.FirstOrDefault(a => a.Name == words[i]);
                    NewsTag newsTag = new NewsTag()
                    {
                        TagId = tag.TagId,
                        NewsId = id
                    };
                    context.NewsTag.Add(newsTag);
                    context.SaveChanges();
                }
                else
                {
                    Tag tag1 = new Tag()
                    {
                        Name = words[i],
                    };
                    context.Tags.Add(tag1);
                    context.SaveChanges();
                    NewsTag newsTag = new NewsTag()
                    {
                        TagId = tag1.TagId,
                        NewsId = id
                    };
                    context.NewsTag.Add(newsTag);
                    context.SaveChanges();
                }
            }

        }
    }
}
