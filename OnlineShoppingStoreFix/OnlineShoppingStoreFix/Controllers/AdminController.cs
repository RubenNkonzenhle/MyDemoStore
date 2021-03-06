using Newtonsoft.Json;
using OnlineShoppingStore.Models;
using OnlineShoppingStoreFix.DAL;
using OnlineShoppingStoreFix.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStoreFix.Controllers
{
    public class AdminController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public List<SelectListItem> GetCategory()
        {

            List<SelectListItem> List = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecords();
            foreach (var item in cat)
            {
                List.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return List;
        }
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetCategoy().Where(i => i.IsDelete == false).ToList());
        }

        
       /* public ActionResult AddCategory()
        {
            return UpdateCategory(0);

        }

        public ActionResult UpdateCategory(int categoryId)
        {
            CategoryDetail cd;
            if(categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new CategoryDetail();
            }
            return View("UpdateCategory", cd);

        }*/

      //  public ActionResult CategoryEdit(int categoryId)
       // {
        //   return View("CategoryAdd",_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(categoryId));
      // }

       // [HttpPost]

       // public ActionResult CategoryEdit(Tbl_Category tbl)
       // {
            
          //  _unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(tbl);
         //   return RedirectToAction("Categories");
        //}

        public ActionResult CategoryAdd(int? Id)
        {
            if (Id > 0)
            {
                return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(Id));
            }
            return View(new Tbl_Category { CategoryId =0});
        }

        [HttpPost]

        public ActionResult CategoryAdd(Tbl_Category tbl)
        {
            tbl.IsDelete = false;
            if (tbl.CategoryId > 0)
            {
                _unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(tbl);

            }
            else
            {   
                _unitOfWork.GetRepositoryInstance<Tbl_Category>().Add(tbl);
            }

            return RedirectToAction("Categories");
        }

        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetProduct());
        }

        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(productId));
        }

        [HttpPost]

        public ActionResult ProductEdit(Tbl_Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {

                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg"), pic);
                //file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = file!=null?pic: tbl.ProductImage;

            tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Update(tbl);
            return RedirectToAction("Product");
        }

        public ActionResult ProductAdd()
        {

            ViewBag.CategoryList = GetCategory();
            return View();
        }

        [HttpPost]

        public ActionResult ProductAdd(Tbl_Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {

                 pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                //file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;

            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(tbl);
            return RedirectToAction("Product");
        }





    }
}