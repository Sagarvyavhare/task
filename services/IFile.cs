namespace nikhilTask.services
{
    public interface IFile
    {
       String SaveFile(IFormFile file);

        String DeleteFile(String file);
        
    }
}
