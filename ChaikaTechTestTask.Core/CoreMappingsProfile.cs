using AutoMapper;
using ChaikaTechTestTask.Core.LatestTransactions;
using ChaikaTechTestTask.Core.LatestTransactions.GetDescriptionInfo;

namespace ChaikaTechTestTask.Core;

public class CoreMappingsProfile : Profile
{
    public CoreMappingsProfile()
    {
        CreateMap<LatestTransaction, LatestTransactionViewModel>()
            .ForMember(dest => dest.TransactionDate, opt => opt.Ignore())
            .ForMember(dest => dest.Amount, opt => opt.Ignore());

        CreateMap<LatestTransaction, GetDescriptionInfo>()
            .ForMember(dest => dest.Amount, opt => opt.Ignore());
    }
}
