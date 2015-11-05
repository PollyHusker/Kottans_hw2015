using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using OOP.Shapes.Triangles;

namespace OOP.Tests
{
    class EquilateralTriangleTest
    {
        [Test]
        public void EqTrianleShouldConvertToString()
        {
            const double edge = 3d;
            var eqTriangle = new EquilateralTriangle(edge);
            var info = eqTriangle.ToString();
            info.Should().Be(
    $"Shape information: Name : {"EquilateralTriangle"}, X : {0}, Y : {0}, Perimeter : {3 * edge }, Square : { Math.Sqrt(3)*edge*edge/4}");

        }
    }
}
