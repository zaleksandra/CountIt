namespace CountIt.Common.Helpers
{
    public class SortHelper
    {
        public static Dictionary<string, int> CustomDictionarySort(Dictionary<string, int> keyValuePairs)
        {
            var arrryOfKey = SortArray(keyValuePairs.Keys.ToArray());
            Dictionary<string, int> sortedDictionary = new Dictionary<string, int>();

            foreach (var key in arrryOfKey)
            {
                var value = keyValuePairs[key];
                sortedDictionary.Add(key, value);
            }

            return sortedDictionary;
        }

        private static string[] SortArray(string[] array)
        {
            string temp;
            int l = array.Length;

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l - 1; j++)
                {
                    // Compare adjacent strings and swap them if they are in the wrong order
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }
    }
}