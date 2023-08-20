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
        TestModel person1;
        TestModel person2;

        public DbServiceTests()
        {
            _mockQueryService = new();
            _dbService = new DbService<TestModel>(_mockQueryService.Object);
            person1 = new TestModel()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DateOfBirth = DateTime.Parse("1957-02-06")
            };
            person2 = new TestModel()
            {
                FirstName = "SecondTestFirstName",
                LastName = "SecondTestLastName",
                DateOfBirth = DateTime.Parse("1987-08-20")
            };
            _parm = new object[] {person1};
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
            var expected = new List<TestModel> {person1, person2};
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
            _mockQueryService.Setup(
                s => s.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(person1);
            var result = await _dbService.GetAsync(_testQuery, _parm);
            Assert.Equal(person1, result);
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