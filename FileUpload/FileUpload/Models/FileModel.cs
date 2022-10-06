using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FileUpload.Models
{
    public abstract class FileModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public string UploadedBy { get; set; } = "raj";
        public DateTime? CreatedOn { get; set; }
    }
}
