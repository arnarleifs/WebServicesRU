#!/usr/bin/env ruby
require 'bunny'
require 'json'

exchange_name = 'math_exchange'
queue_name = 'multiply_queue'
input_routing_key = 'division_success'
output_routing_key = 'multiply_success'

connection = Bunny.new
connection.start

channel = connection.create_channel
exchange = channel.direct(exchange_name, durable: true)
queue = channel.queue(queue_name, durable: true)
queue.bind(exchange, routing_key: input_routing_key)

def multiply(a, b)
    return a * b
end

begin
    queue.subscribe(block: true) do |delivery_info, _properties, body|
        parsed_json = JSON.parse(body)
        multiply_result = multiply(parsed_json['a'], parsed_json['b']).to_i
        body = "{ \"a\": #{multiply_result}, \"b\": 2 }"
        exchange.publish(body, routing_key: output_routing_key)
        puts " [x] Sent: '#{body}'"
    end
end
