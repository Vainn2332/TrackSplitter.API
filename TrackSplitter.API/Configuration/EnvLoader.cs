namespace TrackSplitter.API.Configuration;

public static class EnvLoader
{
    public static void Load()
    {
        DotNetEnv.Env.Load();
    }
}
