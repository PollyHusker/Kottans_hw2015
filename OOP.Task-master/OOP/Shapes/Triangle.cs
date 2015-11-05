using System;
using System.Collections;
using System.Collections.Generic;
using OOP;

namespace OOP.Shapes
{
     //TODO: use Heron's formula for area
    public class Triangle : ShapeBase
    {
        protected double _edge1;
        protected double _edge2;
        protected double _edge3;

        public Triangle(double edge1, double edge2, double edge3): this(new Dictionary<ParamKeys, object>
        {
            {ParamKeys.Edge1, edge1 },
            {ParamKeys.Edge2, edge2 },
            {ParamKeys.Edge3, edge3 },
            {ParamKeys.CoordX, 0},
            {ParamKeys.CoordY, 0}
        })
        {}

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = parameters.ContainsKey(ParamKeys.Edge2) ? (double)parameters[ParamKeys.Edge2] : (double)parameters[ParamKeys.Edge1];
            _edge3 = parameters.ContainsKey(ParamKeys.Edge3) ? (double)parameters[ParamKeys.Edge3] : (double)parameters[ParamKeys.Edge1];
        }

        public override double GetPerimeter()
        {
            return (_edge1 + _edge2 + _edge3)*Multiplier;
        }

        protected override double Area()
        {
            double p = GetPerimeter()/2;
            return Math.Sqrt(p*(p - _edge1)*(p - _edge2)*(p - _edge3));
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ShapeName
        {
            get { return "Triangle"; } 
        }
    }
}