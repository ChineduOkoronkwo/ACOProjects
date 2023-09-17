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
        private const string ConnectionString = "Server=localhost; Port=5432; User Id=testuser; Password=secret; Database=ProductDB";
        private const int Zero = 0;
        private readonly ScenarioContext _scenarioContext;
        private readonly IDbService _dbService;
        private readonly IQueryService _queryService;

        public DbServiceStepsDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var connFactory = new NpgsqlConnectionFactory();
            var dbConnection = connFactory.GetDbConnection(ConnectionString);
            _queryService = new QueryService(dbConnection);
            _dbService = new DbService(_queryService);
        }

        [Given("the following ProductBrand")]
        public async Task GivenTheProductBrand(Table table)
        {
            var sqlCommand = "INSERT INTO product_brands(id, name) Values(@id, @name)";
            var productBrands = GetProductBrandsFromSpecFlowTable(table);
            foreach (var brand in productBrands)
            {
                var result = await _dbService.CreateAsync(sqlCommand, brand);
                result.Should().Be(1);
            }

            table.RowCount.Should().Be(4);
            _scenarioContext["ProductBrandsTable"] = table;
        }

        [When("I call ListAsync to fetch all ProductBrands")]
        public async Task WhenICallListAsyncToFetchAllBrand()
        {
            var sqlCommand = "SELECT * FROM product_brands;";
            var result = await _dbService.ListAsync<ProductBrand>(sqlCommand, null);
            _scenarioContext["ListAsyncResult"] = result;
        }

        [When("I call GetAsync with the (.*)")]
        public async Task WhenICallGetAsync(string id)
        {
            var getAsyncParam = new BaseEntity { Id = Guid.Parse(id) };
            var sqlCommand = "SELECT * FROM product_brands WHERE id = @id;";
            var result = await _dbService.GetAsync<ProductBrand>(sqlCommand, getAsyncParam);
            _scenarioContext["GetAsyncResult"] = result;
        }

        [When("I call UpdateAsync with the (.*) and (.*)")]
        public async Task WhenICallUpdateAsync(string id, string name)
        {
            var productBrand = GetProductBrand(id, name);
            var sqlCommand = "Update product_brands SET name = @name WHERE id = @id;";
            var result = await _dbService.UpdateAsync(sqlCommand, productBrand);
            result.Should().Be(1);
        }

        [When("I call DeleteAsync with the (.*)")]
        public async Task WhenICallDeleteAsync(string id)
        {
            var param = new BaseEntity { Id = Guid.Parse(id) };
            var sqlCommand = "DELETE FROM product_brands WHERE id = @id;";
            var result = await _dbService.DeleteAsync(sqlCommand, param);
            result.Should().Be(1);
        }

        [Then("the ProductBrand details should match what was created")]
        public void ThenFourProductBrands()
        {
            var actualProductBrands = (IEnumerable<ProductBrand>)_scenarioContext["ListAsyncResult"];
            var expectedProductBrands = GetProductBrandsFromSpecFlowTable((Table)_scenarioContext["ProductBrandsTable"]);
            actualProductBrands.Should().BeEquivalentTo(expectedProductBrands);
        }

        [Then("the ProductBrand should have (.*) and (.*)")]
        public void ThentheProductBrand(string id, string name)
        {
            var productBrand = (ProductBrand)_scenarioContext["GetAsyncResult"];
            id.Should().Be(productBrand.Id.ToString());
            name.Should().Be(productBrand.Name);
        }

        [Then("no ProductBrand should have the (.*) or (.*)")]
        public void TheGetAsyncResultShouldHaveNoResult(string id, string name)
        {
            var actualProductBrands = (IEnumerable<ProductBrand>)_scenarioContext["ListAsyncResult"];
            foreach (var brand in actualProductBrands)
            {
                brand.Id.Should().NotBe(Guid.Parse(id));
                brand.Name.Should().NotBe(name);
            }
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

        public async Task CleanUp()
        {
            await _queryService.ExecuteAsync("TRUNCATE TABLE product_brands", null);
        }

        private IEnumerable<ProductBrand> GetProductBrandsFromSpecFlowTable(Table table)
        {
            var productBrands = new List<ProductBrand>();
            foreach (var row in table.Rows)
            {
                productBrands.Add(GetProductBrand(row["id"], row["name"]));
            }

            return productBrands;
        }

        private ProductBrand GetProductBrand(string id, string name)
        {
            return new ProductBrand { Id = Guid.Parse(id), Name = name };
        }
    }
}