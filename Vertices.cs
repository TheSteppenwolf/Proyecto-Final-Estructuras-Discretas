using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Estructuras_Discretas
{
    class Vertices
    {
        #region Variables

        public int State { get; set; }
        public string PastV { get; set; }
        public string Data { get; set; }

        #endregion

        #region Constructores

        public Vertices() { State = 1; }        

        #endregion
    }
}
