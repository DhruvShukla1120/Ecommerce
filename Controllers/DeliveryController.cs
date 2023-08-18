using E_commerce_websites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace E_commerce_websites.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly ApplicationDbContext _context;



        public DeliveryController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: Delivery
        public IActionResult Index()
        {
            var deliveries = _context.Deliveries.Include(d => d.DeliveryAgent).ToList();
            return View(deliveries);
        }



        // GET: Delivery/Create
        public IActionResult Create()
        {
            PopulateDeliveryAgentsDropdown();
            return View();
        }



        // POST: Delivery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                _context.Deliveries.Add(delivery);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PopulateDeliveryAgentsDropdown(delivery.DeliveryAgentId);
            return View(delivery);
        }



        // GET: Delivery/Edit/5
        public IActionResult Edit(int id)
        {
            var delivery = _context.Deliveries.Include(d => d.DeliveryAgent).FirstOrDefault(d => d.Id == id);
            if (delivery == null)
            {
                return NotFound();
            }
            PopulateDeliveryAgentsDropdown(delivery.DeliveryAgentId);
            return View(delivery);
        }



        // POST: Delivery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                _context.Update(delivery);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PopulateDeliveryAgentsDropdown(delivery.DeliveryAgentId);
            return View(delivery);
        }



        // GET: Delivery/Delete/5
        public IActionResult Delete(int id)
        {
            var delivery = _context.Deliveries.Find(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return View(delivery);
        }



        // POST: Delivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var delivery = _context.Deliveries.Find(id);
            if (delivery == null)
            {
                return NotFound();
            }



            _context.Deliveries.Remove(delivery);
            _context.SaveChanges();



            return RedirectToAction(nameof(Index));
        }



        private void PopulateDeliveryAgentsDropdown(int? selectedAgentId = null)
        {
            ViewBag.DeliveryAgentId = new SelectList(_context.DeliveryAgents, "Id", "Name", selectedAgentId);
        }
    }
}