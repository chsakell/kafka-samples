using Confluent.Kafka;
using System;
using Newtonsoft.Json;

const string TOPIC = "mytopic";

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    ClientId = "dotnet.producer",
    Acks = Acks.All,
    GroupId = "custom-group-1",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    EnableAutoCommit = false,
    //MessageTimeoutMs = 300000,
    //BatchNumMessages = 10,
    //LingerMs = 10,
    //CompressionType = CompressionType.Gzip,
};

var consumer = new ConsumerBuilder<string, string>(config)
    .SetKeyDeserializer(Deserializers.Utf8)
    .SetValueDeserializer(Deserializers.Utf8)
.Build();

consumer.Subscribe(TOPIC);

while(true)
{
    var result = consumer.Consume();

    Console.WriteLine($"{result.Message.Key}-{result.Message.Value}");
    break;
}

consumer.Close();

Console.ReadKey();