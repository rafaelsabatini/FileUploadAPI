using FileUpload.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace FileUpload.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProposalController: ControllerBase
    {



        [RequestSizeLimit(100000000)]
        [HttpPost("file-upload")]
        public async Task<ActionResult<string>> FileUpload (IFormFile file)
        {
            var fileName = await SaveFile(file);

            return Ok(fileName);
        }

        [RequestSizeLimit(100000000)]
        [HttpPost]
        public async Task<ActionResult<string>> CreateProposal(ProposalViewModel viewModel)
        {

            var fileName = await SaveFile(viewModel.FileUpload);

            return Ok(fileName);

        }

        private async Task<string> SaveFile (IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var path = Path.Combine(Directory.GetCurrentDirectory(), @$"files\{fileName}");

            using ( var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;

        }



        
    }
}
