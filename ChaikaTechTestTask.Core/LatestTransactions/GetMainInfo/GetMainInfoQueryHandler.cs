using AutoMapper;
using ChaikaTechTestTask.Core.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.LatestTransactions.GetMainInfo;

public class GetMainInfoQueryHandler : IRequestHandler<GetMainInfoQuery, GetMainInfo>
{
    private readonly ChaikaTechDbContext _context;
    private readonly IMapper _mapper;

    public GetMainInfoQueryHandler(ChaikaTechDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetMainInfo> Handle(GetMainInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);

        if (user == null)
        {
            throw new ArgumentException("User not found!");
        }


    }
}
