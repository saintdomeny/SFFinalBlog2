﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFFinalBlog2.BLL.Services.IServices;
using SFFinalBlog2.BLL.ViewModels.Posts;
using SFFinalBlog2.DAL.Models;

namespace SFFinalBlog2.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public PostController(IPostService postService, UserManager<User> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        /// <summary>
        /// [Get] Метод, показывания поста
        /// </summary>
        [Route("Post/Show")]
        [HttpGet]
        public async Task<IActionResult> ShowPost(Guid id)
        {
            var post = await _postService.ShowPost(id);

            return View(post);
        }

        /// <summary>
        /// [Get] Метод, создания поста
        /// </summary>
        [Route("Post/Create")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreatePost()
        {
            var model = await _postService.CreatePost();

            return View(model);
        }

        /// <summary>
        /// [Post] Метод, создания поста
        /// </summary>
        [Route("Post/Create")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);

            model.AuthorId = user.Id;

            if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Content))
            {
                ModelState.AddModelError("", "Не все поля заполнены");

                return View(model);
            }

            await _postService.CreatePost(model);

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Get] Метод, редактирования поста
        /// </summary>
        [Route("Post/Edit")]
        [HttpGet]
        public async Task<IActionResult> EditPost(Guid id)
        {
            var model = await _postService.EditPost(id);

            return View(model);
        }

        /// <summary>
        /// [Post] Метод, редактирования поста
        /// </summary>
        [Authorize]
        [Route("Post/Edit")]
        [HttpPost]
        public async Task<IActionResult> EditPost(PostEditViewModel model, Guid Id)
        {
            if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Content))
            {
                ModelState.AddModelError("", "Не все поля заполненны");

                return View(model);
            }

            await _postService.EditPost(model, Id);

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Get] Метод, удаления поста
        /// </summary>
        [HttpGet]
        [Route("Post/Remove")]
        public async Task<IActionResult> RemovePost(Guid id, bool confirm = true)
        {
            if (confirm)

                await RemovePost(id);

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Post] Метод, удаления поста
        /// </summary>
        [HttpPost]
        [Route("Post/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        public async Task<IActionResult> RemovePost(Guid id)
        {
            await _postService.RemovePost(id);

            return RedirectToAction("GetPosts", "Post");
        }

        /// <summary>
        /// [Get] Метод, получения всех постов
        /// </summary>
        [HttpGet]
        [Route("Post/Get")]//GetAllPosts
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetPosts();

            return View(posts);
        }
        [HttpGet]
        [Route("Post/GetByAuthor/{authorId}")]
        public async Task<IActionResult> GetPostsByAuthor(string authorId)
        {
            var posts = await _postService.GetPostsByAuthor(authorId);
            return View(posts);
        }
    }
}

