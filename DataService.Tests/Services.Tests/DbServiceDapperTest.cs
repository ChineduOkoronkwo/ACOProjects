using Dapper;
using DataService.Interfaces;
using DataService.Services;
using Moq;
using Moq.Dapper;
using System.Data;

namespace DataService.Tests.Services.Tests
{
    public class DbServiceDapperTest
    {
        private const string _testQuery = "test-query";
        private const string _testExceptionMessage = "Test exception";

        private readonly IDbService _dbService;
        private readonly IQueryService _queryService;
        private readonly Mock<IDbConnection> _mockConnection;
        private readonly object[] _parm;
        private readonly TestModel _person1;
        private readonly TestModel _person2;

        public DbServiceDapperTest()
        {
            _mockConnection = new();
            _queryService = new QueryService(_mockConnection.Object);
            _dbService = new DbService(_queryService);
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
        public async Task GetAsync_ReturnsSingleRecord_From_QuerySingleAsync()
        {
            _mockConnection.SetupDapperAsync(c => c.QuerySingleAsync<TestModel>(It.IsAny<string>(), It.IsAny<object>(), null, null, null)).ReturnsAsync(_person1);
            var result = await _dbService.GetAsync<TestModel>(_testQuery, _person1);
            Assert.Equivalent(result, _person1);
        }
    }
}
