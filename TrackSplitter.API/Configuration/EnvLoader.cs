namespace TrackSplitter.API.Configuration;

public static class EnvLoader
{
    public static void Load()
    {
        // Search up the directory tree so the .env at the solution root is found
        // regardless of the app's working directory.
        DotNetEnv.Env.TraversePath().Load();
    }
}
