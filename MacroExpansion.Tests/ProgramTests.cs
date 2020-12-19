using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MacroExpansion.Tests
{
    [TestFixture]
    public class ProgramTests
    {

        [Test]
        public void MacroExpansion_SequenceIsNull()
        {
            Assert.That(() => ((IEnumerable<int>) null).MacroExpansion(2, new[] {1, 2, 3}), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void MacroExpansion_NewValuesIsNull()
        {
            Assert.That(() => (new[] {7, 8, 9}.MacroExpansion(2, null)), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void MacroExpansion_SequenceIsEmpty()
        {
            Assert.That(() => (new int[] { }.MacroExpansion(1, new[] {2, 3})), Is.EqualTo(new int[] { }));
        }

        [TestCase(7)]
        [TestCase(0)]
        [TestCase(38)]
        [TestCase(-28)]
        public void MacroExpansion_ValueIsNotPresent(int elem)
        {
            var source = new[] {elem+100, elem-4, elem+89};
            var newElem = new[] {8, 7};
            var result = source.MacroExpansion(elem, newElem);
            Assert.That(result, Is.EqualTo(source));
        }

        [Test]
        public void MacroExpansion_HeadReplacement()
        {
            var elem = "pippo";
            var source = new[] {elem, elem + elem + "sss", elem + "ksjdjdjk", "sjsjdj"+elem};
            var newValues = new[] {"1" + elem, "2" + elem};
            var expected = new[] { "1" + elem, "2" + elem, elem + elem + "sss", elem + "ksjdjdjk", "sjsjdj" + elem };
            var result = source.MacroExpansion(elem, newValues);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
