using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace Canvas01.Drawers
{
    public abstract class ShapeDrawer<TShape, TDrawableShape> : IShapeDrawer<TDrawableShape>
        where TDrawableShape : UIElement, new()
    {
        protected TShape _shape;
        protected TDrawableShape _uiElement;
        protected Shape _prototype;
        protected double _canvasTop;
        protected double _canvasLeft;
        protected int _zIndex;

        protected ShapeDrawer(
            TShape shape,
            Shape prototype,
            double canvasTop = 0,
            double canvasLeft = 0,
            int zIndex = 1)
        {
            _shape = shape;
            _uiElement = null;
            _prototype = prototype;
            _canvasTop = canvasTop;
            _canvasLeft = canvasLeft;
            _zIndex = zIndex;

            CreateUIElement();
        }

        public void CreateUIElement()
        {
            _uiElement = new TDrawableShape();

            SetShapeGeometricProperties();
            SetShapePropertiesFromPrototype();
            SetAttachedProperties();
        }

        public int AttachToCanvas(Canvas aCanvas)
        {
            SetShapeGeometricProperties();
            SetShapePropertiesFromPrototype();
            SetAttachedProperties();
            aCanvas.Children.Add(_uiElement);
            return aCanvas.Children.Count - 1;
        }

        public void DetachFromCanvas(Canvas theCanvas)
        {
            if (theCanvas.Children.Contains(_uiElement))
            {
                theCanvas.Children.Remove(_uiElement);
            }
        }

        protected abstract void SetShapeGeometricProperties();
        protected abstract void SetShapePropertiesFromPrototype();

        public virtual void SetAttachedProperties()
        {
            Canvas.SetTop(_uiElement, _canvasTop);
            Canvas.SetLeft(_uiElement, _canvasLeft);
            Canvas.SetZIndex(_uiElement, _zIndex);
        }

        public virtual void MoveAndDraw()
        {
            throw new MethodAccessException("MoveAndDraw");
        }
    }
}