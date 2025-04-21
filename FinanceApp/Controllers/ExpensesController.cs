using FinanceApp.Data;
using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.Add(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expensesService.GetAll();
            var expenseToDelete = expense.FirstOrDefault(e => e.Id == id);
            if (expenseToDelete == null)
            {
                return NotFound();
            }
            return View(expenseToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _expensesService.GetAll();
            var expenseToDelete = expense.FirstOrDefault(e => e.Id == id);
            if (expenseToDelete != null)
            {
                // Assuming a Delete method exists in IExpensesService
                await _expensesService.Delete(id);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var expense = await _expensesService.GetAll();
            var expenseToEdit = expense.FirstOrDefault(e => e.Id == id);
            if (expenseToEdit == null)
            {
                return NotFound();
            }
            return View(expenseToEdit); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                // Assuming an Update method exists in IExpensesService
                await _expensesService.Update(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult GetChart()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }
    }
}
