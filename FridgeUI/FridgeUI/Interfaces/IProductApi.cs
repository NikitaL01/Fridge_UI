using Microsoft.AspNetCore.Mvc;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FridgeUI.Models.DataTransferObjects;
using FridgeUI.ModelBinders;

namespace FridgeUI.Interfaces
{
    [Header("Product-Agent", "RestEase")]
    public interface IProductApi
    {
        [Get("api/products")]
        Task<IActionResult> GetProducts();

        [Get("api/products/{id}")]
        Task<IActionResult> GetProduct([Path] Guid id);

        [Post("api/products")]
        Task<IActionResult> CreateProduct([Body] ProductForCreationDto product);

        [Get("api/products/collection/{ids}")]
        Task<IActionResult> GetProductCollection([Path] [ModelBinder(BinderType = typeof(ArrayModelBinder))]
        IEnumerable<Guid> ids);

        [Post("api/products/collection")]
        Task<IActionResult> CreateProductCollection(IEnumerable<ProductForCreationDto> productCollection);

        [Delete("api/products/{id}")]
        Task<IActionResult> DeleteProduct([Path] Guid id);

        [Put("api/products/{id}")]
        Task<IActionResult> UpdateProduct([Path] Guid id, [Body] ProductForUpdateDto product);

        [Options("api/products")]
        IActionResult GetFridgesOptions();
    }
}
