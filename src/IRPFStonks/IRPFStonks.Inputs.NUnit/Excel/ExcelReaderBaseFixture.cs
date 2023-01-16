using NUnit.Framework;
using System.Text;

namespace IRPFStonks.Inputs.NUnit.Excel
{
    [TestFixture]
    internal class ExcelReaderBaseFixture
    {
        [SetUp]
        public void SetUp()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
