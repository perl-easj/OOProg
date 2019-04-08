using ReFac.TowardsAdapter.Shared.Figures;

namespace ReFac.TowardsAdapter.Shared.Interfaces
{
    public interface IDrawTool
    {
        void DrawHouse(House obj);
        void DrawCar(Car obj);
        void DrawTrain(Train obj);
    }
}