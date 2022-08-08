using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Test.Models.ModelsDB.ServicesImpl;
using System.Linq;
using DataBase.Entities;
using Core.Service;
using Microsoft.AspNetCore.Authorization;

namespace Test.Controllers
{
    public class AdminController : Controller
    {
        private ModelBaseService _repository;
        private List<string> _listNameTable;
        private ProductService _productService;
        private PriceService _priceService;
        private TypeProductService _typeService;
        private UserService _userService;
        private RoleService _roleService;

        public AdminController(ModelBaseService repo, ProductService productService, PriceService priceService, TypeProductService typeService, UserService userService, RoleService roleService)
        {
            _repository = repo;
            _productService = productService; 
            _typeService = typeService;
            _priceService = priceService;
            _userService = userService;
            _roleService = roleService;
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            _listNameTable = _listNameTable ?? _repository.GetTable();
            return View(_listNameTable);
        }

        #region EditTables
        [Authorize(Roles = "Admin")]
        public IActionResult EditTables(string TableName)
        {
            if (_productService.NameTable.Equals(TableName))
                return RedirectToAction("ViewTableProduct");
            if (_typeService.NameTable.Equals(TableName))
                return RedirectToAction("ViewTableTypeProduct");
            if (_priceService.NameTable.Equals(TableName))
                return RedirectToAction("ViewTablePrice");
            if (_userService.NameTable.Equals(TableName))
                return RedirectToAction("ViewTableUser");
            if (_roleService.NameTable.Equals(TableName))
                return RedirectToAction("ViewTableRole");
            return View();
        }

        public ViewResult ViewTableProduct()
        {
            return View(_productService.GetObjectList());
        }

        public ViewResult ViewTableTypeProduct()
        {
            return View(_typeService.GetObjectList());
        }

        public ViewResult ViewTablePrice()
        {
            return View(_priceService.GetObjectList());
        }

        public ViewResult ViewTableUser()
        {
            return View(_userService.GetObjectList());
        }

        public ViewResult ViewTableRole()
        {
            return View(_roleService.GetObjectList());
        }
        #endregion

        #region EditItem
        public ViewResult EditProduct(int ProductId)
        {
            Product product = _productService.GetObjectList().ToList().FirstOrDefault(g => g.Id == ProductId);
            return View(product);
        }

        public ViewResult EditTypeProduct(int TypeId)
        {
            TypeProduct type = _typeService.GetObjectList().ToList().FirstOrDefault(g => g.Id == TypeId);
            return View(type);
        }

        public ViewResult EditPrice(int PriceId)
        {
            Price price = _priceService.GetObjectList().ToList().FirstOrDefault(g => g.Id == PriceId);
            return View(price);
        }

        public ViewResult EditUser(int UserId)
        {
            User user = _userService.GetObjectList().ToList().FirstOrDefault(g => g.Id == UserId);
            return View(user);
        }

        public ViewResult EditRole(int RoleId)
        {
            Role role = _roleService.GetObjectList().ToList().FirstOrDefault(g => (int)g.Id == RoleId);
            return View(role);
        }
        #endregion Edit

        #region DeleteItem
        public IActionResult DeleteProduct(int ProductId)
        {
            _productService.Delete(ProductId);
            _productService.Save();
            return RedirectToAction("EditTableProduct", "Admin");
        }

        public IActionResult DeletePrice(int PriceId)
        {
            _productService.Delete(PriceId);
            _productService.Save();
            return RedirectToAction("EditTablePrice", "Admin");
        }

        public IActionResult DeleteTypeProduct(int TypeProductId)
        {
            _productService.Delete(TypeProductId);
            _productService.Save();
            return RedirectToAction("EditTableTypeProduct", "Admin");
        }

        public IActionResult DeleteTypeUser(int UserId)
        {
            _userService.Delete(UserId);
            _userService.Save();
            return RedirectToAction("EditTableUser", "Admin");
        }

        public IActionResult DeleteRole(int RoleId)
        {
            _roleService.Delete(RoleId);
            _roleService.Save();
            return RedirectToAction("EditTableRole", "Admin");
        }
        #endregion DeleteItem

        #region Create
        public ViewResult CreateProduct()
        {
            return View();
        }

        public ViewResult CreateTypeProduct()
        {
            return View();
        }

        public ViewResult CreatePrice()
        {
            return View();
        }

        public ViewResult CreateRole()
        {
            return View();
        }

        public ViewResult CreateUser()
        {
            return View();
        }
        #endregion Create

        #region PostCreate
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productService.Create(product);
            _productService.Save();

            return RedirectToAction("EditTable", "Admin", new { TableName = typeof(Product).Name });
        }

        [HttpPost]
        public IActionResult CreateType(TypeProduct type)
        {
            _typeService.Create(type);
            _typeService.Save();

            return RedirectToAction("EditTableTypeProduct", "Admin");
        }

        [HttpPost]
        public IActionResult CreatePrice(Price price)
        {
            _priceService.Create(price);
            _priceService.Save();

            return RedirectToAction("EditTableTypeProduct", "Admin");
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _userService.Create(user);
            _userService.Save();

            return RedirectToAction("EditTableUser", "Admin");
        }

        [HttpPost]
        public IActionResult CreateRole(Role role)
        {
            _roleService.Create(role);
            _roleService.Save();

            return RedirectToAction("EditTableRole", "Admin");
        }
        #endregion PostCreate
    }
}
