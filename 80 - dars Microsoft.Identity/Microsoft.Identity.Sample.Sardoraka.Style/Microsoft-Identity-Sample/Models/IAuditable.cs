namespace Microsoft_Identity_Sample.Models
{
    public interface IAuditable
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifedDate { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
