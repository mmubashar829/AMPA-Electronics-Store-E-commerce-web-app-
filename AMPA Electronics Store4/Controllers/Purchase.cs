using AMPA_Electronics_Store4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPA_Electronics_Store4.Controllers
{
    public class PurchaseController : Controller
    {
        Model1 db = new Model1();
        public ActionResult PurchaseProducts(int? id)
        {
            ProductsModel pr = new ProductsModel();
            pr.Cat = db.Categories.ToList();
            if (id == null)
            {
                pr.Pro = db.Products.ToList();
            }
            else
            {
                pr.Pro = db.Products.Where(p => p.CATEGORY_FID == id).ToList();
            }
            return View(pr);
        }
        public ActionResult PurchaseCheckout()
        {
            ViewBag.Message = "Your Checkout Purchase page.";

            return View();
        }
        public ActionResult AddToCart(int id)
        {
            List<Product> list;
            if (Session["mycart"]== null)
            {
                list = new List<Product>();
            }
            else
            {
                list = (List<Product>)Session["mycart"];
            }
            Boolean isproductexist = false;
            foreach (var item in list)
            {
                if (id == item.PRODUCT_ID)
                {
                    isproductexist = true;
                    item.PRO_QUANTITY++;
                }
            }
            if(isproductexist == false)
            {
                list.Add(db.Products.Where(p => p.PRODUCT_ID == id).FirstOrDefault());
                list[list.Count - 1].PRO_QUANTITY = 1;
            }
               
            Session["mycart"] = list;
            return RedirectToAction("PurchaseCheckout");
        }
        public ActionResult MinusFromCart(int RowNo)
        {
            List<Product> list =  (List<Product>)Session["mycart"];
            list[RowNo].PRO_QUANTITY -= 2;
            Session["mycart"] = list;
            return RedirectToAction("PurchaseCheckout");
        }
        public ActionResult PlusToCart(int RowNo)
        {
            List<Product> list =  (List<Product>)Session["mycart"];
            list[RowNo].PRO_QUANTITY += 3;
            Session["mycart"] = list;
            return RedirectToAction("PurchaseCheckout");
        }
        public ActionResult RemoveFromCart(int RowNo)
        {
            List<Product> list =  (List<Product>)Session["mycart"];
            list.RemoveAt(RowNo);
            Session["mycart"] = list;
            return RedirectToAction("PurchaseCheckout");
        }
        
        public ActionResult PurchaseNow(Order o)
        {
            o.ORDER_DATE = System.DateTime.Now;
            o.ORDER_STATUS = "Paid";
            o.ORDER_TYPE = "Purchase";
            Session["Order"] = o;
            return RedirectToAction("PurchaseBooked");
        }
        public ActionResult PurchaseBooked()
        {
            Order o = (Order)Session["Order"];
            //1. code for sending email
            //2. code for sending sms
            //3. code for saving order in order & details table 
            _ = db.Orders.Add(o);
            _ = db.SaveChanges();

            List<Product> p = (List<Product>)Session["mycart"];
            for (int i = 0; i < p.Count; i++)
            {
                OrderDetail od = new OrderDetail();
                int orderID = db.Orders.Max(x => x.ORDER_ID);
                od.ORDER_FID = orderID;
                od.PRODUCT_FID = p[i].PRODUCT_ID;
                od.QUANTITY = p[i].PRO_QUANTITY;
                od.PURCHASE_PRICE = p[i].PRODUCT_PURCHASEPRICE;
                od.SALE_PRICE = p[i].PRODUCT_SALEPRICE;
                _ = db.OrderDetails.Add(od);
                _ = db.SaveChanges();
            }
            return View();
        }
    }
}