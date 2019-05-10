using Windows.UI.Xaml.Controls;

namespace Canvas01.Drawers
{
    public interface IShapeDrawer<out TDrawableShape>
    {
        int AttachToCanvas(Canvas aCanvas);
        void DetachFromCanvas(Canvas theCanvas);
        void SetAttachedProperties();
        void MoveAndDraw();
    }
}