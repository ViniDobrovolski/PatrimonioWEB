﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysAplicativo.Models;

namespace sysAplicativo.Controllers
{
    public class DbDepartamentoesController : Controller
    {
        private readonly Context _context;

        public DbDepartamentoesController(Context context)
        {
            _context = context;
        }

       

        // GET: DbDepartamentoes
        public async Task<IActionResult> Index()
        {
            List<DtoDepartamento> lista = (from d in _context.Departamentos
                                           join l in _context.Locais on d.idlocal equals l.id
                                           select new DtoDepartamento
                                           {
                                               id = d.id,
                                               nomedepartamento = d.nomedepartamento,
                                               descricaodepartamento = d.descricaodepartamento,
                                               nomelocal = l.nomelocal


                                           }).ToList();



              return View(lista);
        }

        // GET: DbDepartamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }

            return View(dbDepartamento);
        }

        // GET: DbDepartamentoes/Create
        public IActionResult Create()
        {
            
            ViewBag.Local2 = new SelectList(_context.Locais, "id", "nomelocal");



            
            return View();
        }

        // POST: DbDepartamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomedepartamento,descricaodepartamento,idlocal")] DbDepartamento dbDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbDepartamento);
        }

        // GET: DbDepartamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.Departamentos.FindAsync(id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }
            return View(dbDepartamento);
        }

        // POST: DbDepartamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomedepartamento,descricaodepartamento,idlocal")] DbDepartamento dbDepartamento)
        {
            if (id != dbDepartamento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbDepartamentoExists(dbDepartamento.id))
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
            return View(dbDepartamento);
        }

        // GET: DbDepartamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }

            return View(dbDepartamento);
        }

        // POST: DbDepartamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departamentos == null)
            {
                return Problem("Entity set 'Context.Departamentos'  is null.");
            }
            var dbDepartamento = await _context.Departamentos.FindAsync(id);
            if (dbDepartamento != null)
            {
                _context.Departamentos.Remove(dbDepartamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbDepartamentoExists(int id)
        {
          return (_context.Departamentos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
