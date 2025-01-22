using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_accountService.GetAll());
        }

        [HttpPost("Add")]
        public IActionResult Add(Account account)
        {
            _accountService.Add(account);
            return Ok();
        }
    }
}
