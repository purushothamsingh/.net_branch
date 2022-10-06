namespace FileUpload.Models
{
    public class MultipleBinding
    {
      
            public List<FileOnFileSystem> FileOnFileSystems { get; set; }
            public List<FileOnDatabaseModel> FilesOnDatabase { get; set; }
        
    }
}
