using System.Data;
using DataService.Interfaces;
using DataService.Services;
using Moq;

namespace DataService.Tests.Services.Tests
{
    public class DbServiceTests
    {
        Mock<IQueryService> _mockQueryService;
        IDbService _dbService;

        string _testQuery = "test-query";
        object[] _parm;
        TestModel person1;
        TestModel person2;

        public DbServiceTests()
        {
            _mockQueryService = new();
            _dbService = new DbService(_mockQueryService.Object);

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
        public async void GetAsync_ReturnsSngleRecord_WithValidParamAndQuery()
        {
            _mockQueryService.Setup(
                s => s.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(person1);
            var result = await _dbService.GetAsync<TestModel>(_testQuery, _parm);
            Assert.Equal(person1, result);
            _mockQueryService.Verify(s => s.QuerySingleAsync<TestModel>(_testQuery, _parm), Times.Once);
        }

        [Fact]
        public async void GetAsync_ThrowsExcepton_WithInValidQuery()
        {
            _mockQueryService.Setup(
                s => s.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception("Test exception"));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.GetAsync<TestModel>(_testQuery, _parm)
            );
            _mockQueryService.Verify(
                s => s.QuerySingleAsync<TestModel>(_testQuery, _parm), Times.Once
            );
        }

        [Fact]
        public async void ListAsync_ReturnsRecords_WithValidParamAndQuery()
        {
            var expected = new List<TestModel> {person1, person2};
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
        public async void ListAsync_ThrowsExcepton_WithInValidParam()
        {
            _mockQueryService.Setup(
                s => s.QueryAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception("Test exception"));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.ListAsync<TestModel>(_testQuery, _parm));
            _mockQueryService.Verify(s => s.QueryAsync<TestModel>(_testQuery, _parm), Times.Once);
        }
    }

    public class TestModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTimeOffset DateOfBirth { get; set; } = default!;
    }
}