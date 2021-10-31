using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class MainBL
    {
        public List<MainCLS> ShowData()
        {
            MainDAL oMainDal = new MainDAL();
            return oMainDal.ShowData();
        }

        public int InsertaData(MainCLS oMainCLS)
        {
            MainDAL oMainDal = new MainDAL();
            return oMainDal.InsertaData(oMainCLS);
        }
    }
    
}
