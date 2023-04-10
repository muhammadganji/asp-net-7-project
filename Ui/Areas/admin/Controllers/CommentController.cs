using DAL.Servieces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class CommentController : Controller
    {

        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        /// <summary>
        /// نمایش نظرات تایید نشده
        /// </summary>
        public IActionResult Index()
        {
            List<Comment> model = _commentService.GetByChecked(false).ToList();
            return View(model);
        }


        /// <summary>
        /// نمایش همه نظرات
        /// </summary>
        public IActionResult GetAll()
        {
            List<Comment> comments = _commentService.GetAll().ToList();
            return View("Index", comments);
        }


        /// <summary>
        /// پاسخ به نظر
        /// </summary>
        public IActionResult SetReply(Comment comment)
        {
            if (ModelState.IsValid)
            {
                Comment cmt = _commentService.GetById(comment.Id);
                cmt.ReplyComment = comment.ReplyComment ?? "";
                cmt.IsChecked = true;

                _commentService.Update(cmt);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        ///// <summary>
        ///// نمایش کامنت با جزییات کامل
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public IActionResult GetById(int? id)
        //{
        //    CommentDetailViewModel model = new CommentDetailViewModel();
        //    model.comment = _context.comments.Where(c => c.IdComment == id).FirstOrDefault();
        //    model.product = _context.products.Where(p => p.IdProduct == model.comment.IdProduct).FirstOrDefault();
        //    model.user = _context.Users.Where(u => u.UserName == model.comment.UserName).FirstOrDefault();

        //    return View(model);
        //}


        ///// <summary>
        ///// رد نظر
        ///// </summary>
        //public IActionResult Decline(int id)
        //{
        //    Comment c = _commentService.GetById(id);
        //    if (c != null)
        //    {
        //        c.IsChecked = false;
        //        _commentService.Update(c);
        //    }
        //    return RedirectToAction("Index");
        //}

        /// <summary>
        /// حذف نظر
        /// </summary>
        public IActionResult Remove(int id)
        {
            _commentService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
