using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using tsar80323.DAL.Data;
using tsar80323.DAL.Entities;
using tsar80323.Extensions;
using tsar80323.Models;

namespace tsar80323.Controllers
{



    //    public class ProductController : Controller
    //    {


    //        ApplicationDbContext _context;


    //        public List<Dish> _dishes;
    //        List<DishGroup> _dishGroups;

    //        int _pageSize;

    //        public ProductController(ApplicationDbContext context)
    //        {
    //            _pageSize = 3;
    //            _context = context;
    //        }
    //        //public IActionResult Index(int? group, int pageNo = 1)
    //        //{

    //        //    var dishesFiltered = _dishes
    //        //    .Where(d => !group.HasValue || d.DishGroupId == group.Value);


    //        //    ViewData["Groups"] = _dishGroups;

    //        //    ViewData["CurrentGroup"] = group ?? 0;


    //        //   return View(ListViewModel<Dish>.GetModel(dishesFiltered,pageNo, _pageSize));



    //        // }

    //        [Route("Catalog")]
    //        [Route("Catalog/Page_{pageNo}")]
    //        public IActionResult Index(int? group, int pageNo = 1)
    //        {

    //            var dishesFiltered = _context.Dishes
    //                .Where(d => !group.HasValue || d.DishGroupId ==
    //group.Value);
    //            // Поместить список групп во ViewData
    //            ViewData["Groups"] = _context.DishGroups;


    //            ViewData["DishGroupId"] =
    //new SelectList(_context.DishGroups, "DishGroupId", "GroupName");








    //            //var dishesFiltered = _dishes
    //            //    .Where(d => !group.HasValue || d.DishGroupId == group.Value);


    //            //ViewData["Groups"] = _dishGroups;

    //            ViewData["CurrentGroup"] = group ?? 0;



    //            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo,_pageSize);



    //            //if (Request.Headers["x-requested-with"]
    //            //.ToString().ToLower().Equals("xmlhttprequest"))
    //            //    return PartialView("_listpartial", model);

    //            if (Request.IsAjaxRequest())
    //                return PartialView("_listpartial", model);


    //            else
    //                return View(model);



    //        }






    //        /// <summary>
    //        /// Инициализация списков
    //        /// </summary>
    //        private void SetupData()
    //        {
    //            _dishGroups = new List<DishGroup>
    //{
    //new DishGroup {DishGroupId=1, GroupName="Стартеры"},
    //new DishGroup {DishGroupId=2, GroupName="Салаты"},
    //new DishGroup {DishGroupId=3, GroupName="Супы"},
    //new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
    //new DishGroup {DishGroupId=5, GroupName="Напитки"},
    //new DishGroup {DishGroupId=6, GroupName="Десерты"}
    //};
    //            _dishes = new List<Dish>
    //{
    //new Dish {DishId = 1, DishName="Суп-харчо",Description="Очень острый, невкусный",Calories =200, DishGroupId=3, Image="s1200harcho.jpg" },
    //new Dish { DishId = 2, DishName="Борщ",Description="Много сала, без сметаны",Calories =330, DishGroupId=3, Image="s1200borsh.jpg" },
    //new Dish { DishId = 3, DishName="Котлета пожарская",Description="Хлеб - 80%, Морковь - 20%",Calories =635, DishGroupId=4, Image="s1200kotl.jpg" },
    //new Dish { DishId = 4, DishName="Макароны по-флотски",Description="С охотничьей колбаской",Calories =524, DishGroupId=4, Image="s1200makar.jpg" },
    //new Dish { DishId = 5, DishName="Компот",Description="Быстро растворимый, 2 литра",Calories =180, DishGroupId=5, Image="s1200kompt.jpg" }
    //};
    //        }
    //    }



    //}




    public class ProductController : Controller
    {
        //public List<Dish> _dishes;
        //List<DishGroup> _dishGroups;
        readonly int _pageSize;
        ApplicationDbContext _context;
        ILogger _logger;





                                                                    //4.2 уберите логгер
        public ProductController(ApplicationDbContext context     /* , ILogger<ProductController> logger*/)
        {
            _context = context;
            //SetupData();
            _pageSize = 3;

            //4.2 уберите логгер

            //_logger = logger;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DishGroups;

            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;




            //9 4.11


            //4.2 уберите логгер

            //_logger.LogInformation($"info: group={group}, page={pageNo}");



            var dishesFiltered = _context.Dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);


            
            
            



        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        //private void SetupData()
        //{
        //    _dishGroups = new List<DishGroup>
        //    {
        //        new DishGroup {DishGroupId=1, GroupName="Стартеры"},
        //        new DishGroup {DishGroupId=2, GroupName="Салаты"},
        //        new DishGroup {DishGroupId=3, GroupName="Супы"},
        //        new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
        //        new DishGroup {DishGroupId=5, GroupName="Напитки"},
        //        new DishGroup {DishGroupId=6, GroupName="Десерты"}
        //    };

        //    _dishes = new List<Dish>
        //    {
        //        new Dish {DishId = 1, DishName="Суп-харчо",
        //            Description="Очень острый, невкусный",
        //            Calories =200, DishGroupId=3, Image="Суп.jpg" },
        //        new Dish { DishId = 2, DishName="Борщ",
        //            Description="Много сала, без сметаны",
        //            Calories =330, DishGroupId=3, Image="Борщ.jpg" },
        //        new Dish { DishId = 3, DishName="Котлета пожарская",
        //            Description="Хлеб - 80%, Морковь - 20%",
        //            Calories =635, DishGroupId=4, Image="Котлета.jpg" },
        //        new Dish { DishId = 4, DishName="Макароны по-флотски",
        //            Description="С охотничьей колбаской",
        //            Calories =524, DishGroupId=4, Image="Макароны.jpg" },
        //        new Dish { DishId = 5, DishName="Компот",
        //            Description="Быстро растворимый, 2 литра",
        //            Calories =180, DishGroupId=5, Image="Компот.jpg" }
        //    };
        //}
    }
}