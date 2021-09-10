using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IPSDemo.IPSDemoModel;

namespace IPSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IPSDemoModel _context;

        public AccountsController(IPSDemoModel context)
        {
            _context = context;
        }

        [HttpGet("Personal")]
        public ActionResult<IEnumerable<PersonalAccount>> GetPersonal()
        {
            return Ok(_context.PersonalAccounts.Include(ac => ac.Personnel));
        }

        [HttpGet("Corporate")]
        public ActionResult<IEnumerable<CorporateAccount>> GetCorporate()
        {
            return Ok(_context.CorporateAccounts.Include(ac => ac.CompanyOfficers));
        }

        [HttpGet("Personal/{id}")]
        public ActionResult<PersonalAccount> GetPersonal(Guid id)
        {
            var account = _context.PersonalAccounts.Include(ac => ac.Personnel).FirstOrDefault(ac => ac.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpGet("Corporate/{id}")]
        public ActionResult<CorporateAccount> GetCorporate(Guid id)
        {
            var account = _context.CorporateAccounts.Include(ac => ac.CompanyOfficers).FirstOrDefault(ac => ac.Id == id);
            if(account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost("Personal")]
        public async Task<ActionResult> PostPersonal([FromBody] PersonalAccount value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            await _context.PersonalAccounts.AddAsync(value);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Corporate")]
        public async Task<ActionResult> PostCorporate([FromBody] CorporateAccount value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            await _context.CorporateAccounts.AddAsync(value);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("Personal/{id}")]
        public async Task<ActionResult> PutPersonal(Guid id, [FromBody] PersonalAccount value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var account = _context.PersonalAccounts.FirstOrDefault(ac => ac.Id == id);
            if(account != null)
            {
                account.AccountName = value.AccountName;
                account.BankAccountBSB = value.BankAccountBSB;
                account.BankAccountNo = value.BankAccountNo;
                account.NoOfPersonnel = value.NoOfPersonnel;
                account.Personnel = value.Personnel;
                account.TFN = value.TFN;

                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        [HttpPut("Corporate/{id}")]
        public async Task<ActionResult> PutCorporate(Guid id, [FromBody] CorporateAccount value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var account = _context.CorporateAccounts.FirstOrDefault(ac => ac.Id == id);
            if (account != null)
            {
                account.AccountName = value.AccountName;
                account.BankAccountBSB = value.BankAccountBSB;
                account.BankAccountNo = value.BankAccountNo;
                account.CompanyName = value.CompanyName;
                account.CompanyOfficers = value.CompanyOfficers;
                account.NoOfCompanyOfficers = value.NoOfCompanyOfficers;
                account.ABN = value.ABN;
                
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("Personal/{id}")]
        public async Task<ActionResult> DeletePersonal(Guid id)
        {
            var account = _context.PersonalAccounts.FirstOrDefault(ac => ac.Id == id);
            if(account != null)
            {
                _context.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("Corporate/{id}")]
        public async Task<ActionResult> DeleteCorporate(Guid id)
        {
            var account = _context.CorporateAccounts.FirstOrDefault(ac => ac.Id == id);
            if (account != null)
            {
                _context.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
