using System.Data;
using DataService.Interfaces;
using DataService.Services;
using Moq;

namespace DataService.Tests.Services.Tests
{
    public class DbServiceTests
    {
        private const string _testQuery = "test-query";
        private const string _testExceptionMessage = "Test exception";

        private readonly Mock<IQueryService> _mockQueryService;
        private readonly IDbService _dbService;
        private readonly object[] _parm;
        private readonly TestModel _person1;
        private readonly TestModel _person2;

        public DbServiceTests()
        {
            _mockQueryService = new();
            _dbService = new DbService(_mockQueryService.Object);

            _person1 = new TestModel()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DateOfBirth = DateTime.Parse("1957-02-06")
            };
            _person2 = new TestModel()
            {
                FirstName = "SecondTestFirstName",
                LastName = "SecondTestLastName",
                DateOfBirth = DateTime.Parse("1987-08-20")
            };
            _parm = new object[] { _person1 };
        }

        [Fact]
        public async void GetAsync_ReturnsSingleRecord_From_QuerySingleAsync()
        {
            _mockQueryService.Setup(
                s => s.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(_person1);
            var result = await _dbService.GetAsync<TestModel>(_testQuery, _parm);
            Assert.Equal(_person1, result);
            _mockQueryService.Verify(s => s.QuerySingleAsync<TestModel>(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void GetAsync_Propagates_Exception_FROM_QuerySingleAsync()
        {
            _mockQueryService.Setup(
                s => s.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception(_testExceptionMessage));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.GetAsync<TestModel>(_testQuery, _parm)
            );
            _mockQueryService.Verify(
                s => s.QuerySingleAsync<TestModel>(_testQuery, _parm), Times.Once
            );
        }

        [Fact]
        public async void ListAsync_ReturnsTwoRecords_From_QueryAsync()
        {
            var expected = new List<TestModel> {_person1, _person2};
            _mockQueryService.Setup(
                s => s.QueryAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(expected);
            var result = await _dbService.ListAsync<TestModel>(_testQuery, _parm);
            Assert.Equal(expected, result);
            _mockQueryService.Verify(
                s => s.QueryAsync<TestModel>(_testQuery, _parm), Times.Once
            );
        }

        [Fact]
        public async void ListAsync_Propagates_Excepton_From_QueryAsync()
        {
            _mockQueryService.Setup(
                s => s.QueryAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception(_testExceptionMessage));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.ListAsync<TestModel>(_testQuery, _parm));
            _mockQueryService.Verify(s => s.QueryAsync<TestModel>(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void CreateAsync_Returns_One_From_ExecuteAsync()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(1);
            var result = await _dbService.CreateAsync(_testQuery, _parm);
            Assert.Equal(1, result);
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void CreateAsync_Propagates_Exception_From_ExecuteAsync()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception(_testExceptionMessage));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.CreateAsync(_testQuery, _parm));
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void UpdateAsync_Returns_One_From_ExecuteAsync()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(1);
            var result = await _dbService.UpdateAsync(_testQuery, _parm);
            Assert.Equal(1, result);
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void UpdateAsync_Propagates_Exception_From_ExecuteAsync()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception(_testExceptionMessage));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.UpdateAsync(_testQuery, _parm));
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void DeleteAsync_Returns_One_From_ExecuteAsync()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(1);
            var result = await _dbService.DeleteAsync(_testQuery, _parm);
            Assert.Equal(1, result);
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void DeleteAsync_Propagates_Exception_From_ExecuteAsync()
        {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception(_testExceptionMessage));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.DeleteAsync(_testQuery, _parm));
            _mockQueryService.Verify(s => s.ExecuteAsync(_testQuery, _parm), Times.Once);
        }
    }

    public class TestModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTimeOffset DateOfBirth { get; set; } = default!;
    }
}