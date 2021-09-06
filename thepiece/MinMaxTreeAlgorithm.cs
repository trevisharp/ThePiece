using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ThePiece
{
    public class MinMaxTreeAlgorithm<T>
        where T : StateManager, new()
    {
        private T manager;
        private List<double> avaliationtree = new List<double>();
        public MinMaxTreeAlgorithm()
        {
            manager = new T();
            byte[] arr = StatePooling.Current.Pool;
            manager.DefaultInitialState(arr);
        }
        public MinMaxTreeAlgorithm(byte[] initialstate)
        {
            manager = new T();
            byte[] arr = StatePooling.Current.Pool;
            Buffer.BlockCopy(initialstate, 0, arr, 0, initialstate.Length);
        }

        public void Explore(int deth)
        {
            
        }
    }
}