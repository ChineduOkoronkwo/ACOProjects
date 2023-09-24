// using DataService.Interfaces;
// using DbServiceAcceptanceTest.SoccerPrediction.Models;
// using FluentAssertions;

// namespace DbServiceAcceptanceTest.Utilities.SoccerPredictionsDataMapping
// {
//     public class SoccerPredictionDbLoader
//     {
//         public static async Task LoadCountry(IDbService dbService)
//         {
//             var sqlCommand = "INSERT INTO COUNTRIES(Id, Name, Alpha2, Alpha3, Countrycode, Region, SubRegion, IntermediateRegion, RegionCode, SubRegionCode, IntermediateRegionCode) VALUES(@Id, @Name, @Alpha2, @Alpha3, @Countrycode, @Region, @SubRegion, @IntermediateRegion, @RegionCode, @SubRegionCode, @IntermediateRegionCode);";

// var loader = new CsvLoader<Country>("~/Data/countries.csv");
//             await foreach (var country in loader.ReadFile())
//             {
//                 country.Id = Guid.NewGuid();
//                 var result = await dbService.CreateAsync(sqlCommand, country);
//                 result.Should().Be(1);
//             }
//         }
//     }
// }