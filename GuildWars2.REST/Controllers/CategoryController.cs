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
        [Authorize, HttpGet("all")]
        public IActionResult All() {
            var result = new List<object>();
            foreach (var item in Enum.GetNames(typeof(CategoryValueType))) {
                result.Add(new { id = (int)Enum.Parse(typeof(CategoryValueType), item), type = item });
            }
            return Ok(result);
        }

        [Authorize, HttpPost]
        public async Task<IActionResult> Get([FromBody]CategoryModel category) {
            if (category == null || category.CategoriesList == null || category.CategoriesList.Count <= 0)
                return BadRequest(ErrorMessage("categories are invalid/missing"));

            var categoryValues = await UserAPI.GetCategoriesTop(category.CategoriesList, category.APIKey);
            return Ok(categoryValues);
        }

        [Authorize, HttpPost("history")]
        public async Task<IActionResult> History([FromBody]CategoryHistoryModel category, [FromQuery]int page = 0, [FromQuery]int pageSize = 200) {
            if (category == null)
                return BadRequest(ErrorMessage("category is missing"));

            var categoryValues = await UserAPI.GetCategoryHistory(category.Category, category.APIKey, page, pageSize);
            return Ok(categoryValues);
        }
    }

    public class CategoryModel
    {
        public int[] Categories { get; set; }

        public string APIKey { get; set; }

        [JsonIgnore]
        public List<CategoryValueType> CategoriesList {
            get {
                return Categories.Select(x => (CategoryValueType)x).ToList();
            }
        }
    }

    public class CategoryHistoryModel
    {
        public string APIKey { get; set; }

        public CategoryValueType Category { get; set; }
    }
}