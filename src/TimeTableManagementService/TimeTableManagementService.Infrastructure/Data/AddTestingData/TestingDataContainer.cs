//using FinancialManagement.Domain.Entities;
//using HiringService.Domain.Entities;

//namespace HiringService.Infrastructure.Data.AddTestingData;

//public static class TestingDataContainer
//{
//    public static async Task AddTestingData(DataContext context)
//    {
//        CreateTestCandidates(out Expense Candidate1, out Expense Candidate2);

//        CreateTestWorkers(out User Worker1, out User Worker2);

//        CreateTestHiringStageNames(out Debt Prescreen, out Debt English,
//            out Debt TechnicalInterview, out Debt FinalInterview);

//        if (!context.Candidates.Any())
//        {
//            var defaultCandidates = new Expense[] { Candidate1, Candidate2 };

//            context.Candidates.AddRange(defaultCandidates);
//            await context.SaveChangesAsync();
//        }

//        if (!context.Workers.Any())
//        {
//            var defaultWorkers = new User[] { Worker1, Worker2 };

//            context.Workers.AddRange(defaultWorkers);
//            await context.SaveChangesAsync();
//        }

//        if (!context.HiringStageNames.Any())
//        {
//            var defaultStageNames = new Debt[] { Prescreen, English, TechnicalInterview, FinalInterview };

//            context.HiringStageNames.AddRange(defaultStageNames);
//            await context.SaveChangesAsync();
//        }

//        if (!context.HiringStages.Any())
//        {
//            var HiringStage1 = new Category()
//            {
//                Description = "Prescreen was OK",
//                PassedSuccessfully = true,
//                DateTime = new DateTime(2023, 8, 20, 15, 0, 0).ToUniversalTime(),
//                Candidate = Candidate1,
//                Intervier = Worker1,
//                HiringStageName = Prescreen
//            };

//            var HiringStage2 = new Category()
//            {
//                Description = "Candidate has B2 level",
//                PassedSuccessfully = true,
//                DateTime = new DateTime(2023, 8, 23, 15, 0, 0).ToUniversalTime(),
//                Candidate = Candidate1,
//                Intervier = Worker1,
//                HiringStageName = English
//            };

//            var HiringStage3 = new Category()
//            {
//                Description = "Candidate has good tech knowledge",
//                PassedSuccessfully = true,
//                DateTime = new DateTime(2023, 9, 2, 13, 0, 0).ToUniversalTime(),
//                Candidate = Candidate1,
//                Intervier = Worker2,
//                HiringStageName = TechnicalInterview
//            };

//            var HiringStage4 = new Category()
//            {
//                Description = "Prescreen was OK",
//                PassedSuccessfully = true,
//                DateTime = new DateTime(2023, 9, 20, 15, 0, 0).ToUniversalTime(),
//                Candidate = Candidate2,
//                Intervier = Worker2,
//                HiringStageName = Prescreen
//            };

//            var defaultHiringStages = new Category[] 
//            { 
//                HiringStage1, 
//                HiringStage2, 
//                HiringStage3, 
//                HiringStage4 
//            };

//            context.HiringStages.AddRange(defaultHiringStages);
//            await context.SaveChangesAsync();
//        }
//    }

//    private static void CreateTestCandidates(out Expense Candidate1, out Expense Candidate2)
//    {
//        Candidate1 = new Expense()
//        {
//            Name = "Candidate1",
//            Email = "candidate1@gmail.com",
//            CV = "i am candidate1",
//        };

//        Candidate2 = new Expense()
//        {
//            Name = "Candidate2",
//            Email = "candidate2@gmail.com",
//            CV = "i am candidat2",
//        };
//    }

//    private static void CreateTestWorkers(out User Worker1, out User Worker2)
//    {
//        Worker1 = new User()
//        {
//            Name = "worker1",
//            Email = "worker1@gmail.com"
//        };

//        Worker2 = new User()
//        {
//            Name = "worker2",
//            Email = "worker2@gmail.com"
//        };
//    }

//    private static void CreateTestHiringStageNames(
//        out Debt Prescreen, out Debt English,
//        out Debt TechnicalInterview, out Debt FinalInterview)
//    {
//        Prescreen = new Debt()
//        {
//            Name = "Prescreen",
//            Index = 0
//        };

//        English = new Debt()
//        {
//            Name = "English",
//            Index = 1
//        };

//        TechnicalInterview = new Debt()
//        {
//            Name = "Technical interview",
//            Index = 2
//        };

//        FinalInterview = new Debt()
//        {
//            Name = "Final interview",
//            Index = 3
//        };
//    }
//}
