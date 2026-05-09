using Common.Application.FileUtil.StorageInterfaces;
using CoreModule.Facade.Category;
using Microsoft.AspNetCore.Mvc;

namespace DevLearn.Web.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ICourseCategoryFacade _categoryFacade;
        private readonly IStorageService _storageService;
        public AjaxController(ICourseCategoryFacade categoryFacade, IStorageService storageService)
        {
            _categoryFacade = categoryFacade;
            _storageService = storageService;
        }

        [Route("/ajax/getCategoryChildren")]
        public async Task<IActionResult> GetCategoryChildren(Guid id)
        {
            var text = "";
            var children = await _categoryFacade.GetChildren(id);
            foreach (var item in children)
            {
                text += $"<option value='{item.Id}'>{item.Title}</option>";
            }
            return new ObjectResult(text);
        }


        [Route("/Upload/ImageUploader")]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload == null)
            {
                return null;
            }
            var fileName = await _storageService.SaveFileAndGenerateName(upload, "wwwroot/images/upload");

            var url = $"/images/upload/{fileName}";
            return Json(new { uploaded = true, url });
        }
    }
}
