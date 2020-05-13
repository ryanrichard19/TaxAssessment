using System.Threading.Tasks;
using NUnit.Framework;

namespace BLL.Test
{
    [TestFixture]
    public class TaxCalculatorTest
    {
        private ProgressiveTaxCalculatorStrategry _progresssiveTaxCalculator;
        private FlatRateTaxCalculatorStrategry _flatRateTaxCalculator;
        private FlatValueTaxCalculatorStrategry _flatValueTaxCalculator;
        [SetUp]
        public void Setup()
        {
            _progresssiveTaxCalculator = new ProgressiveTaxCalculatorStrategry();
            _flatRateTaxCalculator = new FlatRateTaxCalculatorStrategry();
            _flatValueTaxCalculator = new FlatValueTaxCalculatorStrategry();
        }

        [TestCase(33400, 4592.35)]
        [TestCase(100000, 21719.32)]
        [TestCase(8000, 800)]
        public async Task CalculateTaxProgressiveTest(decimal amount, decimal outcome)
        {
            var result = await _progresssiveTaxCalculator.CalculateTaxAsync(amount);
            Assert.AreEqual(outcome, result);
        }

        [TestCase(1000, 175)]
        [TestCase(5500, 962.5)]
        [TestCase(89760, 15708)]
        public async Task CalculateTaxFlatRateTest(decimal amount, decimal outcome)
        {
            var result = await _flatRateTaxCalculator.CalculateTaxAsync(amount);
            Assert.AreEqual(outcome, result);
        }

        [TestCase(33400, 1670)]
        [TestCase(9000, 450)]
        [TestCase(3450087, 10000)]
        public async Task CalculateTaxFlatValueTest(decimal amount, decimal outcome)
        {
            var result = await _flatValueTaxCalculator.CalculateTaxAsync(amount);
            Assert.AreEqual(outcome, result);
        }
    }
}