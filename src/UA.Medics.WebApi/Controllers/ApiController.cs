using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace UA.Medics.WebApi.Controllers
{
	public abstract class ApiController : ControllerBase
	{
		protected ISender Mediator =>  this.HttpContext.RequestServices.GetService<ISender>();
	}
}
