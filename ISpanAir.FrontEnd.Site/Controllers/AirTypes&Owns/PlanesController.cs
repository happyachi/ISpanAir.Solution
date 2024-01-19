using Seats.Models.Dtos;
using Seats.Models.Entities;
using Seats.Models.Interfaces;
using Seats.Models.Repositories;
using Seats.Models.Services;
using Seats.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Seats.Controllers
{
	public class PlanesController : Controller
	{
		// GET: Planes
		public ActionResult Index()
		{
			//var _repo=new PlaneRepository();
			IPlaneRepository _repo = new PlaneRepository();
			var planeService = new PlaneService(_repo);
			var list = planeService.GetAll()//dto格式
				.Select(p => new PlaneVmIndex
				{
					Id = p.ID,
					FlightModel = p.FlightModel,
					ManufactureCompany = p.ManufactureCompany,
				})
				.ToList();

			return View(list);//vm格式
		}
		public ActionResult Create()
		{ return View(); }

		[HttpPost]
		public ActionResult Create(PlaneVm model)

		{
			if (!ModelState.IsValid) return View(model);
			try
			{
				CreateProduct(model);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(model);
			}
			//catch (DbEntityValidationException ex)
			//{
			//	foreach (var entityValidationErrors in ex.EntityValidationErrors)
			//	{
			//		foreach (var validationError in entityValidationErrors.ValidationErrors)
			//		{
			//			Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");

			//		}
			//	}
			//return View(model);
			//}

		}

		private void CreateProduct(PlaneVm model)
		{
			IPlaneRepository _repo = new PlaneRepository();
			var planeService = new PlaneService(_repo);
			PlaneDto dto = new PlaneDto
			{
				ID = model.Id,
				FlightModel = model.FlightModel,
				TotalSeat = model.TotalSeat,
				MaxMile = model.MaxMile,
				MaxWeight = model.MaxWeight,
				ManufactureCompany = model.ManufactureCompany,
			};

			planeService.Create(dto);
		}

		public void Update(PlaneVm model)
		{
			IPlaneRepository _repo = new PlaneRepository();
			var planeService = new PlaneService(_repo);
			PlaneDto dto = new PlaneDto
			{
				ID = model.Id,
				FlightModel = model.FlightModel,
				TotalSeat = model.TotalSeat,
				MaxMile = model.MaxMile,
				MaxWeight = model.MaxWeight,
				ManufactureCompany = model.ManufactureCompany,
			};

			planeService.Update(dto);
		}

		public ActionResult Delete(int? id)
		{

			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			return View();
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]

		public ActionResult DeleteConfirmed(int id)
		{
			IPlaneRepository _repo = new PlaneRepository();
			var planeService = new PlaneService(_repo);
			planeService.Delete(id);

			return RedirectToAction("Index");
		}

		//todo public ActionResult Details() { }





	}
}