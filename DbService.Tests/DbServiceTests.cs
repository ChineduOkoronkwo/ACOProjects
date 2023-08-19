using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBService;
using DBService.interfaces;
using Moq;
using Xunit;

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
        public async void TestExecuteAsync()
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
        public async void TestExecuteAsyncException() {
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ThrowsAsync(new Exception("Test exception"));
            await Assert.ThrowsAsync<Exception>(
                async () => await _dbService.CreateAsync(_testQuery, _parm));
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