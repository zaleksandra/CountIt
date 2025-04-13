using CountIt.Common.Helpers;
using System.Text.RegularExpressions;

namespace CountIt.Services
{
    public class DocumentService : IDocumentService
    {
        public Dictionary<string, int> CountUniqueWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new Dictionary<string, int>();

            string cleaned = Regex.Replace(input, @"[\d]", "");
            var matches = Regex.Matches(cleaned.ToLower(), @"\b[a-z]+\b");

            var wordCounts = new Dictionary<string, int>();

            foreach (Match match in matches)
            {
                var word = match.Value;
                if (wordCounts.ContainsKey(word))
                    wordCounts[word]++;
                else
                    wordCounts[word] = 1;
            }

            return SortHelper.CustomDictionarySort(wordCounts);
        }
    }
}
