namespace SolarEnergy.Profiles
{
    public class UploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;



        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string SaveFile(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string uploadDirection = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDirection, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    if(string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
                    {
                        _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                }

            }
            return fileName;
        }
    }
}
