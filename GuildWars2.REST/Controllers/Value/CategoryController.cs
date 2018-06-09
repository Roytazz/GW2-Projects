using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using GuildWars2.Data;
using GuildWars2.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildWars2.REST.Controllers.Value
{
    [Route("api/v1/[controller]")]
    public class CategoriesController : BaseController
    {
        [Authorize, HttpGet]
        public IActionResult GetAll() 
        {
            var result = new List<object>();
            foreach (var item in Enum.GetNames(typeof(CategoryType))) {
                result.Add(new { id = (int)Enum.Parse(typeof(CategoryType), item), type = item });
            }
            return Ok(result);
        }

        [Authorize, HttpPost]
        public async Task<IActionResult> Get([FromBody]CategoryModel category) 
        {
            var categories = category.Categories.Select(x => (CategoryType)x).ToList();
            var categoryValues = await UserAPI.GetCategories(categories, UserID, category.AccountID);
            return Ok(categoryValues);
        }
    }

    public class CategoryModel
    {
        public List<int> Categories { get; set; }

        public int AccountID { get; set; }
    }
}