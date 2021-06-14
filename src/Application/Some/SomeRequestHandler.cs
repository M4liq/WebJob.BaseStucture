using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Some
{
    public class SomeRequestHandler : IRequestHandler<SomeRequest>
    {
        public async Task<Unit> Handle(SomeRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello world");
            return Unit.Value;
        }
    }
}
