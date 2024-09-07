using System;

namespace NewsWeb.Entittes
{
    public class Comment
    {
        public Comment()
        {
            IsActive = false;
            PublishCommentDate = DateTime.Now;
        }
        public int CommentId { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }

        public bool IsActive { get; set; }
        public DateTime PublishCommentDate { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
