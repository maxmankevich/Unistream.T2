namespace Unistream.T2.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.OperationDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
    }
}
