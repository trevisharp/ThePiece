using System;
using System.Buffers;
using System.Collections.Generic;

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
        private List<int> freelist;
        private StatePooling()
        {
            this.pool = ArrayPool<byte>.Create(128 * 1024 * 1024, 1024);
            this.arr = pool.Rent(32 * 1024 * 1024);
            this.freelist = new List<int>();
            freelist.Add(0);
            freelist.Add(32 * 1024 * 1024);
        }

        public byte[] Pool => arr;

        public int Rent(int size)
        {
            int index = -1;
            for (int j = 0; j < freelist.Count; j += 2)
            {
                if (freelist[j + 1] - freelist[j] < size)
                {
                    index = freelist[j];
                    freelist[j] += size;
                    break;
                }
            }
            return index;
        }

        public void Return(int index, int size)
        {
            if (size < 1)
                return;
            if (index >= freelist[freelist.Count - 1])
                return;
            int len = freelist.Count - 1;
            for (int j = 1; j < len; j += 2)
            {
                if (index > freelist[j] && index < freelist[j + 1])
                {
                    if (index + size < freelist[j + 1])
                    {
                        int leninzone = freelist[j + 1] - size;
                        Return(index, leninzone);
                        Return(freelist[j + 1], size - leninzone);
                        break;
                    }
                    else
                    {
                        if (freelist[j] == index)
                            freelist[j] += size;
                        else if (freelist[j + 1] == index + size)
                            freelist[j + 1] -= size;
                        else
                        {
                            freelist.Insert(j + 1, index);
                            freelist.Insert(j + 2, index + size);
                        }
                        break;
                    }
                }
                else if (index > freelist[j + 1] && index < freelist[j + 2])
                {
                    int leninfreezone = freelist[j + 2] - size;
                    Return(freelist[j + 2], size - leninfreezone);
                    break;
                }
            }
        }
    }
}