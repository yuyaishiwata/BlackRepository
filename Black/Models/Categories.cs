using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;

namespace Black.Models
{
    public class Categories : Models<Category>
    {
        public Categories() {}

        public string Title { get; set; }

        public static async Task<Categories> GetCategoriesAsync(int limit = 10, int offset = 0, string country = "JP")
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("limit", limit.ToString());
            query.Add("offset", offset.ToString());
            query.Add("country", country);

            CategoryPaging wrap = await GetAsync <CategoryPaging>($"/browse/categories?{query}");
            var categories = new Categories();
            categories.LoadPaging(wrap.Paging);

            return categories;
        }
    }
}
