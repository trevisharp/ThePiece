namespace ThePiece
{
    public interface StateManager
    {
        void ComputeNext(int pl);
        double Avaliation(int pl);
        int ChildrenPoolLocation(int pl);
        int ChildrenCount(int pl);
        int Size(int pl);
        void DefaultInitialState();
    }
}