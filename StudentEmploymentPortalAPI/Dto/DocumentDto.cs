namespace StudentEmploymentPortalAPI.Dto
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string FilePath { get; set; }
    }
}
