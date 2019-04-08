using System;
using ReFac.TowardsAdapter.Shared;
using ReFac.TowardsAdapter.Shared.Figures;
using ReFac.TowardsAdapter.Shared.Interfaces;

namespace ReFac.TowardsAdapter.After
{
    public class DrawTool : IDrawTool
    {
        private IShapeDraw _drawLib;

        public DrawTool(bool useLibX = true)
        {
            _drawLib = useLibX ? (IShapeDraw) new DrawLibXAdapter() : new DrawLibYAdapter();
        }

        public DrawTool(IShapeDraw shapeDrawLib)
        {
            _drawLib = shapeDrawLib ?? throw new ArgumentException("Null not allowed...");
        }

        public void DrawHouse(House obj)
        {
            _drawLib.DrawTriangle(obj.Roof);
            _drawLib.DrawRectangle(obj.Body);
        }

        public void DrawCar(Car obj)
        {
            _drawLib.DrawCircle(obj.WheelA);
            _drawLib.DrawCircle(obj.WheelB);
            _drawLib.DrawRectangle(obj.Body);
        }

        public void DrawTrain(Train obj)
        {
            _drawLib.DrawCircle(obj.WheelA);
            _drawLib.DrawCircle(obj.WheelB);
            _drawLib.DrawCircle(obj.WheelC);
            _drawLib.DrawRectangle(obj.BodyA);
        }
    }
}