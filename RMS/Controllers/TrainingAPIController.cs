using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using RMS_Service.Impl;

namespace RMS.Controllers
{
    [Route("api/Training")]
    [ApiController]
    public class TrainingAPIController : ControllerBase
    {
        private readonly TrainingService _trainingService;
        public TrainingAPIController(RMSContext context)
        {
            _trainingService = new TrainingService(context);
        }


        [HttpGet("GetAll")]
        public async Task<string> GetAllTrainingActive()
        {
            var trainingModel = _trainingService.GetAllActive();
            var result = string.Empty;
            if (trainingModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(trainingModel);
                return result;
            }
            return trainingModel.Count() == 0 ? "There's no active Training(s)" : result;
        }

        [HttpPost("Create")]
        public async Task<string> Create(TrainingCreateViewModel viewModel)
        {
            var trainingModel = _trainingService.CreateTraining(viewModel);
            var result = string.Empty;
            if (trainingModel != 0)
            {
                result = JsonConvert.SerializeObject(trainingModel);
                return result;
            }
            return trainingModel == 0 ? "Create Resource Transaction Failed!" : result;
        }

        [HttpPost("Update")]
        public async Task<string> Update(TrainingUpdateViewModel viewModel)
        {
            var trainingModel = _trainingService.UpdateTraining(viewModel);
            var result = string.Empty;
            if (trainingModel != 0)
            {
                result = JsonConvert.SerializeObject(trainingModel);
                return result;
            }
            return trainingModel == 0 ? "Create Resource Transaction Failed!" : result;
        }

        [HttpPost("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var trainingModel = _trainingService.DeleteTraining(id, UserAccountId);
            var result = string.Empty;
            if (trainingModel != 0)
            {
                result = JsonConvert.SerializeObject(trainingModel);
                return result;
            }
            return trainingModel == 0 ? "Delete Resource Transaction Failed!" : result;
        }

        [HttpPost("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var trainingModel = _trainingService.RestoreTraining(id, UserAccountId);
            var result = string.Empty;
            if (trainingModel != 0)
            {
                result = JsonConvert.SerializeObject(trainingModel);
                return result;
            }
            return trainingModel == 0 ? "Delete Resource Transaction Failed!" : result;
        }

        [HttpGet("GetTraineeSelection")]
        public async Task<string> GetTraineeSelectionList()
        {
            var trainingModel = _trainingService.GetAllTraineeSelectionList();
            var result = string.Empty;
            if (trainingModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(trainingModel);
                return result;
            }
            return trainingModel.Count() == 0 ? "There's no active Bench Resource" : result;
        }



    }
}
