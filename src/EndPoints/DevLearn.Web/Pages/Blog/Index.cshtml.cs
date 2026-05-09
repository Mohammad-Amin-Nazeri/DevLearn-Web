using BlogModule.Services;
using BlogModule.Services.DTOs.Query;
using DevLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevLearn.Web.Pages.Blog
{
    public class IndexModel : BaseRazorFilter<BlogPostFilterParams>
    {
        private IBlogService _blogService;

        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public List<BlogCategoryDto> Categories { get; set; }
        public BlogPostFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _blogService.GetPostsByFilter(FilterParams);
            Categories = await _blogService.GetAllCategories();
        }
    }
}
