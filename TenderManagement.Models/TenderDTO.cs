namespace TenderManagement.Models
{
    public class TenderDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public UserDTO? User { get; set; }
    }
}