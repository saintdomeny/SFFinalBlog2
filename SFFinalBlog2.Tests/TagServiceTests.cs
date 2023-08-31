using NUnit.Framework;
using Moq;
using AutoMapper;
using SFFinalBlog2.BLL.Services;
using SFFinalBlog2.DAL.Models;
using Microsoft.AspNetCore.Identity;
using SFFinalBlog2.BLL.ViewModels.Users;
using SFFinalBlog2.BLL.ViewModels.Posts;
using SFFinalBlog2.DAL.Repositories.IRepositories;
using SFFinalBlog2.BLL.ViewModels.Tags;
using SFFinalBlog2.BLL.ViewModels.Roles;

namespace SFFinalBlog2.Tests
{
	[TestFixture]
	public class TagServiceTests
	{
		private Mock<ITagRepository> _tagRepoMock;
		private Mock<IMapper> _mapperMock;
		private TagService _tagService;

		[SetUp]
		public void SetUp()
		{
			_tagRepoMock = new Mock<ITagRepository>();
			_mapperMock = new Mock<IMapper>();
			_tagService = new TagService(_tagRepoMock.Object, _mapperMock.Object);
		}

		[Test]
		public async Task CreateTag_Should_Create_Tag()
		{
			// Arrange
			var model = new TagCreateViewModel { Name = "TestTag" };
			var tag = new Tag { Id = Guid.NewGuid(), Name = model.Name };
			_mapperMock.Setup(mapper => mapper.Map<Tag>(model)).Returns(tag);
			_tagRepoMock.Setup(repo => repo.AddTag(tag)).Returns(Task.CompletedTask);

			// Act
			var tagId = await _tagService.CreateTag(model);

			// Assert
			_mapperMock.Verify(mapper => mapper.Map<Tag>(model), Times.Once);
			_tagRepoMock.Verify(repo => repo.AddTag(tag), Times.Once);
			Assert.AreEqual(tag.Id, tagId);
		}

		[Test]
		public async Task EditTag_Should_Edit_Tag()
		{
			// Arrange
			var tagId = Guid.NewGuid();
			var model = new TagEditViewModel { Name = "UpdatedTag" };
			var existingTag = new Tag { Id = tagId, Name = "OldTag" };
			_tagRepoMock.Setup(repo => repo.GetTag(tagId)).Returns(existingTag);
			_tagRepoMock.Setup(repo => repo.UpdateTag(It.IsAny<Tag>())).Returns(Task.CompletedTask);

			// Act
			await _tagService.EditTag(model, tagId);

			// Assert
			_tagRepoMock.Verify(repo => repo.GetTag(tagId), Times.Once);
			_tagRepoMock.Verify(repo => repo.UpdateTag(It.IsAny<Tag>()), Times.Once);
			Assert.AreEqual(model.Name, existingTag.Name);
		}

		[Test]
		public async Task RemoveTag_Should_Remove_Tag()
		{
			// Arrange
			var tagId = Guid.NewGuid();
			_tagRepoMock.Setup(repo => repo.RemoveTag(tagId)).Returns(Task.CompletedTask);

			// Act
			await _tagService.RemoveTag(tagId);

			// Assert
			_tagRepoMock.Verify(repo => repo.RemoveTag(tagId), Times.Once);
		}

		[Test]
		public async Task GetTags_Should_Return_List_Of_Tags()
		{
			// Arrange
			var tags = new HashSet<Tag>
		{
			new Tag { Id = Guid.NewGuid(), Name = "Tag1" },
			new Tag { Id = Guid.NewGuid(), Name = "Tag2" }
		};
			_tagRepoMock.Setup(repo => repo.GetAllTags()).Returns(tags);

			// Act
			var resultTags = await _tagService.GetTags();

			// Assert
			Assert.AreEqual(tags.Count, resultTags.Count);
			foreach (var tag in tags)
			{
				Assert.IsTrue(resultTags.Any(t => t.Id == tag.Id && t.Name == tag.Name));
			}
		}

		[Test]
		public async Task GetTag_Should_Return_Single_Tag()
		{
			// Arrange
			var tagId = Guid.NewGuid();
			var tag = new Tag { Id = tagId, Name = "TestTag" };
			_tagRepoMock.Setup(repo => repo.GetTag(tagId)).Returns(tag);

			// Act
			var resultTag = await _tagService.GetTag(tagId);

			// Assert
			Assert.NotNull(resultTag);
			Assert.AreEqual(tag.Id, resultTag.Id);
			Assert.AreEqual(tag.Name, resultTag.Name);
		}
	}
}