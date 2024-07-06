using Anv;

namespace TodoList.Src.Features.Commum.Adapters.Configs;

public static class AppEnv
{
    public static class Postgres
    {
        public static readonly AnvEnv CONNECTION_STRING = new("POSTGRES_CONNECTION_STRING");
    }
}