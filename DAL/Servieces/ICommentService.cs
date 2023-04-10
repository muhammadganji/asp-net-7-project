using Entities;

namespace DAL.Servieces
{
    public interface ICommentService
    {
        void Add(Comment comment);
        void Update(Comment comment);
        void Remove(int Id);
        Comment GetById(int Id);
        IEnumerable<Comment> GetAll();
        IEnumerable<Comment> GetByUserId(string UserId);
        IEnumerable<Comment> GetByProductId(int productId);
        IEnumerable<Comment> GetByChecked(bool IsCkecked);

        /// <summary>
        /// check user has ONE comment about special product
        /// </summary>
        /// <returns>true: if has any comment about product else False</returns>
        bool HasWrittenComment(string userId, int productId);
        //int GetCountByProductId(int productId);

    }
}
