using Microsoft.VisualStudio.TestTools.UnitTesting;
using Godreault.MartinDown;

namespace Godreault.MartinDownTest
{
    [TestClass]
    public class MartinDownTest
    {
        [TestMethod]
        public void WhenInputHasNoMarkDown_ExpectSameOutput()
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform("Hello World!");

            //assert
            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void WhenInputIsEmpty_ExpectEmptyOutput() 
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform(string.Empty);

            //assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void WhenSingleWordHasItalic_ExpectCorrectHtmlTagOutput() 
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform("*Hello*");

            //assert
            Assert.AreEqual("<em>Hello</em>", result);
        }

        [TestMethod]
        public void WhenSingleWordHasBold_ExpectCorrectHtmlTagOutput() 
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform("**Hello**");

            //assert
            Assert.AreEqual("<strong>Hello</strong>", result);
        }

        [TestMethod]
        public void WhenSingleWordHasBoldAndItalics_ExpectCorrectHtmlTagOutput() 
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform("***Hello***");

            //assert
            Assert.AreEqual("<strong><em>Hello</em></strong>", result);
        }

        [TestMethod]
        public void WhenSentenceHasExtraWhiteSpaceBetweenWords_ExpectExtraWhiteSpace()
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform("Hello  World   !");

            //assert
            Assert.AreEqual("Hello  World   !", result);
        }

        [TestMethod]
        public void When1LineSentenceContainsMultipleMarkup_ExpectEachWordWithRightTags()
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform("The *quick* **brown** fox ***jumps*** over the lazy dog.");

            //assert
            Assert.AreEqual("The <em>quick</em> <strong>brown</strong> fox <strong><em>jumps</em></strong> over the lazy dog.", result);
        }

        [TestMethod]
        public void When1LineSentenceContainsMultipleSpacesBetweenWord_ExpectSameOutput() 
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform("The  quick    brown   fox    jumps    over the lazy dog.");

            //assert
            Assert.AreEqual("The  quick    brown   fox    jumps    over the lazy dog.", result);
        }

        [TestMethod]
        public void When1LineSentenceContainsTrailingSpaces_ExpectSpacePreserved() 
        {
            //arrange
            MarkDown markdown = new MarkDown();
            
            //act
            var result = markdown.Transform("The quick brown fox jumps over the lazy dog.      ");

            //assert
            Assert.AreEqual("The quick brown fox jumps over the lazy dog.      ", result);
        }
    }
}
