using StackExchange.Redis;

namespace Operation.Redis
{
    public class RedisService
    {
        private readonly string host;
        private readonly int port;
        private ConnectionMultiplexer connectionMultiplexer;

        public RedisService(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect($"{host}:{port}");

        public IDatabase GetDatabase(int db = 0) => connectionMultiplexer.GetDatabase(db);
    }
}