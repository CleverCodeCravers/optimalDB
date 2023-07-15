using NUnit.Framework;
using optimalDb.Contracts;

namespace optimalDb.Interactors.Tests.SqlCodeSeachTests;

[TestFixture]
public class SqlCodeSearchInteractorTests
{
    //[Test]
    //public void When_the_search_query_matches_the_matching_object_is_returned()
    //{
    //    var index = new IDatabaseObjectWithCode[]
    //    {
    //        new DatabaseObjectWithCode("schema", "findme", "schema.findme", "I am the code")
    //    };
            
    //    var interactor = new SqlCodeSearchInteractor(index);

    //    var result = interactor.SearchFor("the code");

    //    Assert.AreEqual(1, result.Length);
    //}

    //[Test]
    //public void When_the_search_query_does_not_match_the_object_is_not_returned()
    //{
    //    var index = new IDatabaseObjectWithCode[]
    //    {
    //        new DatabaseObjectWithCode("schema", "findme", "schema.findme", "I am the code")
    //    };

    //    //var interactor = new SqlCodeSearchInteractor(index);

    //    var result = interactor.SearchFor("something else");

    //    Assert.AreEqual(0, result.Length);
    //}
}