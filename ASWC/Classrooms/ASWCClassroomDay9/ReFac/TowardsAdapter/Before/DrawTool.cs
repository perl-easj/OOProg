using ReFac.TowardsAdapter.Shared;
using ReFac.TowardsAdapter.Shared.Drawing;
using ReFac.TowardsAdapter.Shared.Figures;
using ReFac.TowardsAdapter.Shared.Interfaces;

namespace ReFac.TowardsAdapter.Before
{
    public class DrawTool : IDrawTool
    {
        private DrawLibX _drawLibX;
        private DrawLibY _drawLibY;

        public DrawTool(bool useLibX = true)
        {
            _drawLibX = useLibX ? new DrawLibX() : null;
            _drawLibY = useLibX ? null : new DrawLibY();
        }

        public void DrawHouse(House obj)
        {
            if (_drawLibX != null)
            {
                _drawLibX.DrawTriangle(obj.Roof);
                _drawLibX.DrawRectangle(obj.Body);
                return;
            }

            if (_drawLibY != null)
            {
                // All this for drawing a rectangle...
                double brX = obj.Body.BotRight.X;
                double brY = obj.Body.BotRight.Y;
                double tlX = obj.Body.TopLeft.X;
                double tlY = obj.Body.TopLeft.Y;
                _drawLibY.DrawLine(tlX, tlY, brX, tlY);
                _drawLibY.DrawLine(brX, tlY, brX, brY);
                _drawLibY.DrawLine(brX, brY, tlX, brY);
                _drawLibY.DrawLine(tlX, brY, tlX, tlY);

                // All this for drawing a triangle...
                double aX = obj.Roof.A.X;
                double aY = obj.Roof.A.Y;
                double bX = obj.Roof.B.X;
                double bY = obj.Roof.B.Y;
                double cX = obj.Roof.C.X;
                double cY = obj.Roof.C.Y;
                _drawLibY.DrawLine(aX, aY, bX, bY);
                _drawLibY.DrawLine(bX, bY, cX, cY);
                _drawLibY.DrawLine(cX, cY, aX, aY);

                return;
            }
        }

        public void DrawCar(Car obj)
        {
            if (_drawLibX != null)
            {
                _drawLibX.DrawCircle(obj.WheelA);
                _drawLibX.DrawCircle(obj.WheelB);
                _drawLibX.DrawRectangle(obj.Body);

                return;
            }

            if (_drawLibY != null)
            {
                _drawLibY.DrawCircle(obj.WheelA.Center.X, obj.WheelA.Center.Y, obj.WheelA.Radius);
                _drawLibY.DrawCircle(obj.WheelB.Center.X, obj.WheelB.Center.Y, obj.WheelB.Radius);

                // All this for drawing a rectangle...
                double brX = obj.Body.BotRight.X;
                double brY = obj.Body.BotRight.Y;
                double tlX = obj.Body.TopLeft.X;
                double tlY = obj.Body.TopLeft.Y;
                _drawLibY.DrawLine(tlX, tlY, brX, tlY);
                _drawLibY.DrawLine(brX, tlY, brX, brY);
                _drawLibY.DrawLine(brX, brY, tlX, brY);
                _drawLibY.DrawLine(tlX, brY, tlX, tlY);

                return;
            }
        }

        public void DrawTrain(Train obj)
        {
            if (_drawLibX != null)
            {
                _drawLibX.DrawCircle(obj.WheelA);
                _drawLibX.DrawCircle(obj.WheelB);
                _drawLibX.DrawCircle(obj.WheelC);
                _drawLibX.DrawRectangle(obj.BodyA);
                _drawLibX.DrawRectangle(obj.BodyB);
            }

            if (_drawLibY != null)
            {
                _drawLibY.DrawCircle(obj.WheelA.Center.X, obj.WheelA.Center.Y, obj.WheelA.Radius);
                _drawLibY.DrawCircle(obj.WheelB.Center.X, obj.WheelB.Center.Y, obj.WheelB.Radius);
                _drawLibY.DrawCircle(obj.WheelC.Center.X, obj.WheelC.Center.Y, obj.WheelC.Radius);

                // All this for drawing a rectangle...
                double abrX = obj.BodyA.BotRight.X;
                double abrY = obj.BodyA.BotRight.Y;
                double atlX = obj.BodyA.TopLeft.X;
                double atlY = obj.BodyA.TopLeft.Y;
                _drawLibY.DrawLine(atlX, atlY, abrX, atlY);
                _drawLibY.DrawLine(abrX, atlY, abrX, abrY);
                _drawLibY.DrawLine(abrX, abrY, atlX, abrY);
                _drawLibY.DrawLine(atlX, abrY, atlX, atlY);

                // All this for drawing a rectangle...
                double bbrX = obj.BodyB.BotRight.X;
                double bbrY = obj.BodyB.BotRight.Y;
                double btlX = obj.BodyB.TopLeft.X;
                double btlY = obj.BodyB.TopLeft.Y;
                _drawLibY.DrawLine(btlX, btlY, bbrX, btlY);
                _drawLibY.DrawLine(bbrX, btlY, bbrX, bbrY);
                _drawLibY.DrawLine(bbrX, bbrY, btlX, bbrY);
                _drawLibY.DrawLine(btlX, bbrY, btlX, btlY);

                return;
            }
        }
    }
}