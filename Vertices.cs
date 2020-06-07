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

        private int state;
        private string pastV;
        private string data;

        #endregion

        #region Constructores

        public Vertices() { }

        public Vertices(int p_state, string p_pastV, string p_data)
        {
            state = p_state;
            pastV = p_pastV;
            data = p_data;
        }

        #endregion

        #region Métodos

        // Métodos que establecen los datos del vertice.
        public void SetVerticeState(int p_state)
        {
            state = p_state;
        }
        public void SetVerticePastV(string p_pastV)
        {
            pastV = p_pastV;
        }
        public void SetVerticeData(string p_data)
        {
            data = p_data;
        }

        // Métodos que devuelven los datos del vertice.
        public int GetVerticeState()
        {
            return state;
        }
        public string GetVerticePastV()
        {
            return pastV;
        }
        public string GetVerticeData()
        {
            return data;
        }

        #endregion
    }
}
