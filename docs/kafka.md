cd C:\kafka_2.13-3.5.0\bin\windows

## Topics

### create topic
> .\kafka-topics.bat --bootstrap-server 127.0.0.1:9092 --create --replication-factor 1 --partitions 3 --topic myorders
### describe topic
> kafka-topics.bat --bootstrap-server localhost:9092 --describe --topic mytopic
### list topics
> .\kafka-topics.bat --bootstrap-server 127.0.0.1:9092 --list
### reassign partitions
> .\kafka-reassign-partitions.bat --bootstrap-server 127.0.0.1:9092 --reassignment-json-file  C:\Code\samples\getting-started-kafka\module3\demo3\increase_replication.json --execute

## Producers
### produce
> .\kafka-console-producer.bat --bootstrap-server 127.0.01:9092 --topic first_topic
### produce with key seperator
> .\kafka-console-producer.bat --bootstrap-server 127.0.01:9092 --topic myorders --property "parse.key=true" --property "key.separator=:"

## Consumers

### consume
> .\kafka-console-consumer.bat --bootstrap-server 127.0.0.1:9092 --topic first_topic --from-beginning
### consume with group
> .\kafka-console-consumer.bat --bootstrap-server 127.0.0.1:9092 --topic myorders --group 1
### consume with des/ser
```
.\kafka-console-consumer.bat ^
--bootstrap-server localhost:9092 ^
--topic myorders --from-beginning ^
--key-deserializer org.apache.kafka.common.serialization.StringDeserializer ^
--value-deserializer org.apache.kafka.common.serialization.DoubleDeserializer ^
--property print.key=true ^
--property key.separator=, ^
--group 1
```

## Consumer groups
### consumers describe
> .\kafka-consumer-groups.bat --all-groups --all-topics --bootstrap-server 127.0.0.1:9092 --describe
### reset offset for a group
> .\kafka-consumer-groups.bat --bootstrap-server 127.0.0.1:9092 --group 1 --topic mytopic --reset-offsets --to-earliest --execute



http://localhost:8082/brokers
http://localhost:8082/topics
