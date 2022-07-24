import pika
import json

connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
channel = connection.channel()

exchange_name = 'math_exchange'
queue_name = 'divide_queue'
input_routing_key = 'solve_problem'
output_routing_key = 'division_success'

# Declare exchange
channel.exchange_declare(exchange=exchange_name, exchange_type='direct', durable=True)

# Declare queue
channel.queue_declare(queue=queue_name, durable=True)

# Bind queue to exchange with a routing key
channel.queue_bind(queue=queue_name, exchange=exchange_name, routing_key=input_routing_key)

def divide(a, b):
    return a / b

def divide_and_publish(ch, method, properties, data):
    parsed_data = json.loads(data)
    division_results = divide(int(parsed_data['a']), int(parsed_data['b']))
    body = '{ "a": %d, "b": %d }' % (division_results, 2)
    channel.publish(exchange=exchange_name, routing_key=output_routing_key, body=body)
    print('[x] Sent: %s' % body)

channel.basic_consume(consumer_callback=divide_and_publish,
                      queue=queue_name,
                      no_ack=True)

channel.start_consuming()
connection.close()
