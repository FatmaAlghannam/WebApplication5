using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApplication5.Models;
//this is the Contract btwn => server and client 
namespace WebApplication5.Controllers
{
    [Route("api/bank")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankContext _bankContext;
        // NEW code _bankContext is the injection :we place it all in >
        public BankController(BankContext Context)
        {
            _bankContext = Context;
        }

        [HttpGet]
        public PageListResult<BankBranchResponse> GetAll(int page = 1, string search = "")
        {
            if (search == "")
            {
                return _bankContext.BankBranches
                    //paging:
                    //envolpe data about data :

                    //.Skip((page-1)*3)
                    //.Take(3)
                    .Select(b => new BankBranchResponse
                    {
                        LocationName = b.LocationName,
                        LocationURL = b.LocationURL,


                    }).ToPageList(page, 1);
            }
            return _bankContext.BankBranches
                    .Where(r => r.LocationName.StartsWith(search))
                     .Select(b => new BankBranchResponse
                     {
                         LocationName = b.LocationName,
                         LocationURL = b.LocationURL,


                     }).ToPageList(page, 1);
        }
        [HttpGet("{id}")]
        public ActionResult<BankBranchResponse> DetailsBank(int id)
        {
            var bank = _bankContext.BankBranches.Find(id);
            if (bank == null)
            {
                return NotFound();
            }
            return new BankBranchResponse
            {
                LocationName = bank.LocationName,
                LocationURL = bank.LocationURL,



            };
        }

        [HttpPost]
        public IActionResult Add(AddBankRequest req)
        { var newBank = new BankBranches()
        // _bankContext.BankBranches.Add(new BankBranches()
        {
            LocationName = req.LocationName,
            LocationURL = req.LocationURL,
            Branchmanger = "",


        };
            _bankContext.BankBranches.Add(newBank);
            _bankContext.SaveChanges();

            return Created(nameof(DetailsBank), new { Id = newBank.Id });
        }

        [HttpPatch("{id}")]
        public IActionResult Edit(int id, AddBankRequest req)
        {

            var bank = _bankContext.BankBranches.Find(id);
            bank.LocationName = req.LocationName;
            bank.LocationURL = req.LocationURL;
            bank.Branchmanger = req.Branchmanger;
            _bankContext.SaveChanges();

            return Created(nameof(DetailsBank), new { Id = bank.Id });


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bank = _bankContext?.BankBranches.Find(id);
            if(bank == null)
            {
                return BadRequest();
            }
            _bankContext?.BankBranches.Remove(bank);
            _bankContext.SaveChanges();

            return Ok();
                
        }










        }
    }
