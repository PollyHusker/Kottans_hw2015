using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Rectangle : ShapeBase
    {
        private double _edge1;
        private double _edge2;

        public Rectangle(double a, double b) : this(new Dictionary<ParamKeys, object>
        {
            {ParamKeys.Edge1, a},
            {ParamKeys.Edge2, b},
            {ParamKeys.CoordX, 0},
            {ParamKeys.CoordY, 0}
        })
        {
        }

        public Rectangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double) parameters[ParamKeys.Edge2];
            Multiplier = 1;
        }

        public override double GetPerimeter()
        {
            return 2*(_edge1 + _edge2)*Multiplier;
        }

        protected override double Area()
        {
            return (_edge1*_edge2)* Math.Pow(Multiplier, 2);
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ShapeName
        {
            get { return "Rectangle"; }
        }
    }
}