using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;
using System.Collections.Generic;

namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IRecentlyViewedProductsService _recentlyViewedProductsService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly ICatalogModelFactory _catalogModelFactory;
        private readonly IStoreContext _storeContext;


        public HomeController(CatalogSettings catalogSettings,
    IAclService aclService,
    IProductModelFactory productModelFactory,
    IProductService productService,
    IRecentlyViewedProductsService recentlyViewedProductsService,
    ICatalogModelFactory catalogModelFactory,
    IStoreContext storeContext,
    IStoreMappingService storeMappingService)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _recentlyViewedProductsService = recentlyViewedProductsService;
            _storeMappingService = storeMappingService;
            _catalogModelFactory = catalogModelFactory;
            _storeContext = storeContext;

        }
        public virtual IActionResult Index()
        {
            int? productThumbPictureSize = 650;
            bool? preparePriceModel = true;
            if (!_catalogSettings.RecentlyViewedProductsEnabled)
                return Content("");

            var preparePictureModel = productThumbPictureSize.HasValue;
            var products = _recentlyViewedProductsService.GetRecentlyViewedProducts(_catalogSettings.RecentlyViewedProductsNumber);

            //ACL and store mapping
            // products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            //products = products.Where(p => _productService.ProductIsAvailable(p)).ToList();

            //if (!products.Any())
            //    return Content("");

            //prepare model
            var productViewedModel = new List<ProductOverviewModel>();
            productViewedModel.AddRange(_productModelFactory.PrepareProductOverviewModels(products,
                preparePriceModel.GetValueOrDefault(),
                preparePictureModel,
                productThumbPictureSize));

            ViewBag.recentlyViewed = productViewedModel;

            //Manufacturer Section
            if (_catalogSettings.ManufacturersBlockItemsToDisplay == 0)
                return Content("");


            var manufacturerModel = _catalogModelFactory.PrepareManufacturerAllModels();
            ViewBag.manufacturers = manufacturerModel;

            // New Arrival Section
            if (!_catalogSettings.NewProductsEnabled)
                return Content("");

            var newArrival = _productService.SearchProducts(
                storeId: _storeContext.CurrentStore.Id,
                visibleIndividuallyOnly: true,
                markedAsNewOnly: true,
                orderBy: ProductSortingEnum.CreatedOn,
                pageSize: _catalogSettings.NewProductsNumber);

            var newArrivalmodel = new List<ProductOverviewModel>();
            newArrivalmodel.AddRange(_productModelFactory.PrepareProductOverviewModels(newArrival));
            ViewBag.NewArrival = newArrivalmodel;
            return View();
        }
    }
}