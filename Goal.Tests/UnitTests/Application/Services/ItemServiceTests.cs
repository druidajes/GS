using FluentMediator;
using Goal.Application.Mappers;
using Goal.Application.Services;
using Goal.Domain.Items;
using Goal.Domain.Items.Commands;
using Goal.Tests.UnitTests.Helpers;
using Microsoft.AspNetCore.Http;
using Moq;
using OpenTracing;
using OpenTracing.Mock;
using Xunit;


namespace Goal.Tests.UnitTests.Application.Services
{
    public class ItemServiceTests
    {
        private readonly Mock<IItemRepository> _mockItemRepository = new Mock<IItemRepository>();
        private readonly Mock<IItemFactory> _mockItemFactory = new Mock<IItemFactory>();
        private readonly Mock<ITracer> _mockITracer = new Mock<ITracer>();
        private readonly Mock<IMediator> _mockIMediator = new Mock<IMediator>();
        private static readonly Mock<IHttpContextAccessor> _mockIHttpContextAccessor = new Mock<IHttpContextAccessor>();

        private readonly ItemViewModelMapper _mockItemViewModelMapper = new ItemViewModelMapper(_mockIHttpContextAccessor.Object);

        [Fact]
        public async Task Create_Success()
        {
            //Arrange
            _mockITracer.Setup(x => x.BuildSpan(It.IsAny<string>())).Returns(() => new MockSpanBuilder(new MockTracer(), ""));
            _mockIMediator.Setup(x => x.SendAsync<Item>(It.IsAny<CreateNewItemCommand>(), null))
                .Returns(Task.FromResult(ItemHelper.GetItem()));
            _mockIHttpContextAccessor.Setup(x => x.HttpContext).Returns(HttpContextHelper.GetHttpContext());

            //Act

            var taskService = new ItemService(_mockItemRepository.Object, _mockItemViewModelMapper, _mockITracer.Object, _mockItemFactory.Object, _mockIMediator.Object);
            var result = await taskService.Create(ItemViewModelHelper.GetTaskViewModel());

            //Assert
            Assert.NotNull(result);

            Assert.Equals("Name", result.Name);
            Assert.Equals("Type", result.Type);

            Assert.NotNull(result.Id);
            Assert.NotNull(result.Name);

            _mockITracer.Verify(x => x.BuildSpan(It.IsAny<string>()), Times.Once);
            _mockIMediator.Verify(x => x.SendAsync<Task>(It.IsAny<CreateNewItemCommand>(), null), Times.Once);
        }
    }

}
