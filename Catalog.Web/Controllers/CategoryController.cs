﻿using Catalog.Application.DTOs;
using Catalog.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(InputCategoryDto inputCategoryDto)
        {
            var category = await _categoryService.CreateCategoryAsync(inputCategoryDto);

            var actionName = nameof(GetCategory);
            var routeValue = new { id = category.Id };

            return CreatedAtAction(actionName, routeValue, category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id, InputCategoryDto inputCategoryDto)
        {
            var category = await _categoryService.UpdateCategoryAsync(id, inputCategoryDto);

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return NoContent();
        }
    }
}