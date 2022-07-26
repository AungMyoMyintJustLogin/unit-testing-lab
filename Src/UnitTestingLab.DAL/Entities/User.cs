namespace UnitTestingLab.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
