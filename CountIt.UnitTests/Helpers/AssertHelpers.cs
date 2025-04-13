namespace CountIt.UnitTests.Helpers
{
    public class AssertHelpers
    {
        public static void AssertDictionariesAreEqual(Dictionary<string, int> expected, Dictionary<string, int> actual)
        {
            Assert.Equal(expected.Count, actual.Count);

            foreach (var kvp in expected)
            {
                Assert.True(actual.ContainsKey(kvp.Key), $"Key '{kvp.Key}' not found in result");
                Assert.Equal(kvp.Value, actual[kvp.Key]);
            }
        }

        public static bool IsDictionarySorted(Dictionary<string, int> dictionary)
        {
            var keys = dictionary.Keys.ToList();
            for (int i = 1; i < keys.Count; i++)
            {
                if (string.Compare(keys[i - 1], keys[i], StringComparison.Ordinal) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
