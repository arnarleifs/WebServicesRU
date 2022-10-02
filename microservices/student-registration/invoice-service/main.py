import pika
from requests import post
import json
import os
from dotenv import load_dotenv

load_dotenv()

host = os.getenv('HOST')
exchange = os.getenv('EXCHANGE')
queue = os.getenv('QUEUE')
base_url = os.getenv('BASEURL')

connection = pika.BlockingConnection(pika.ConnectionParameters(host))
channel = connection.channel()

# Declare the exchange, if it doesn't exist
channel.exchange_declare(exchange=exchange, exchange_type='topic', durable=True)
# Declare the queue, if it doesn't exist
channel.queue_declare(queue=queue, durable=True)
# Bind the queue to a specific exchange with a routing key
channel.queue_bind(exchange=exchange, queue=queue, routing_key='student-registration')

def send_invoice(ch, method, properties, data):
    parsed_msg = json.loads(data)
    body = {
        'kennitala': parsed_msg['kennitala'],
        'price': parsed_msg['price']
    }
    response = post(f'{base_url}/200', body)
    print(response.status_code)
    print(response.content)
    print(body)

    ch.basic_ack(delivery_tag = method.delivery_tag)

channel.basic_consume(on_message_callback=send_invoice,
                      queue=queue,
                      auto_ack=False)

channel.start_consuming()
connection.close()