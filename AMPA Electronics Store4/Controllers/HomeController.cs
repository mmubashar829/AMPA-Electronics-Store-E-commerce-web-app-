using AMPA_Electronics_Store4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPA_Electronics_Store4.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult IndexCustomer()
        {
            return View();
        }

        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult Products(int? id , char? id1)
        {
            ProductsModel pr = new ProductsModel();
            pr.Cat = db.Categories.ToList();
            if (id == null)
            {
                pr.Pro = db.Products.ToList();
            }
            else if (id == 0)
            {
                pr.Pro = db.Products.ToList();
            }
            else if (id1 == 'a')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_SALEPRICE < 10000).ToList();
            }
            else if (id1 == 'b')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_SALEPRICE >= 10000 & p.PRODUCT_SALEPRICE <= 20000).ToList();
            }
            else if (id1 == 'c')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_SALEPRICE >= 20000 & p.PRODUCT_SALEPRICE <= 30000).ToList();
            }
            else if (id1 == 'd')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_SALEPRICE >= 30000 & p.PRODUCT_SALEPRICE <= 40000).ToList();
            }
            else if (id1 == 'e')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_SALEPRICE >= 40000 & p.PRODUCT_SALEPRICE <= 50000).ToList();
            }
            else if (id1 == 'f')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_SALEPRICE > 50000).ToList();
            }
            else if (id1 == 'g')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_DISCOUNT >= 5).ToList();
            }
            else if (id1 == 'h')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_DISCOUNT >= 10).ToList();
            }
            else if (id1 == 'i')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_DISCOUNT >= 20).ToList();
            }
            else if (id1 == 'j')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_DISCOUNT >= 30).ToList();
            }
            else if (id1 == 'k')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_DISCOUNT >= 40).ToList();
            }
            else if (id1 == 'l')
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_DISCOUNT >= 50).ToList();
            }
            else
            {
                pr.Pro = db.Products.Where(p => p.CATEGORY_FID == id).ToList();
            }
            return View(pr);
        }
        public ActionResult Appliances()
        {
            ViewBag.Message = "Your Appliances page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Feedback()
        {
            ViewBag.Message = "Your Feedback page.";

            return View();
        }
        public ActionResult FAQS()
        {
            ViewBag.Message = "Your FAQS page.";

            return View();
        }
        public ActionResult TermsConditions()
        {
            ViewBag.Message = "Your Terms & Conditions page.";

            return View();
        }
        public ActionResult Privacy()
        {
            ViewBag.Message = "Your Privacy page.";

            return View();
        }
        public ActionResult CheckoutOrder()
        {
            ViewBag.Message = "Your Checkout Order page.";

            return View();
        }
        public ActionResult PaymentMethod()
        {
            ViewBag.Message = "Your Payment Method page.";

            return View();

        }
        // login start from here
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            Admin admin = db.Admins.Where(x => x.ADMIN_EMAIL == a.ADMIN_EMAIL && x.ADMIN_PASSWORD == a.ADMIN_PASSWORD).FirstOrDefault();
            if (admin != null)
            {
                Session["Admin"] = admin;
                return RedirectToAction("IndexAdmin", "Home");
            }

            else
            {
                ViewBag.Message = "Invalid email or password";
                return View();
            }
        }
        // Login end here
        public ActionResult Logout()
        {
            Session["Admin"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult AddToCart(int id)
        {
            List<Product> list;
            if (Session["mycart"] == null)
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
            if (isproductexist == false)
            {
                list.Add(db.Products.Where(p => p.PRODUCT_ID == id).FirstOrDefault());
                list[list.Count - 1].PRO_QUANTITY = 1;
            }

            Session["mycart"] = list;
            return RedirectToAction("CheckoutOrder");
        }
        public ActionResult MinusFromCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["mycart"];
            //if (list[RowNo].PRO_QUANTITY > 0)
            //{
            list[RowNo].PRO_QUANTITY--;
            if (list[RowNo].PRO_QUANTITY == 0)
                list.RemoveAt(RowNo);
            Session["mycart"] = list;
            //}
            return RedirectToAction("CheckoutOrder");
        }
        public ActionResult PlusToCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["mycart"];
            //if (list[RowNo].PRO_QUANTITY < list[RowNo].OrderDetails.Select(x => x.QUANTITY).Sum())
            //{
            int P_ID = list[RowNo].PRODUCT_ID;
            int? available = db.OrderDetails.Where(x => x.PRODUCT_FID == P_ID).Sum(x => x.QUANTITY);
            if (available > list[RowNo].PRO_QUANTITY)
                list[RowNo].PRO_QUANTITY++;
            Session["mycart"] = list;
            //}
            return RedirectToAction("CheckoutOrder");
        }
        public ActionResult RemoveFromCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["mycart"];
            list.RemoveAt(RowNo);
            Session["mycart"] = list;
            return RedirectToAction("CheckoutOrder");
        }

        public ActionResult PayNow(Order o)
        {
            o.ORDER_DATE = System.DateTime.Now;
            o.ORDER_TYPE = "Sale";
            o.STATUS = "Active";
            if ("Customer" != null)
            {
                Customer c = (Customer)Session["Customer"];
                o.CUSTOMER_FID = c.CUSTOMER_ID; 
            }
            Session["Order"] = o;
            if (o.ORDER_STATUS == "Cash on Delivery")
            {
                return RedirectToAction("OrderBooked");
            }
            else
            {
                return RedirectToAction("OrderBooked");
            }
        }
        public ActionResult OrderBooked()
        {
            Order or = (Order)Session["Order"];
            //1. code for sending email
            //2. code for sending sms
            //3. code for saving order in order & details table 
            _ = db.Orders.Add(or);
            _ = db.SaveChanges();

            List<Product> p = (List<Product>)Session["mycart"];
            for (int i = 0; i < p.Count; i++)
            {
                OrderDetail od = new OrderDetail();
                int orderID = db.Orders.Max(x => x.ORDER_ID);
                od.ORDER_FID = orderID;
                od.PRODUCT_FID = p[i].PRODUCT_ID;
                od.QUANTITY = p[i].PRO_QUANTITY * -1;
                od.PURCHASE_PRICE = p[i].PRODUCT_PURCHASEPRICE;
                od.SALE_PRICE = p[i].PRODUCT_SALEPRICE;
                _ = db.OrderDetails.Add(od);
                _ = db.SaveChanges();
            }
            return View();
        }
        public ActionResult QuickView(int id1)
        {
            List<Product> list = new List<Product>();
            list.Add(db.Products.Where(p => p.PRODUCT_ID == id1).FirstOrDefault());
            Session["QuickView"] = list;
            return View();
        }
        public ActionResult CloseOrder()
        {
            Session["mycart"] = null;
            Session["Order"] = null;
            return RedirectToAction("IndexCustomer");
        }
        public ActionResult Search(string name)
        {
            ProductsModel pr = new ProductsModel();
            pr.Cat = db.Categories.ToList();
            if (name != null)
            {
                pr.Pro = db.Products.Where(p => p.PRODUCT_NAME.Contains(name)).ToList();
            }
            return View(pr);
        }
        public ActionResult Post(Feedback f)
        {
            Session["feedback"] = f;
            return RedirectToAction("Posted");
        }
        public ActionResult Posted()
        {
            Feedback fd = (Feedback)Session["feedback"];
            if (Session["customer"] != null)
            {
                Customer c = (Customer)Session["customer"];
                fd.CUSTOMER_FID = c.CUSTOMER_ID;
                _ = db.Feedbacks.Add(fd);
                _ = db.SaveChanges();
            }
            else
            {
                _ = db.Feedbacks.Add(fd);
                _ = db.SaveChanges();
            }
            
            return View();
        }
    }
}