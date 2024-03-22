namespace nikhilTask.services
{
    public class FileService:IFile
    {
        readonly private IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public FileService() { }


        public string SaveFile(IFormFile file)
        {
            try
            {

                String fileName = file.FileName.Insert(0, DateTime.Now.Ticks.ToString());
                String absolutePath = getAbsolutePath(fileName);
                using (Stream writer = new FileStream(absolutePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                     file.CopyToAsync(writer);
                }
                return fileName;
            }
            catch(Exception ex) { 
                Console.WriteLine(ex.ToString());
                return "";
            }
        }

        public String DeleteFile(String file)
        {
            String absolutePath = getAbsolutePath(file);
            if(File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }
            return "file deleted";
        }

       public String getAbsolutePath(String file)
        {

            return Path.Combine(_env.WebRootPath, "thumbnails", file);
        }
    }
}
