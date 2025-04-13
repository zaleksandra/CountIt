using CountIt.Common.Helpers;
using CountIt.UnitTests.Helpers;

namespace CountIt.UnitTests.Common
{
    public class SortHelperTests
    {
        [Fact]
        public void CustomDictionarySort_ReturnsSortedDictionary()
        {

            Dictionary<string, int> input = new Dictionary<string, int>();
            input["dog"] = 2;
            input["cat"] = 2;
            input["delfin"] = 3;
            input["tiger"] = 2;
            input["fox"] = 1;

            var result = SortHelper.CustomDictionarySort(input);
            
            var expected = new Dictionary<string, int>
           {
               {"cat", 2},
               {"delfin", 3},
               {"dog", 2},
               {"fox", 1},
               {"tiger", 2}
           };

            AssertHelpers.AssertDictionariesAreEqual(expected, result);
            Assert.True(AssertHelpers.IsDictionarySorted(result));

        }
    }
}
