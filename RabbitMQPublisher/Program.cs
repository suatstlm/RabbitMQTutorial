using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://vvjjdmze:D-T54SjsLmo6O0DG0XO1XoU32-N_o90E@puffin.rmq2.cloudamqp.com/vvjjdmze");

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("FristTutorialRabbitmq", false, false, true);
    byte[] bytemessage = Encoding.UTF8.GetBytes("Frist Tutorial On Rabbitmq test");
    channel.BasicPublish(exchange: "", routingKey: "FristTutorialRabbitmq", body: bytemessage);
}