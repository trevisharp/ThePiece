using System.Buffers;

namespace ThePiece
{
    public class StatePooling
    {
        private static StatePooling current = null;
        public static StatePooling Current
        {
            get
            {
                if (current == null)
                    current = new StatePooling();
                return current;
            }
        }

        private ArrayPool<byte> pool;
        private byte[] arr;
        private StatePooling()
        {
            this.pool = ArrayPool<byte>.Create(128 * 1024 * 1024, 1024);
            this.arr = pool.Rent(32 * 1024 * 1024);
        }
    }
}