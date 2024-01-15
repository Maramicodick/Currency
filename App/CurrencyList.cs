using Domain.DbModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class CurrencyList
    {
        public class Query : IRequest<List<GraphCurrency>> { }

        public class Handler : IRequestHandler<Query, List<GraphCurrency>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<GraphCurrency>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.GraphCurrencies.ToListAsync(cancellationToken);
            }
        }
    }
}
