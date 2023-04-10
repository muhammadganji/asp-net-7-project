using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servieces
{
    public class CommentService : ICommentService
    {
        private readonly DatabaseContext _Context;
        public CommentService(DatabaseContext context)
        {
            _Context = context;
        }
        public void Add(Comment comment)
        {
            comment.TimeStampIR = GetTimeStampIR();
            _Context.comments.Add(comment);
            _Context.SaveChanges();
        }

        public bool HasWrittenComment(string userId, int productId)
        {
            bool result = _Context.comments.Where(c => c.ProductId == productId && c.UserId == userId && c.IsDeleted == false).Any();
            return result;
        }

        public IEnumerable<Comment> GetAll()
        {
            List<Comment> comments = new List<Comment>();
            comments = _Context.comments.Where(c => c.IsDeleted == false).ToList();
            return comments;
        }

        public IEnumerable<Comment> GetByChecked(bool IsCkecked)
        {
            List<Comment> comments = new List<Comment>();
            comments = _Context.comments.Where(c => c.IsChecked == IsCkecked && c.IsDeleted == false).ToList();
            return comments;
        }

        public Comment GetById(int Id)
        {
            Comment comment = _Context.comments.Where(c => c.Id == Id && c.IsDeleted == false).FirstOrDefault();
            return comment;
        }

        public IEnumerable<Comment> GetByProductId(int productId)
        {
            List<Comment> comments = new List<Comment>();
            comments = _Context.comments.Where(c => c.ProductId == productId && c.IsChecked == true && c.IsDeleted == false).ToList();
            return comments;
        }

        public IEnumerable<Comment> GetByUserId(string UserId)
        {
            List<Comment> comments = new List<Comment>();
            comments = _Context.comments.Where(c => c.UserId == UserId && c.IsDeleted == false).ToList();
            return comments;
        }

        public void Remove(int commentId)
        {
            Comment c = _Context.comments.Where(c => c.Id == commentId).FirstOrDefault();
            if (c != null)
            {
                c.IsDeleted = true;
                _Context.comments.Update(c);
                _Context.SaveChanges();
            }
        }

        public void Update(Comment comment)
        {
            _Context.comments.Update(comment);
            _Context.SaveChanges();
        }

        //public int GetCountByProductId(int productId)
        //{
        //    int result = _Context.comments.Where(c => c.ProductId == productId).Count();
        //    return result;
        //}


        // 1401-12-10 10:10:10
        private string GetTimeStampIR()
        {
            DateTime dt = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            string result = pc.GetYear(dt).ToString() + "-" +
                pc.GetMonth(dt).ToString() + "-" +
                pc.GetDayOfMonth(dt).ToString() + " " +
                pc.GetHour(dt).ToString() + ":" +
                pc.GetMinute(dt).ToString();
            return result;
        }
    }
}
