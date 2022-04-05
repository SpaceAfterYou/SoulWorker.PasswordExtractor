namespace SoulWorker.PasswordExtractor;

internal enum AssemblyOpcode : byte
{
    Push = 0x68,
    Nop = 0x90,
    Ret = 0xC3,
    Align = 0xCC,
}
