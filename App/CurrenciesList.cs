using Domain.DbModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App
{
    public class CurrenciesList
    {
        public class Query : IRequest<List<Currency>> { }

        public class Handler : IRequestHandler<Query, List<Currency>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Currency>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Currencies.ToListAsync(cancellationToken);
            }
        }
    }
}
