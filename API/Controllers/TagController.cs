﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SFFinalBlog2.BLL.Services.IServices;
using SFFinalBlog2.BLL.ViewModels.Tags;
using SFFinalBlog2.DAL.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagSerive;

        public TagController(ITagService tagService)
        {
            _tagSerive = tagService;
        }

        /// <summary>
        /// Получение всех тегов
        /// </summary>
        /// <remarks>
        /// Для получения всех тегов необходимы права администратора
        /// </remarks>
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route("GetTags")]
        public async Task<List<Tag>> GetTags()
        {
            var tags = await _tagSerive.GetTags();

            return tags;
        }

        /// <summary>
        /// Добавление тега
        /// </summary>
        /// <remarks>
        ///
        /// Для добавления тега необходимы права администратора
        /// 
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "#.Net",
        ///     }
        ///
        /// </remarks>
        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route("AddTag")]
        public async Task<IActionResult> AddTag(TagCreateViewModel model)
        {
            var result = await _tagSerive.CreateTag(model);

            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование тега
        /// </summary>
        /// <remarks>
        /// Для редактирования тега необходимы права администратора
        /// </remarks>
        [Authorize(Roles = "Администратор")]
        [HttpPatch]
        [Route("EditTag")]
        public async Task<IActionResult> EditTag(TagEditViewModel model)
        {
            await _tagSerive.EditTag(model, model.Id);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление тега
        /// </summary>
        /// <remarks>
        /// Для удаления тега необходимы права администратора
        /// </remarks>
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route("RemoveTag")]
        public async Task<IActionResult> RemoveTag(Guid id)
        {
            await _tagSerive.RemoveTag(id);

            return StatusCode(201);
        }
    }
}
