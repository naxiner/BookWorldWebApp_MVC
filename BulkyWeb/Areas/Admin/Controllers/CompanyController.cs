using BookWorld.Models;
using Microsoft.AspNetCore.Mvc;
using BookWorld.DataAccess.Repository.IRepository;
using BookWorld.Utility;
using Microsoft.AspNetCore.Authorization;

namespace BookWorldWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objProductList = _unitOfWork.Company.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {
            if(id == null || id == 0)
            {
                // To create
				return View(new Company());
			}
            else
            {
                // To update
				Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
				return View(companyObj);
			}
        }

        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {
                if (companyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
					_unitOfWork.Company.Update(companyObj);
				}

                _unitOfWork.Save();
                TempData["success"] = "Company successfully created!";
                return RedirectToAction("Index");
            }
            else
            {
			    return View(companyObj);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
			List<Company> objCompanytList = _unitOfWork.Company.GetAll().ToList();
		    return Json(new {data = objCompanytList });
        }

        [HttpDelete]
		public IActionResult Delete(int? id)
		{
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

			List<Company> objCompanytList = _unitOfWork.Company.GetAll().ToList();
			return Json(new { success = true, message = "Delete Successful" });
		}

		#endregion
	}
}
