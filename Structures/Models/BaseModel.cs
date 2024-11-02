namespace Structures.Models
{
    public class BaseModel
    {
        protected Guid Id { get; private set; }
        public DateTime Creation {  get; private set; }
        public DateTime LastModified { get; protected set; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
            Creation = DateTime.Now;
        }

    }
}
