using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Queries
{
    public class GetActivityDetails
    {
        public class Query : IRequest<Activity>
        {
            public required string Id { get; set; }
        };

        public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
        {
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync([request.Id], cancellationToken);
                if (activity == null) throw new Exception("Activity not found");
                return activity;
            }

            
        }
    }
}