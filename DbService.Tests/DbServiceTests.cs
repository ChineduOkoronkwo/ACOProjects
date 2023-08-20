using DBService;
using DBService.interfaces;
using Moq;

namespace DbService.Tests
{
    public class DbServiceTests
    {
        Mock<IQueryService> _mockQueryService;
        IDbService<TestModel> _dbService;
        string _testQuery = "test-query";
        object[] _parm;

        public DbServiceTests()
        {
            _mockQueryService = new();
            _dbService = new DbService<TestModel>(_mockQueryService.Object);
            var person = new TestModel();
            _parm = new object[] {person};
        }

        [Fact]
        public async void TestCreateAsync()
        {
            var expected = 1;
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(expected);
            var result = await _dbService.CreateAsync(_testQuery, _parm);

            Assert.Equal(expected, result);
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestCreateAsyncException()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception("Test exception"));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.CreateAsync(_testQuery, _parm));
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestUpdateAsync()
        {
            var expected = 1;
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(expected);
            var result = await _dbService.UpdateAsync(_testQuery, _parm);

            Assert.Equal(expected, result);
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestUpdateAsyncException()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception("Test exception"));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.UpdateAsync(_testQuery, _parm));
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestDeleteAsync()
        {
            var expected = 1;
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(expected);
            var result = await _dbService.DeleteAsync(_testQuery, _parm);

            Assert.Equal(expected, result);
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestDeleteAsyncException()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception("Test exception"));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.DeleteAsync(_testQuery, _parm));
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestListAsync()
        {
            var expected = new List<TestModel>
            {
                new TestModel() {FirstName = "TestFirstName", LastName = "TestLastName"},
                new TestModel(){FirstName = "SecondTestFirstName", LastName = "SecondTestLastName"}
            };
            _mockQueryService.Setup(
                s => s.QueryAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(expected);
            var result = await _dbService.ListAsync(_testQuery, _parm);
            Assert.Equal(expected, result);
            _mockQueryService.Verify(s => s.QueryAsync<TestModel>(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestListAsyncException()
        {
             _mockQueryService.Setup(
                s => s.QueryAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception("Test exception"));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.ListAsync(_testQuery, _parm));
            _mockQueryService.Verify(s => s.QueryAsync<TestModel>(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestGetAsync()
        {
            var expected = new TestModel() {FirstName = "TestFirstName", LastName = "TestLastName"};
            _mockQueryService.Setup(
                s => s.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(expected);
            var result = await _dbService.GetAsync(_testQuery, _parm);
            Assert.Equal(expected, result);
            _mockQueryService.Verify(s => s.QuerySingleAsync<TestModel>(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void TestGetAsyncException()
        {
            _mockQueryService.Setup(
                s => s.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception("Test exception"));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.GetAsync(_testQuery, _parm));
            _mockQueryService.Verify(s => s.QuerySingleAsync<TestModel>(_testQuery, _parm), Times.Once);
        }
    }

    public class TestModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTimeOffset DateOfBirth { get; set; } = default!;
    }
}