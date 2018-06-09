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
    [Route("api/value/[controller]")]
    public class CategoriesController : BaseController
    {
        [Authorize, HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(new { categories = Enum.GetNames(typeof(CategoryType)) });
        }

        [Authorize, HttpPost]
        public async Task<IActionResult> Get([FromBody]CategoryModel category) 
        {
            var categories = category.Categories.Select(x => (CategoryType)Enum.Parse(typeof(CategoryType), x)).ToList();
            var categoryValues = await UserAPI.GetCategories(categories, UserID, category.AccountID);
            var result = new Dictionary<string, CategoryValue>();
            foreach (var item in categoryValues) {
                result[item.Category.ToString()] = item;
            }
            
            return Ok(result);
        }
    }

    public class CategoryModel
    {
        public string[] Categories { get; set; }

        public int AccountID { get; set; }
    }
}