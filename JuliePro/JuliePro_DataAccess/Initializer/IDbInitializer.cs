using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBooks_DataAccess.Initializer
{
  public interface IDbInitializer
  {
    
    Task Initialize();
  }
}
