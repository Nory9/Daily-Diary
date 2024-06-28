using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Daily_Diary;

namespace DailyDiary.Tests
{
    public class DiaryTests
    {
        [Fact]
        public void ValidInput_pass()
        {
            // Arrange
            var diary = new Diary();
            // var diary = new DailyDiary();
            string validInput = "1";

            // Act
            bool result = diary.validInput(validInput);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidInput_failed()
        {
            // Arrange
            var diary = new Diary();
            string invalidInput = "5";

            // Act
            bool result = diary.validInput(invalidInput);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ReadPath_pass()
        {
            // Arrange
            var diary = new Diary();

            // Act
            string path = diary.Read_path();

            // Assert
            Assert.Equal("../../../mydiary.txt", path);
        }

        [Fact]
        public void ReadDiary_pass()
        {
            // Arrange
            var diary = new Diary();
            string expectedContent = "Test diary content";
            File.WriteAllText("../../../mydiary.txt", expectedContent);

            // Act
            string content = diary.Read_Diary();

            // Assert
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void DeleteEntry_failed()
        {
            // Arrange
            var diary = new Diary();
            List<string> entries = new List<string> { "01/01/2023", "Test entry" };
            string date = "02/02/2023";

            // Act
            bool result = diary.Delete_entry(entries, date);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteEntry_pass()
        {
            // Arrange
            var diary = new Diary();
            List<string> entries = new List<string> { "01/01/2023", "Test entry" };
            string date = "01/01/2023";

            // Act
            bool result = diary.Delete_entry(entries, date);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetCount_pass()
        {
            // Arrange
            var diary = new Diary();
            List<string> entries = new List<string> { "01/01/2023", "Test entry" };

            // Act
            int count = diary.Get_count(entries);

            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void SearchEntry_TrimEntries()
        {
            // Arrange
            var diary = new Diary();
            List<string> entries = new List<string> { " 01/01/2023 ", " Test entry " };
            List<string> expectedEntries = new List<string> { "01/01/2023", "Test entry" };

            // Act
            List<string> result = diary.Search_entry(entries);

            // Assert
            Assert.Equal(expectedEntries, result);
        }
    }
}
