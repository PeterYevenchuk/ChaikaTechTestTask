using AutoMapper;
using ChaikaTechTestTask.Core.LatestTransactions;

namespace ChaikaTechTestTask.Core;

public class CoreMappingsProfile : Profile
{
    public CoreMappingsProfile()
    {
        CreateMap<LatestTransaction, LatestTransactionViewModel>();
    }
}
