using LIT.Smabu.Shared.Domain.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace LIT.Smabu.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class InvoicesController : ControllerBase
    {
        private readonly ILogger<InvoicesController> _logger;
        private readonly ISender sender;

        public InvoicesController(ILogger<InvoicesController> logger, ISender sender)
        {
            _logger = logger;
            this.sender = sender;
        }

        [HttpGet("")]
        public async Task<GetAllInvoicesResponse[]> Get()
        {
            var result = await this.sender.Send(new GetAllInvoicesQuery());
            return result;
        }

        //[HttpGet("{id}")]
        //public CustomerDetailDto GetDetails(Guid id)
        //{
        //    return this.customerReadModel.GetDetail(new CustomerId(id));
        //}

        //[HttpPost]
        //public async Task<CustomerOverviewDto> Post([FromBody] CreateCustomer model)
        //{
        //    var customer = await this.customerService.CreateAsync(model.Name);
        //    return CustomerOverviewDto.From(customer);
        //}

        //[HttpPut]
        //public async Task<CustomerOverviewDto> Put([FromBody] EditCustomer model)
        //{
        //    var customer = await this.customerService.EditAsync(model.Id, model.Name, model.IndustryBranch);
        //    return CustomerOverviewDto.From(customer);
        //}
    }
}