
using Confluent.Kafka;

const string TOPIC = "myorders";

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092",
    ClientId = "dotnet.producer",
    Acks = Acks.All,
    //MessageTimeoutMs = 300000,
    //BatchNumMessages = 10,
    //LingerMs = 10,
    //CompressionType = CompressionType.Gzip,
};

var producer = new ProducerBuilder<string, double>(config)
    .SetValueSerializer(Serializers.Double)
    .SetKeySerializer(Serializers.Utf8)
    .Build();

for (var i = 0; i < 20; i++)
{
    Random autoRand = new Random();
    var message = new Message<string, double>()
    {
        Key = $"key-{i}",
        Value = autoRand.NextDouble(),
    };

    var result = await producer.ProduceAsync(TOPIC, message);
}

Console.ReadKey();