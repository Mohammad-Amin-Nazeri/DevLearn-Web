using Common.Query.Filter;
using CoreModule.Facade.Course;
using CoreModule.Query.Course._DTOs;
using DevLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevLearn.Web.Areas.Admin.Pages.Courses;

public class IndexModel : BaseRazorFilter<CourseFilterParams>
{
    private ICourseFacade _courseFacade;

    public IndexModel(ICourseFacade courseFacade)
    {
        _courseFacade = courseFacade;
    }

    public CourseFilterResult FilterResult { get; set; }
    public async Task OnGet()
    {
        FilterResult = await _courseFacade.GetCourseFilter(FilterParams);
    }
}