using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Repositori
{
    public interface Interface
    {
        Task<Curs> GetCurs();

        Task<Curs> GetCurs(DateTime? date);//(? - значит можно передовать нулл)
    }
}
