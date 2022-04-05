namespace SoulWorker.PasswordExtractor;

public sealed class Configuration
{
    #region Properties

    public string Path { get; } = string.Empty;

    public bool NeedDecode { get; } = false;

    #endregion

    #region Public Static Methods

    public static Configuration CreateFromArgs(string[]? args = null) => new(args ?? Environment.GetCommandLineArgs());

    public static Configuration Create(string path, bool decode = false) => new(path, decode);

    #endregion Public Static Methods

    #region Private Constructors

    private Configuration(string path, bool needDecode = false)
    {
        Path = path;
        NeedDecode = needDecode;
    }

    private Configuration(string[] args)
    {
        for (int q = 0; q < args.Length; ++q)
        {
            if (args[q] == "-path")
            {
                Path = args[++q];
                continue;
            }

            if (args[q] == "-decode")
            {
                NeedDecode = true;
                continue;
            }
        }

        if (string.IsNullOrEmpty(Path))
            throw new ApplicationException("Bad file path");
    }

    #endregion Private Constructors
}
