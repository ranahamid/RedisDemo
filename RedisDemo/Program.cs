using RedisDemo;

Console.WriteLine("Saving random data in cache");
SaveBigData();

Console.WriteLine("Reading data from cache");
ReadData();

Console.ReadLine();

 void ReadData()
{
    var cache = RedisConnectorHelper.Connection.GetDatabase();
    var devicesCount = 10000;
    for (int i = 0; i < devicesCount; i++)
    {
        var value = cache.StringGet($"Device_Status:{i}");
        Console.WriteLine($"Valor={value}");
    }
}

 void SaveBigData()
{
    var devicesCount = 10000;
    var rnd = new Random();
    var cache = RedisConnectorHelper.Connection.GetDatabase();

    for (int i = 1; i < devicesCount; i++)
    {
        var value = rnd.Next(0, 10000);
        cache.StringSet($"Device_Status:{i}", value);
    }
}