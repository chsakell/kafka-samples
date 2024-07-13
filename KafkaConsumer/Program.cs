using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;

const string TOPIC = "myorders";

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    ClientId = "dotnet.producer",
    Acks = Acks.All,
    GroupId = "1",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    EnableAutoCommit = true,
    //MessageTimeoutMs = 300000,
    //BatchNumMessages = 10,
    //LingerMs = 10,
    //CompressionType = CompressionType.Gzip,
};

var consumer = new ConsumerBuilder<string, double>(config)
    .SetValueDeserializer(Deserializers.Double)
.Build();

consumer.Subscribe(TOPIC);

while(true)
{
    var result = consumer.Consume();

    Console.WriteLine($"{result.Message.Key}-{result.Message.Value}");
}

consumer.Close();

Console.ReadKey();