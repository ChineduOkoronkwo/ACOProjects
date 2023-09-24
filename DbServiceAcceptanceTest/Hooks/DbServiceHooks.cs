using TechTalk.SpecFlow;

namespace DbServiceAcceptanceTest.Hooks
{
    [Binding]
    public class DbServiceHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Create Database
            // 1. Create connection to postgres database
            // 2. Create SoccerPredictions database
            // 3. Create testuser login
            // 4. Grant testuser login all priviledges to the table
            //  testuser needs to have at lease priviledges for Create, Update,
            //  Delete, Read and Truncate on all the tables

            // Load Data
            // Do bulk insert on Country Table
        }
    }
}