using System.Data;
using Dapper;
using DataService.Interfaces;
using DataService.Services;
using Moq;
using Moq.Dapper;

namespace DataService.Tests.Services.Tests
{
    public class QueryServiceTests
    {
        private const string _testSql = "test-sql";
        private const string _testExceptionMessage = "Test exception";
        private readonly IQueryService _queryService;
        private readonly Mock<IDbConnection> _mockConnection;
        private readonly TestModel _person1;
        private readonly TestModel _person2;

        public QueryServiceTests()
        {
            _mockConnection = new();
            _queryService = new QueryService(_mockConnection.Object);
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
        }

        [Fact]
        public async void QuerySingleAsync_Returns_SingleRecord_With_Parm()
        {
            _mockConnection.SetupDapperAsync(c => c.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).ReturnsAsync(_person1);
            var result = await _queryService.QuerySingleAsync<TestModel>(_testSql, _person1);
            Assert.Equivalent(result, _person1);
        }

        [Fact]
        public async void QuerySingleAsync_Returns_SingleRecord_With_Null_Param()
        {
            _mockConnection.SetupDapperAsync(c => c.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).ReturnsAsync(_person1);
            var result = await _queryService.QuerySingleAsync<TestModel>(_testSql, null);
            Assert.Equivalent(result, _person1);
        }

        [Fact]
        public async void QueryAsync_Returns_ListOfRecords_With_Param()
        {
            var expected = new List<TestModel> { _person1, _person2 };
            _mockConnection.SetupDapperAsync(c => c.QueryAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).ReturnsAsync(expected);
            var result = await _queryService.QueryAsync<TestModel>(_testSql, new object());
            Assert.Equivalent(result, expected);
        }

        [Fact]
        public async void QueryAsync_Returns_ListOfRecords_With_Null_Param()
        {
            var expected = new List<TestModel> { _person1, _person2 };
            _mockConnection.SetupDapperAsync(c => c.QueryAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).ReturnsAsync(expected);
            var result = await _queryService.QueryAsync<TestModel>(_testSql, null);
            Assert.Equivalent(result, expected);
        }
    }
}