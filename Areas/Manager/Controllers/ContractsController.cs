using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoContratos.Data;
using GestaoContratos.Models;
using Microsoft.AspNetCore.Http;

namespace GestaoContratos.Areas.Contracts.Controllers
{
    [Area("Manager")]
    public class ContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;
        public ContractsController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: Contracts/Contracts
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ContractViewModel>>(await _context.Contract.ToListAsync()));
        }

        // GET: Contracts/Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Contracts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contracts/Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContractViewModel contractViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Contract>(contractViewModel));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractViewModel);
        }

        // GET: Contracts/Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ContractViewModel>(contract));
        }


        [HttpGet]
        public async Task<IActionResult> DownloadContractFile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            var fileBytes = contract.File;

            return File(fileBytes, "application/force-download", contract.FileName);
        }


        // POST: Contracts/Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientName,Type,NegotiatedQuantity,NegotiatedValue,StartDate,Duration,File")] ContractViewModel contractViewModel)
        {
            if (id != contractViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    

                    

                    _context.Update(_mapper.Map<Contract>(contractViewModel));

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contractViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contractViewModel);
        }

        // GET: Contracts/Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ContractViewModel>(contract));
        }

        // POST: Contracts/Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.Id == id);
        }
    }
}
