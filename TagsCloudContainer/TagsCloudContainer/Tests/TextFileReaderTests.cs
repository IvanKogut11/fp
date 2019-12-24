﻿using System.IO;
using NUnit.Framework;
using FluentAssertions;
using System;

namespace TagsCloudContainer
{
    [TestFixture]
    public class TextFileReaderTests
    {
        private string fileName = Path.Combine(new string[] { AppDomain.CurrentDomain.BaseDirectory,
            "Test.txt"});

        [TearDown]
        public void DeleteFile()
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        [Test]
        public void TextFileReader_ReadsAllTheLines()
        {
            var text = "123\nHi\nHello";
            File.WriteAllText(fileName, text);
            var textFileReader = new TextFileReader(fileName);
            var str = "";

            foreach (var line in textFileReader.GetLines().Value)
            {
                if (str.Length != 0)
                    str += "\n";
                str += line;
            }

            str.Should().BeEquivalentTo(text);
        }

        [Test]
        public void TextFileReader_ThrowsAllFileNotFoundException_IfNotFile()
        {
            var textFileReader = new TextFileReader(fileName);

            var linesResult = textFileReader.GetLines();

            linesResult.IsSuccess.Should().BeFalse();
            linesResult.Error.Should().BeEquivalentTo(string.Format("Text file {0} is not found.\n" +
                                                                    "Check if file path is correct.", fileName));
        }
    }
}