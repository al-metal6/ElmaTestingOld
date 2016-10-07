using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Managers
{
    public interface IHistoryManager
    {
        void Add(History item);
        IEnumerable<History> List();
    }
}
