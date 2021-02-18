using FileUpload.API.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.ViewModels
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "proposal")]
    public class ProposalViewModel
    {

        public int ProductCode { get; set; }

        public long ProposalCode { get; set; }

        public string CustomerDocument { get; set; }

        public IFormFile FileUpload { get; set; }
    }
}
