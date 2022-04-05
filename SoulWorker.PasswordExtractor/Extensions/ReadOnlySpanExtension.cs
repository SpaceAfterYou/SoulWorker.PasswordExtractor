using System.Diagnostics;

namespace SoulWorker.PasswordExtractor.Extensions;

internal static class ReadOnlySpanExtension
{
    internal static int DistanceTo(this ReadOnlySpan<byte> buffer, byte what)
    {
        int index = 0;

        foreach (var value in buffer)
        {
            if (value != what)
            {
                Debug.Assert(index < 24);

                ++index; 
                continue;
            }
             
            Debug.Assert(index != 0);
            return index;
        }

        throw new ApplicationException();
    }
}
