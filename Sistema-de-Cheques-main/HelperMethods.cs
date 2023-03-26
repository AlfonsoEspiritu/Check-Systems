using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Cheques
{
    internal class HelperMethods
    {
        /*
            Metodo usado para dar un formato de "Placeholder" a los TextBox
        */
        public static void placeholderController(TextBox label, string placeholer)
        {
            if (label.Text.Equals(placeholer))
            {
                if (label.Text.ToLower().Contains("contraseña")) label.UseSystemPasswordChar = true;
                label.Text = "";
                label.ForeColor = Color.Black;
                return;
            }
            if (label.Text.Equals(""))
            {
                placeholderDesign(label, placeholer);
                if (label.Text.ToLower().Contains("contraseña")) label.UseSystemPasswordChar = false;
            }
        }

        /*
            Metodo usado para dar un formato de color "Placeholder" a los TextBox
        */
        public static void placeholderDesign(TextBox label, string text)
        {
            label.Text = text;
            label.ForeColor = Color.DimGray;
        }


        /*
            Metodo usado para dar un verificar que una cadena contena solo numeros
        */
        public static bool IsNumeric(string str)
        {
            bool isNumeric = str.All(char.IsDigit);
            return isNumeric;
        }

        public static bool IsMoney(string str)
        {
            decimal quantity = 0;
            if (!decimal.TryParse(str, out quantity))
            {
                return false;
            }

            return true;
        }
    }
}
