using LIT.Smabu.Service.Business;
using LIT.Smabu.Service.ReadModels;
using LIT.Smabu.Shared.Commands.Customer;
using LIT.Smabu.Shared.Dtos;
using LIT.Smabu.Shared.Entities.Business.CustomerAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace LIT.Smabu.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly CustomerService customerService;
        private readonly CustomerReadModel customerReadModel;

        public CustomersController(ILogger<CustomersController> logger, CustomerService customerService, CustomerReadModel customerReadModel)
        {
            _logger = logger;
            this.customerService = customerService;
            this.customerReadModel = customerReadModel;
        }

        [HttpGet("")]
        public IEnumerable<CustomerOverviewDto> Get()
        {
            return this.customerReadModel.GetOverview();
        }

        [HttpGet("{id}")]
        public CustomerDetailDto GetDetails(Guid id)
        {
            return this.customerReadModel.GetDetail(new CustomerId(id));
        }

        [HttpPost]
        public async Task<CustomerOverviewDto> Post([FromBody] CreateCustomer model)
        {
            var customer = await this.customerService.CreateAsync(model.Name1, model.Name2);
            return CustomerOverviewDto.From(customer);
        }

        [HttpPut]
        public async Task<CustomerOverviewDto> Put([FromBody] EditCustomer model)
        {
            var customer = await this.customerService.EditAsync(model.Id, model.Name1, model.Name2, model.IndustryBranch);
            return CustomerOverviewDto.From(customer);
        }
    }
}