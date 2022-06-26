namespace TenderManagement.Models
{
    public class CreateTenderDTO
    {
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }        
    }
}