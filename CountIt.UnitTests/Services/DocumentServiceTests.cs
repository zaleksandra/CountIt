using CountIt.Services;
using CountIt.UnitTests.Helpers;

namespace BasicFit.UnitTests
{
    public class DocumentServiceTests
    {
        private readonly DocumentService service;

        public DocumentServiceTests()
        {
            service = new DocumentService();
        }

        [Fact]
        public void CountUniqueWords_WithEmptyInput_ReturnsEmptyDictionary()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void CountUniqueWords_WithNullInput_ReturnsEmptyDictionary()
        {
            // Arrange
            string input = null;

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void CountUniqueWords_WithValidText_ReturnsCorrectWordCounts()
        {
            // Arrange
            string input = "Squat squat Deadlift deadlift Bench bench";
            var expected = new Dictionary<string, int>
            {
                { "squat", 2 },
                { "deadlift", 2 },
                { "bench", 2 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
        }

        [Fact]
        public void CountUniqueWords_WithNumbers_RemovesNumbers()
        {
            // Arrange
            string input = "Squat 3x12 Deadlift 5x5 Bench 4x8";
            var expected = new Dictionary<string, int>
            {
                { "squat", 1 },
                { "deadlift", 1 },
                { "bench", 1 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
        }

        [Fact]
        public void CountUniqueWords_WithSpecialCharacters_HandlesSpecialCharacters()
        {
            // Arrange
            string input = "Squat! Deadlift? Bench...";
            var expected = new Dictionary<string, int>
            {
                { "squat", 1 },
                { "deadlift", 1 },
                { "bench", 1 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
        }

        [Fact]
        public void CountUniqueWords_WithMixedCase_ConvertsToLowerCase()
        {
            // Arrange
            string input = "SQUAT Squat squat";
            var expected = new Dictionary<string, int>
            {
                { "squat", 3 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
        }

        [Fact]
        public void CountUniqueWords_WithMultipleSpaces_HandlesMultipleSpaces()
        {
            // Arrange
            string input = "Squat    Deadlift    Bench";
            var expected = new Dictionary<string, int>
            {
                { "squat", 1 },
                { "deadlift", 1 },
                { "bench", 1 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
        }

        [Fact]
        public void CountUniqueWords_WithPunctuation_HandlesPunctuation()
        {
            // Arrange
            string input = "Squat, Deadlift! Squat; Bench.";
            var expected = new Dictionary<string, int>
            {
                { "squat", 2 },
                { "deadlift", 1 },
                { "bench", 1 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
        }

        [Fact]
        public void CountUniqueWords_WithNewlines_HandlesNewlines()
        {
            // Arrange
            string input = "Squat\nDeadlift\nSquat\nBench";
            var expected = new Dictionary<string, int>
            {
                { "squat", 2 },
                { "deadlift", 1 },
                { "bench", 1 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
        }

        [Fact]
        public void CountUniqueWords_WithTabs_HandlesTabs()
        {
            // Arrange
            string input = "Squat\tDeadlift\tSquat\tBench";
            var expected = new Dictionary<string, int>
            {
                { "squat", 2 },
                { "deadlift", 1 },
                { "bench", 1 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
        }

        [Fact]
        public void CountUniqueWords_WithSortedOutput_ReturnsSortedDictionary()
        {
            // Arrange
            string input = "Squat Deadlift Bench Squat";
            var expected = new Dictionary<string, int>
            {
                { "bench", 1 },
                { "deadlift", 1 },
                { "squat", 2 }
            };

            // Act
            var result = service.CountUniqueWords(input);

            // Assert
            AssertHelpers.AssertDictionariesAreEqual(expected, result);
            Assert.True(AssertHelpers.IsDictionarySorted(result));
        }


    }
}