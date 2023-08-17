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
        [Fact]
        public async void Test1()
        {
            var expected = 1;
            var person = new TestModel();
            var testQuery = "test-query";
            Mock<IQueryService> _mockQueryService = new();
            _mockQueryService.Setup(
                s => s.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(expected);

            IDbService<TestModel> _dbService = new DbService<TestModel>(_mockQueryService.Object);
            object[] parm = {person!};
            var result = await _dbService.CreateAsync(testQuery, parm);

            Assert.Equal(expected, result);
            _mockQueryService.Verify(s => s.ExecuteAsync(testQuery, parm), Times.Once);
        }
    }

    public class TestModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTimeOffset DateOfBirth { get; set; } = default!;
    }
}