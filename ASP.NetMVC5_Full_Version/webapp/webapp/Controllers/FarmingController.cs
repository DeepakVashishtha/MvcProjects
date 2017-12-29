using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class FarmingController : Controller
    {
        // GET: Pests
        SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities();
        public ActionResult pests()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var listAllPestd=context.USP_Pests_All().ToList();
                return View(listAllPestd);
            }
        }
       
        public ActionResult add_pests()
        {
            Models.DbEntity.Pest pest = new Models.DbEntity.Pest();
            return View(pest);
        }
        [HttpPost]
        public ActionResult add_pests(Models.DbEntity.Pest pest)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                ObjectParameter pestId=  new ObjectParameter("pestID", typeof(global::System.Int32));
                context.USP_Pests_Insert(pest.PestName, pest.Description, pestId);
                TempData["pestId"] = pestId.Value;
                if (TempData["pestId"]!=null)
                {
                    TempData["Message"] = "Save Successfully.";
                }
                else
                {
                    TempData["Message"] = "Error Occured!!";
                }
                
            }
            return RedirectToAction("add_pests");
        }
        public ActionResult edit_pests(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var Pests = context.USP_Pests_Get(id).SingleOrDefault();
                return View(Pests);
            }
        }
        [HttpPost]
        public ActionResult edit_pests(Models.DbEntity.Pest pest)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Pests_Update(pest.PestID, pest.PestName, pest.Description);
                TempData["Message"] = "Update Successfully.";
                return RedirectToAction("pests");
            }
        }
        
        public ActionResult delete_pests(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Pests_Delete(id);
                TempData["Message"] = "Delete Successfully.";
                return RedirectToAction("pests");
            }
        }

        //Pesticides
        public ActionResult pesticides()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var listAllPesticides = context.USP_Pesticides_All().ToList();
                return View(listAllPesticides);
            }
        }

        public ActionResult add_pesticides()
        {
            Models.DbEntity.Pesticide pesticide = new Models.DbEntity.Pesticide();
            ViewBag.ProductMeasurementType = GetProductMeasurementType();
            return View(pesticide);
        }
        [HttpPost]
        public ActionResult add_pesticides(Models.DbEntity.Pesticide pesticide)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                ObjectParameter PesticideID = new ObjectParameter("PesticideID", typeof(global::System.Int32));
                context.USP_Pesticides_Insert(pesticide.PesticideName, pesticide.RatesListedPer, pesticide.RestrictedUseData, pesticide.RestrictedEntryLevelData, pesticide.PesticideLabelSignalWord, pesticide.WPSOralNotification,pesticide.Toxicity, pesticide.Formulation, pesticide.ActiveIndegrident, pesticide.EPARegistrationNumber, pesticide.RestrictedEntryInterval, pesticide.ProductRate, pesticide.ProductMeasurementTypeID, pesticide.TotalProductConsumed, pesticide.ApplicatorName, pesticide.CertificationNumber, pesticide.Speed, pesticide.MPH, pesticide.GPA, pesticide.Concentration, pesticide.SprayRig, pesticide.NozzelSetup, pesticide.SprayingInstructions,PesticideID);
                TempData["PesticideID"] = PesticideID.Value;
                if (TempData["PesticideID"] != null)
                {
                    TempData["Message"] = "Save Successfully.";
                }
                else
                {
                    TempData["Message"] = "Error Occured!!";
                }

            }
            return RedirectToAction("add_pesticides");
        }
        public ActionResult edit_pesticides(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var pesticides = context.USP_Pesticides_Get(id).SingleOrDefault();
                return View(pesticides);
            }
        }
        [HttpPost]
        public ActionResult edit_pesticides(Models.DbEntity.Pesticide pesticide)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Pesticides_Update(pesticide.PesticideID,pesticide.PesticideName, pesticide.RatesListedPer, pesticide.RestrictedUseData, pesticide.RestrictedEntryLevelData, pesticide.PesticideLabelSignalWord, pesticide.WPSOralNotification, pesticide.Formulation, pesticide.ActiveIndegrident, pesticide.EPARegistrationNumber, pesticide.RestrictedEntryInterval, pesticide.ProductRate, pesticide.ProductMeasurementTypeID, pesticide.TotalProductConsumed, pesticide.ApplicatorName, pesticide.CertificationNumber, pesticide.Speed, pesticide.MPH, pesticide.GPA, pesticide.Concentration, pesticide.SprayRig, pesticide.NozzelSetup, pesticide.SprayingInstructions);
                TempData["Message"] = "Update Successfully.";
                return RedirectToAction("pesticides");
            }
        }

        public ActionResult delete_pesticides(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Pesticides_Delete(id);
                TempData["Message"] = "Delete Successfully.";
                return RedirectToAction("pesticides");
            }
        }

        public List<SelectListItem> GetProductMeasurementType()
        {
            using (
                SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities())
            {
                var vProductMeasurementType = (from tblProductMeasurementType in entity.ProductMeasurementTypes
                                               select new SelectListItem
                                               {
                                                   Text = tblProductMeasurementType.ProductMeasurementTypeName,
                                                   Value = tblProductMeasurementType.ProductMeasurementTypeID.ToString()
                                               });

                return vProductMeasurementType.ToList();
            }


        }

        public ActionResult Growers()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var listAllSuppliers = context.USP_Suppliers_All().ToList();
                return View(listAllSuppliers);
            }

            // return View();
        }

        public ActionResult add_Growers()
        {

            Models.DbEntity.Supplier supplier = new Models.DbEntity.Supplier();
            return View(supplier);
        }
        [HttpPost]
        public ActionResult add_Growers(Models.DbEntity.Supplier supplier)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                ObjectParameter supplierID = new ObjectParameter("SupplierID", typeof(global::System.Int32));
                context.USP_Suppliers_Insert(supplier.CompanyName, supplier.ContactName, supplier.ContactTitle, supplier.Address, supplier.City, supplier.Region, supplier.PostalCode,
          supplier.Country, supplier.Phone, supplier.Fax, supplier.HomePage, supplier.Email, supplier.CompanyUCCprefix, supplierID);
                TempData["SupplierID"] = supplierID.Value;
                if (TempData["SupplierID"] != null)
                {
                    TempData["Message"] = "Save Successfully.";
                }
                else
                {
                    TempData["Message"] = "Error Occured!!";
                }
            }
            return RedirectToAction("Growers");
        }

        public ActionResult edit_Growers(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var Growers = context.USP_Suppliers_Get(id).SingleOrDefault();
                return View(Growers);
            }
        }
        [HttpPost]
        public ActionResult edit_Growers(Models.DbEntity.Supplier supplier)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Suppliers_Update(supplier.SupplierID, supplier.CompanyName, supplier.ContactName, supplier.ContactTitle, supplier.Address, supplier.City, supplier.Region, supplier.PostalCode, supplier.Country, supplier.Phone, supplier.Fax, supplier.HomePage, supplier.Email, supplier.CompanyUCCprefix);
                TempData["Message"] = "Update Successfully.";
                return RedirectToAction("Growers");
            }
        }

        public ActionResult delete_Growers(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Suppliers_Delete(id);
                TempData["Message"] = "Delete Successfully.";
                return RedirectToAction("Growers");
            }
        }

        public ActionResult FarmFields()
        {

            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var listAllFarmFields = context.USP_FarmFields_All().ToList();
                return View(listAllFarmFields);
            }

            // return View();
        }

        public List<SelectListItem> GetFarmFields()
        {
            using (
                SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities())
            {
                var vSuppliersType = (from tblSuppliers in entity.Suppliers
                                      select new SelectListItem
                                      {
                                          Text = tblSuppliers.CompanyName,
                                          Value = tblSuppliers.SupplierID.ToString()
                                      });

                return vSuppliersType.ToList();
            }


        }


        public ActionResult add_FarmFields()
        {
            ViewBag.SuppliersTypeDDL = GetFarmFields();
            Models.DbEntity.FarmField FarmFields = new Models.DbEntity.FarmField();
            return View(FarmFields);
        }

        [HttpPost]
        public ActionResult add_FarmFields(Models.DbEntity.FarmField farmField)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                ObjectParameter farmFieldID = new ObjectParameter("FarmFieldID", typeof(global::System.Int32));
                context.USP_FarmFields_Insert(farmField.FieldIDNumber, farmField.FieldName, farmField.SupplierID, farmField.LegalDescription, farmField.TotalAcres, farmField.IrrigationSource1, farmField.IrrigationSource2, farmField.IrrigationSource3, farmField.Comments, farmFieldID);
                TempData["SupplierID"] = farmFieldID.Value;
                if (TempData["SupplierID"] != null)
                {
                    TempData["Message"] = "Save Successfully.";
                }
                else
                {
                    TempData["Message"] = "Error Occured!!";
                }
            }
            //return View();
            return RedirectToAction("add_FarmFields");
        }





        public ActionResult edit_FarmFields(int id)
        {
            ViewBag.SuppliersTypeDDL = GetFarmFields();
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var FarmFields = context.USP_FarmFields_Get(id).SingleOrDefault();
                return View(FarmFields);
            }
        }
        [HttpPost]
        public ActionResult edit_FarmFields(Models.DbEntity.FarmField farmField)
        {

            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_FarmFields_Update(farmField.FarmFieldID, farmField.FieldIDNumber, farmField.FieldName, farmField.SupplierID, farmField.LegalDescription, farmField.TotalAcres, farmField.IrrigationSource1, farmField.IrrigationSource2, farmField.IrrigationSource3, farmField.Comments);
                TempData["Message"] = "Update Successfully.";
                return RedirectToAction("FarmFields");
            }
        }



        public ActionResult delete_FarmFields(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_FarmFields_Delete(id);
                TempData["Message"] = "Delete Successfully.";
                return RedirectToAction("FarmFields");
            }
        }

        // Farming Dashbord

        public ActionResult FarmDashboard()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var TotalData = context.USP_FarmDashboard_HF().ToList();
                ViewBag.TotalData = TotalData;
                var farmdashboardSummary = context.USP_FarmDashboard_Summary().ToList();
                var farmdashboardByStages = context.USP_FarmDashboard_ByStages().ToList();
                ViewBag.farmdashboardSummary = farmdashboardSummary;
                ViewBag.farmdashboardByStages = farmdashboardByStages;
                return View();
            }
        }

        public ActionResult FarmByCategoryBarChart(string Year,string Month)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var farmbycategoryList = context.USP_FarmDashboard_ByCategory(Year, Month).ToList();
                var TotalData = context.USP_FarmDashboard_HF().ToList();
                ViewBag.TotalData = TotalData;
                ViewBag.farmbycategoryList = farmbycategoryList;
                
                return Json(farmbycategoryList, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult FarmByLotBarChat(string Year, string Month)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var farmbylotList = context.USP_FarmDashboard_ByLot(Year, Month).ToList();
                ViewBag.farmbylotList = farmbylotList;
                var farmdashboardSummary = context.USP_FarmDashboard_Summary().ToList();
                var farmdashboardByStages = context.USP_FarmDashboard_ByStages().ToList();
                ViewBag.farmdashboardSummary = farmdashboardSummary;
                ViewBag.farmdashboardByStages = farmdashboardByStages;
                return Json(farmbylotList, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult LiveFarmDashboard()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var farmdashboardSummary = context.USP_FarmDashboard_Summary().ToList();
                var farmdashboardByStages = context.USP_FarmDashboard_ByStages().ToList();
                ViewBag.farmdashboardSummary = farmdashboardSummary;
                ViewBag.farmdashboardByStages = farmdashboardByStages;
                return View();
            }
        }
        public ActionResult vFarmDashboard()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var TotalData = context.USP_FarmDashboard_HF().ToList();
                ViewBag.TotalData = TotalData;
                var farmdashboardSummary = context.USP_FarmDashboard_Summary().ToList();
                var farmdashboardByStages = context.USP_FarmDashboard_ByStages().ToList();
                ViewBag.farmdashboardSummary = farmdashboardSummary;
                ViewBag.farmdashboardByStages = farmdashboardByStages;
                return View();
            }
        }
    }
}