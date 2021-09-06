namespace ThePiece
{
    public interface StateManager
    {
        void ComputeNext(int pl, byte[] pool);
        double Avaliation(int pl, byte[] pool);
        int ChildrenPoolLocation(int pl, byte[] pool);
        int ChildrenCount(int pl, byte[] pool);
        int Size(int pl, byte[] pool);
        void DefaultInitialState(byte[] pool);
    }
}