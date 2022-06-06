using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * An AGGREGATE is a cluster of associated objects that we treat 
 * as a unit for the purpose of data changes.Each AGGREGATE has a 
 * root and a boundary.The boundary defines what is inside the 
 * AGGREGATE.The root is a single, specific ENTITY contained 
 * in the AGGREGATE. 
 */

namespace Goal.Domain
{
    public interface IAggregateRoot
    {
    }
}
