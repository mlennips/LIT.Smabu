﻿using LIT.Smabu.Infrastructure.CQRS;
using LIT.Smabu.Infrastructure.DDD;
using LIT.Smabu.Infrastructure.Exception;
using LIT.Smabu.Shared.Dtos;
using LIT.Smabu.Shared.Entities.Business.CustomerAggregate;

namespace LIT.Smabu.Service.ReadModels
{
    public class CustomerReadModel : EntityReadModel<Customer, CustomerId>
    {
        public CustomerReadModel(IAggregateStore aggregateStore) : base(aggregateStore)
        {

        }

        protected override IEnumerable<Customer> BuildQuery(IAggregateStore aggregateStore)
        {
            // Fake
            for (int i = 0; i < 50; i++)
            {
                yield return Customer.Create(new CustomerId(Guid.NewGuid()), new CustomerNumber(i), "Customer " + i, "Customer", "Branch A");
            }
            //
            //return aggregateStore.GetAll<Customer, CustomerId>();
        }

        public IEnumerable<CustomerOverviewDto> GetOverview() => GetAll().Select(x => CustomerOverviewDto.From(x));
        public CustomerDetailDto GetDetail(CustomerId id) => CustomerDetailDto.From(GetById(id) ?? throw new EntityNotFoundException(id));
    }
}
