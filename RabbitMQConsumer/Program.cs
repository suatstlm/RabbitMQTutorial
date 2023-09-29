using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Thread.Sleep(10000);

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://vvjjdmze:D-T54SjsLmo6O0DG0XO1XoU32-N_o90E@puffin.rmq2.cloudamqp.com/vvjjdmze");

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("FristTutorialRabbitmq", false, false, true);
    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("FristTutorialRabbitmq", false, consumer);
    consumer.Received += (sender, e) =>
    {
        //e.Body : Kuyruktaki mesajı verir.
        Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
    };
}
Console.Read();