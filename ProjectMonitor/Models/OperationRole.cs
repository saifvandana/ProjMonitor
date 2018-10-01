namespace ProjectMonitor.Models
{
    public class OperationRole
    {
        public long Id { get; set; }
        public short RoleId { get; set; }
        public short OperationId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual Operation Operation { get; set; }
        public virtual Role Role { get; set; }
    }
}
