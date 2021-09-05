using System;
using System.Runtime.InteropServices;

namespace ThePiece
{
    public class MinMaxAlgorithm<T>
        where T : StateManager, new()
    {
        private T manager;
        public MinMaxAlgorithm(byte[] initialstate)
        {
            manager = new T();
        }

        public void Test()
        {
            var array = new byte[1000];
            Span<byte> state = stackalloc byte[100];
            unsafe
            {
                
            }
        }
    }
}