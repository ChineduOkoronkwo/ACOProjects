using DataService.Interfaces;
using DataService.Services;
using DbConnectionFactory;
using DbServiceAcceptanceTest.Dtos;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DbServiceAcceptanceTest.Steps
{
    [Binding]
    public class DbServiceStepsDefinitions
    {
        const string connectionString = "Server=localhost; Port=5432; User Id=testuser; Password=secret; Database=ProductDB";
        const int zero = 0;
        private readonly ScenarioContext _scenarioContext;
        private readonly IDbService _dbService;
        private readonly IQueryService _queryService;
        public DbServiceStepsDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var connFactory = new NpgsqlConnectionFactory();
            var dbConnection = connFactory.GetDbConnection(connectionString);
            _queryService = new QueryService(dbConnection);
            _dbService = new DbService(_queryService);
        }

        [Given("the following ProductBrand")]
        public async Task GivenTheProductBrand(Table table) {
            var sqlCommand = "INSERT INTO product_brands(id, name) Values(@id, @name)";
            var productBrands = GetProductBrands(table);
            foreach (var brand in productBrands)
            {
                var result = await _dbService.CreateAsync(sqlCommand, brand);
                result.Should().Be(1);
            }
            table.RowCount.Should().Be(4);
            _scenarioContext["ProductBrand"] = table;
        }

        [When("I call GetAsync on ProductBrand with (.*)")]
        public async Task WhenICallGetAsyncToFetchAllBrand(string sqlCommand)
        {
            var result = await _dbService.ListAsync<ProductBrand>(sqlCommand, null);
            _scenarioContext["GetAsyncResult"] = result;
        }

        [Then("the ProductBrand details should match what was created")]
        public void ThenFourProductBrands()
        {
            IEnumerable<ProductBrand> actualProductBrands = (IEnumerable<ProductBrand>)_scenarioContext["GetAsyncResult"];
            var expectedProductBrands = GetProductBrands((Table)_scenarioContext["ProductBrand"]);
            actualProductBrands.Should().BeEquivalentTo(expectedProductBrands);
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await CleanUp();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await CleanUp();
        }

        public async Task CleanUp() {
            await _queryService.ExecuteAsync("TRUNCATE TABLE product_brands", null);
        }

        private IEnumerable<ProductBrand> GetProductBrands(Table table) {
            var productBrands = new List<ProductBrand>();
            foreach(var row in table.Rows)
            {
                productBrands.Add(new ProductBrand
                    {
                        Id = Guid.Parse(row["Id"]),
                        Name = row["Name"],
                    });
            }
            return productBrands;
        }
    }
}