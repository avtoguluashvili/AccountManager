using AccountManager.Domain.Entities;
using AccountManager.Dto;
using AccountManager.Interfaces.Repositories;
using AccountManager.Interfaces.Services;
using AutoMapper;

namespace AccountManager.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
        }

        public async Task<SubscriptionDto?> GetSubscriptionByIdAsync(int subscriptionId)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            return subscription is null ? null : _mapper.Map<SubscriptionDto>(subscription);
        }

        public async Task<bool> UpdateSubscriptionAsync(int subscriptionId, SubscriptionDto subscriptionDto)
        {
            var subscriptionEntity = _mapper.Map<Subscription>(subscriptionDto);
            subscriptionEntity.SubscriptionId = subscriptionId;
            return await _subscriptionRepository.UpdateAsync(subscriptionEntity);
        }
    }
}
