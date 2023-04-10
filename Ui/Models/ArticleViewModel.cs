using Entities;

namespace Ui.Models
{
	public class ArticleViewModel
	{
		public Article Article { get; set; }
		/// <summary>
		/// لیست مقالات
		/// </summary>
		public List<Article> Articles { get; set; }
		/// <summary>
		/// لیست گروه بندی
		/// </summary>
		public List<Category> Categories { get; set; }
	}
}
