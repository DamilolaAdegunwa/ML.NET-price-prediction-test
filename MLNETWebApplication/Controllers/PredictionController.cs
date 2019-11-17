using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using MLNETWebApplicationML.Model;

namespace MLNETWebApplication.Controllers
{
    public class PredictionController : Controller
    {
        public IActionResult Price(ModelInput input)
        {
            // Load the model  
            MLContext mlContext = new MLContext();
            // Create predection engine related to the loaded train model  
            ITransformer mlModel = mlContext.Model.Load(@"..\MLNETWebApplicationML.Model\MLModel.zip", out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Try model on sample data to predict fair price  
            ModelOutput result = predEngine.Predict(input);

            ViewBag.Price = result.Score;
            return View(input);
        }
    }
}