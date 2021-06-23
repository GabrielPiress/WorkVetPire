using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VetPireWork.Models;
using VetPireWork.Models.ViewModels;
using VetPireWork.Services;
using VetPireWork.Services.Exceptions;

namespace VetPireWork.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService,
                                 DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Create(seller);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error", new { message = "Id Not Provided" });
            }

            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction("Error", new { message = "Id Not Found" });
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _sellerService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error", new { message = "Id Not Provided" });
            }

            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction("Error", new { message = "Id Not Found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error", new { message = "Id Not Provided" });
            }
            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction("Error", new { message = "Id Not Found" });
            }

            var DepartmentList = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = DepartmentList };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, Seller seller)
        {
            if(id != seller.Id)
            {
                return RedirectToAction("Error", new { message = "Id mismatch" });
            }

            try
            {
            _sellerService.Update(seller);
            return RedirectToAction("Index");
            }
            catch(ApplicationException e) //serve para pegar exceções de bd e de serviço
            {
                return RedirectToAction("Error", new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }





    }
}
