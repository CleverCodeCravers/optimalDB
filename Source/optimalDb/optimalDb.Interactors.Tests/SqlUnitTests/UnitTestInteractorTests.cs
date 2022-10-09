using NUnit.Framework;
using optimalDb.Contracts;

namespace optimalDb.Interactors.Tests.SqlUnitTests
{
    [TestFixture]
    public class UnitTestInteractorTests
    {
        private UnitTestInteractor GetTestInteractor()
        {
            var test1 = new UnitTest(Guid.NewGuid(), "ConnectionString", "dbo", "TEST_What_is_that");
            var test2 = new UnitTest(Guid.NewGuid(), "ConnectionString", "dbo", "TEST_What_is_that2");

            var unitTestingRepository =
                new UnitTestingRepositoryMock(new[] { test1, test2 });

            var interactor = new UnitTestInteractor(unitTestingRepository);

            return interactor;
        }

        [Test]
        public void UnitTests_can_be_executed_and_the_result_is_stored()
        {
            var interactor = GetTestInteractor();
            interactor.Initialize();

            interactor.SelectUnitTest(interactor.UnitTestList[0]);
            interactor.RunSelectedTests(new UnitTestRunnerMock());

            var results = interactor.UnitTestResults;

            Assert.AreEqual(1, results.Length);
        }

        [Test]
        public void At_the_start_we_detect_all_accessable_databases()
        {
            var interactor = GetTestInteractor();

            Assert.IsEmpty(interactor.UnitTestList);

            interactor.Initialize();

            Assert.IsNotEmpty(interactor.UnitTestList);
        }

        [Test]
        public void The_user_can_select_tests()
        {
            var interactor = GetTestInteractor();
            interactor.Initialize();

            var tests = interactor.UnitTestList;

            Assert.IsEmpty(interactor.SelectedUnitTests);
            interactor.SelectUnitTest(tests[0]);
            Assert.IsNotEmpty(interactor.SelectedUnitTests);
        }

        [Test]
        public void When_the_test_list_is_updated_the_selection_is_lost()
        {
            var interactor = GetTestInteractor();
            interactor.Initialize();

            var tests = interactor.UnitTestList;
            interactor.SelectUnitTest(tests[0]);

            interactor.UpdateUnitTestList();
            Assert.IsEmpty(interactor.SelectedUnitTests);
        }
    }
}