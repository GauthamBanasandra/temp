using System;
using System.Threading.Tasks;
using Grpc.Core;
using MathClient;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);

            var operands = new Operands() { Operand1 = 1, Operand2 = 2 };
            var client = new Calculator.CalculatorClient(channel);

            var result = await client.AddAsync(operands);
            Console.WriteLine(result.Number_);
        }
    }
}
