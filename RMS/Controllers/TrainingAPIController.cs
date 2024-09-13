using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMS_COBOL.Impl;
using RMS_DAL.Enum;
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
        private readonly CobolService _cobolService;
        string cobolAppPath = AppSett.ConfigurationManager.AppSetting["COBOLAPPPATH"];
        string cobolCond = AppSett.ConfigurationManager.AppSetting["COBOLACTIVATE"];

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
                try
                {
                    result = JsonConvert.SerializeObject(trainingModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.CreatedByUserId.ToString() + ", CREATE TRAINING", cobolAppPath);
                    }
                }
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
                try
                {
                    result = JsonConvert.SerializeObject(trainingModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, viewModel.UpdatedByUserId.ToString() + ", UPDATE TRAINING", cobolAppPath);
                    }
                }
            }
            return trainingModel == 0 ? "Create Resource Transaction Failed!" : result;
        }

        [HttpGet("Delete")]
        public async Task<string> Delete(int id, int UserAccountId)
        {
            var trainingModel = _trainingService.DeleteTraining(id, UserAccountId);
            var result = string.Empty;
            if (trainingModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(trainingModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", DELETE TRAINING", cobolAppPath);
                    }
                }
            }
            return trainingModel == 0 ? "Delete Resource Transaction Failed!" : result;
        }

        [HttpGet("Restore")]
        public async Task<string> Restore(int id, int UserAccountId)
        {
            var trainingModel = _trainingService.RestoreTraining(id, UserAccountId);
            var result = string.Empty;
            if (trainingModel != 0)
            {
                try
                {
                    result = JsonConvert.SerializeObject(trainingModel);
                    return result;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (cobolCond == "1")
                    {
                        _cobolService.WriteLog((int)Cobol.TRANSLOG, UserAccountId.ToString() + ", RESTORE TRAINING", cobolAppPath);
                    }
                }
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

        [HttpGet("GetTrainerSelection")]
        public async Task<string> GetTrainerSelectionList()
        {
            var trainerModel = _trainingService.GetAllTrainerSelectionList();
            var result = string.Empty;
            if (trainerModel.Count() != 0)
            {
                result = JsonConvert.SerializeObject(trainerModel);
                return result;
            }
            return trainerModel.Count() == 0 ? "There's no active Trainer" : result;
        }

        [HttpGet("GetById")]
        public async Task<string> GetById(int Id)
        {
            var trainerModel = _trainingService.GetById(Id);
            var result = string.Empty;
            if (trainerModel.TrainingId != 0)
            {
                result = JsonConvert.SerializeObject(trainerModel);
                return result;
            }
            return trainerModel.TrainingId == 0 ? "Training not found" : result;
        }




    }
}
