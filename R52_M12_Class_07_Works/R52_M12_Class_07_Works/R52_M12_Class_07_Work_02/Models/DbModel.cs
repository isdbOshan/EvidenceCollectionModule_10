using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R52_M12_Class_07_Work_02.Models
{
    public enum Format { PDF = 1, Print, DVD }
    public class Publisher
    {
        public int PublisherId { get; set; }
        [Required, StringLength(50)]
        public string PublisherName { get; set; } = default!;
        [Required, StringLength(150)]
        public string Address { get; set; } = default!;
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal CoverPrice { get; set; }
        [Required, EnumDataType(typeof(Format))]
        public Format Format { get; set; }
        [Required, ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public virtual Publisher? Publisher { get; set; } = default!;
    }
    public class PublisherDbContext : DbContext
    {
        public PublisherDbContext(DbContextOptions<PublisherDbContext> options) : base(options) { }
        public DbSet<Publisher> Publishers { get; set; } = default!;
        public DbSet<Book> Books { get; set; } = default!;
    }
}
