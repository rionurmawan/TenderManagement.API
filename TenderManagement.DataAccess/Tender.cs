using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenderManagement.DataAccess
{
    public class Tender
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

    }
}
