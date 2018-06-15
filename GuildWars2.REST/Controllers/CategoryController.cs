using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildWars2.Data;
using GuildWars2.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GuildWars2.REST.Controllers.Value
{
    [Route("api/v1/[controller]")]
    public class CategoriesController : BaseController
    {
        [Authorize, HttpGet]
        public IActionResult Get() {
            var result = new List<object>();
            foreach (var item in Enum.GetNames(typeof(CategoryValueType))) {
                result.Add(new { id = (int)Enum.Parse(typeof(CategoryValueType), item), type = item });
            }
            return Ok(result);
        }

        [Authorize, HttpPost("values")]
        public async Task<IActionResult> Values([FromBody]CategoriesModel category) {
            if (category == null || category.CategoriesList == null || category.CategoriesList.Count <= 0)
                return BadRequest(ErrorMessage("categories are invalid/missing"));

            var categoryValues = await UserAPI.GetCategoriesTop(category.CategoriesList, category.APIKey);
            return Ok(categoryValues);
        }

        [Authorize, HttpPost("values/history")]
        public async Task<IActionResult> ValueHistory([FromBody]CategoryModel category, [FromQuery]int page = 0, [FromQuery]int pageSize = 200) {
            if (category == null)
                return BadRequest(ErrorMessage("category is missing"));

            var categoryValues = await UserAPI.GetCategoryHistory(category.Category, category.APIKey, page, pageSize);
            return Ok(categoryValues);
        }

        [Authorize, HttpPost("items")]
        public async Task<IActionResult> Items([FromBody]CategoryModel category, [FromQuery]int page = 0, [FromQuery]int pageSize = 200) {
            if (category == null || category.Category == CategoryValueType.Default)
                return BadRequest(ErrorMessage("category is missing"));

            switch (category.Category) {
                case CategoryValueType.Skins:
                    return Ok(await UserAPI.GetSkins(category.APIKey, page, pageSize));
                case CategoryValueType.Dyes:
                    return Ok(await UserAPI.GetDyes(category.APIKey, page, pageSize));
                case CategoryValueType.Minis:
                    return Ok(await UserAPI.GetMinis(category.APIKey, page, pageSize));
                default:
                    return Ok(await UserAPI.GetAccountItems(category.Category, category.APIKey, page, pageSize));
            }
        }
    }

    public class CategoryModel
    {
        public string APIKey { get; set; }

        public CategoryValueType Category { get; set; }
    }

    public class CategoriesModel
    {
        public string APIKey { get; set; }

        public int[] Categories { get; set; }

        [JsonIgnore]
        public List<CategoryValueType> CategoriesList {
            get {
                return Categories.Select(x => (CategoryValueType)x).ToList();
            }
        }
    }
}