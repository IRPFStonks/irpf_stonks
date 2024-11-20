using NUnit.Framework;

namespace IRPFStonks.View.NUnit
{
    [TestFixture]
    public class MainPageHeaderViewModelFixture
    {
        private MainPageHeaderViewModelFixture viewModel;

        [SetUp]
        public void Setup()
        {
            viewModel = new MainPageHeaderViewModelFixture();
        }

        [Test]
        public void WhenFileImported_LoadStockMovementsCollection()
        {
            Assert.Pass();
        }
    }
}