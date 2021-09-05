using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

int N = 10000;
int CopySize = 1000;

Stopwatch watch = new Stopwatch();

var array = new byte[40 * 1024 * 1024];
for (int i = CopySize; i < 2 * CopySize; i++)
    array[i] = (byte)(i % 256);

watch.Start();
for (int j = 0; j < N; j++)
    copy();
watch.Stop();
Console.WriteLine(1000 * 1000 * watch.ElapsedMilliseconds / ((double)N));

void copy()
{
    Span<byte> state = stackalloc byte[CopySize];
    unsafe
    {
        fixed (byte* _p = state, _q = &array[CopySize], _end = &array[2 * CopySize])
        {
            byte* p =_p, q = _q, end = _end;
            while (q != end)
            {
                *p = *q;
                p++;
                q++;
            }
        }
    }
}