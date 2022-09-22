using Microsoft.AspNetCore.Mvc;
using RestEase;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.JsonPatch;
using FridgeUI.RequestFeatures;
using FridgeUI.Models.DataTransferObjects;

namespace FridgeUI.Interfaces
{
    [Header("FridgeModel-Agent", "RestEase")]
    public interface IFridgeModelApi
    {
        [Head("api/fridges/{fridgeId}/fridge_models")]
        [Get("api/fridges/{fridgeId}/fridge_models")]
        Task<IActionResult> GetFridgeModelsForFridge([Path] Guid fridgeId,
        [Query] FridgeModelParameters fridgeModelParameters);

        [Get("api/fridges/{fridgeId}/fridge_models/{id}")]
        Task<IActionResult> GetFridgeModelForFridge([Path] Guid fridgeId, [Path] Guid id);

        [Post("api/fridges/{fridgeId}/fridge_models")]
        Task<IActionResult> CreateFridgeModelForFridge([Path] Guid fridgeId,
            [Body] FridgeModelForCreationDto fridgeModelForCreationDto);

        [Delete("api/fridges/{fridgeId}/fridge_models/{id}")]
        Task<IActionResult> DeleteFridgeModelForFridge([Path] Guid fridgeId, [Path] Guid id);

        [Put("api/fridges/{fridgeId}/fridge_models/{id}")]
        Task<IActionResult> UpdateFridgeModelForFridge([Path] Guid fridgeId, [Path] Guid id,
            [Body] FridgeModelForUpdateDto fridgeModelForUpdateDto);

        [Patch("api/fridges/{fridgeId}/fridge_models")]
        Task<IActionResult> PartiallyUpdateFridgeModelForFridge([Path] Guid fridgeId, [Path] Guid id,
            [FromBody] JsonPatchDocument<FridgeModelForUpdateDto> patchDoc);
    }
}
