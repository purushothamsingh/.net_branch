namespace FileUpload.Models
{
    public class FileOnFileSystem: FileModel
    {
        public string FilePath { get; set; }
    }


    public class FileOnDatabaseModel : FileModel
    {
        public byte[] Data { get; set; }
    }


}

