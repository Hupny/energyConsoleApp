using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures.Models
{
    public class BaseModel
    {
        private Guid Id { get; set; }
        private DateTime Creation {  get; set; }
        protected DateTime LastModified { get; set; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
            Creation = DateTime.Now;
        }

        public Guid GetId()
        {
            return Id;
        }

        public DateTime GetCreation()
        {
            return Creation;
        }
    }
}
