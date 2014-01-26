using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberNameKata
{
    [TestClass]
    public class NumberNameTest
    {
        [TestMethod]
        public void Should_parse_units_digit_zero()
        {
            NumberName numberName = new NumberName(0);
            Assert.AreEqual("zero", numberName.Name);

            numberName = new NumberName(8);
            Assert.AreEqual("nine", numberName.Name);
        }

        [TestMethod]
        public void Should_parse_tens_digit_ten()
        {
            NumberName numberName = new NumberName(10);
            Assert.AreEqual("ten", numberName.Name);

            numberName = new NumberName(90);
            Assert.AreEqual("ninety", numberName.Name);
        }

        [TestMethod]
        public void Should_parse_tens_digit_less_than_twenteen()
        {
            NumberName numberName = new NumberName(11);
            Assert.AreEqual("eleven", numberName.Name);

            numberName = new NumberName(19);
            Assert.AreEqual("nineteen", numberName.Name);
        }

        [TestMethod]
        public void Should_parse_tens_digit_greater_than_twenteen()
        {
            NumberName numberName = new NumberName(21);
            Assert.AreEqual("twenty one", numberName.Name);

            numberName = new NumberName(93);
            Assert.AreEqual("ninety three", numberName.Name);
        }

        [TestMethod]
        public void Should_parse_hunderds_number()
        {
            NumberName numberName = new NumberName(100);
            Assert.AreEqual("one hundred", numberName.Name);

            numberName = new NumberName(101);
            Assert.AreEqual("one hundred and one", numberName.Name);

            numberName = new NumberName(123);
            Assert.AreEqual("one hundred and twenty three", numberName.Name);
        }

        [TestMethod]
        public void Should_parse_thousands_number()
        {
            NumberName numberName = new NumberName(1001);
            Assert.AreEqual("one thousand, one", numberName.Name);

            numberName = new NumberName(1023);
            Assert.AreEqual("one thousand, twenty three", numberName.Name);

            numberName = new NumberName(2314);
            Assert.AreEqual("two thousand, three hundred and fourteen", numberName.Name);

            numberName = new NumberName(32314);
            Assert.AreEqual("thirty two thousand, three hundred and fourteen", numberName.Name);

            numberName = new NumberName(632314);
            Assert.AreEqual("six hundred and thirty two thousand, three hundred and fourteen", numberName.Name);
        }

        [TestMethod]
        public void Should_parse_million_number()
        {
            NumberName numberName = new NumberName(1344534);
            Assert.AreEqual("one million, three hundred and fourty four thousand, five hundred and thirty four", numberName.Name);

            numberName = new NumberName(41344534);
            Assert.AreEqual("fourty one million, three hundred and fourty four thousand, five hundred and thirty four", numberName.Name);

            numberName = new NumberName(521344534);
            Assert.AreEqual("five hundred and twenty one million, three hundred and fourty four thousand, five hundred and thirty four", numberName.Name);
        }
    }
}
