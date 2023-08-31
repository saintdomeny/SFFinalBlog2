using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;
using AutoMapper;
using SFFinalBlog2.BLL.Services;
using SFFinalBlog2.BLL.ViewModels.Comments;
using SFFinalBlog2.DAL.Models;
using SFFinalBlog2.DAL.Repositories.IRepositories;
using SFFinalBlog2.Tests;

namespace SFFinalBlog2.Tests
{
	[TestFixture]
	public class CommentServiceTests
	{
		private Mock<IMapper> _mapperMock;
		private Mock<ICommentRepository> _commentRepoMock;
		private CommentService _commentService;

		[SetUp]
		public void SetUp()
		{
			_mapperMock = new Mock<IMapper>();
			_commentRepoMock = new Mock<ICommentRepository>();
			_commentService = new CommentService(_mapperMock.Object, _commentRepoMock.Object);
		}

		[Test]
		public async Task CreateComment_Should_AddComment_And_ReturnCommentId()
		{
			// Arrange
			var model = new CommentCreateViewModel { Content = "Test Content", Author = "Test Author", PostId = Guid.NewGuid() };
			var userId = Guid.NewGuid();
			var addedComment = new Comment { Id = Guid.NewGuid(), Content = model.Content, AuthorName = model.Author, PostId = model.PostId };

			_commentRepoMock.Setup(repo => repo.AddComment(It.IsAny<Comment>())).Callback<Comment>(comment =>
			{
				comment.Id = addedComment.Id; // Simulate setting the Id after adding to repository
			});

			// Act
			var result = await _commentService.CreateComment(model, userId);

			// Assert
			Assert.AreEqual(addedComment.Id, result);
			_commentRepoMock.Verify(repo => repo.AddComment(It.IsAny<Comment>()), Times.Once);
		}

		[Test]
		public async Task EditComment_Should_UpdateComment()
		{
			// Arrange
			var id = Guid.NewGuid();
			var editModel = new CommentEditViewModel { Content = "Updated Content", Author = "Updated Author" };
			var existingComment = new Comment { Id = id, Content = "Old Content", AuthorName = "Old Author" };

			_commentRepoMock.Setup(repo => repo.GetComment(id)).Returns(existingComment);

			// Act
			await _commentService.EditComment(editModel, id);

			// Assert
			Assert.AreEqual(editModel.Content, existingComment.Content);
			Assert.AreEqual(editModel.Author, existingComment.AuthorName);
			_commentRepoMock.Verify(repo => repo.UpdateComment(existingComment), Times.Once);
		}

		[Test]
		public async Task GetComment_Should_ReturnComment_When_ValidId()
		{
			// Arrange
			var id = Guid.NewGuid();
			var expectedComment = new Comment { Id = id, Content = "Test Content", AuthorName = "Test Author" };

			_commentRepoMock.Setup(repo => repo.GetComment(id)).Returns(expectedComment);

			// Act
			var result = await _commentService.GetComment(id);

			// Assert
			Assert.AreEqual(expectedComment, result);
			_commentRepoMock.Verify(repo => repo.GetComment(id), Times.Once);
		}

		[Test]
		public async Task GetComment_Should_ReturnNull_When_InvalidId()
		{
			// Arrange
			var invalidId = Guid.NewGuid();

			_commentRepoMock.Setup(repo => repo.GetComment(invalidId)).Returns((Comment)null);

			// Act
			var result = await _commentService.GetComment(invalidId);

			// Assert
			Assert.IsNull(result);
			_commentRepoMock.Verify(repo => repo.GetComment(invalidId), Times.Once);
		}
		[Test]
		public async Task RemoveComment_Should_RemoveComment_When_ValidId()
		{
			// Arrange
			var id = Guid.NewGuid();

			// Act
			await _commentService.RemoveComment(id);

			// Assert
			_commentRepoMock.Verify(repo => repo.RemoveComment(id), Times.Once);
		}
	}
}