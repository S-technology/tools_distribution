using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using u_ierarch;
using u_functions;

namespace PM
{
    /// <summary>
    /// настройки проекта РМ
    /// </summary>
    public class PM_settings : u_settings
    {
        public PM_settings() { }

        /// <summary>
        /// получить новое значение для некого параметра
        /// </summary>
        /// <param name="param_name">имя параметра</param>
        /// <param name="pred_value">предыдущее значение</param>
        /// <param name="new_value">новое значение</param>
        public override object Set_param_value(string param_name, object pred_value)
        {
            object result = null;

            if (param_name.same_text("proj_check_AddLimit"))
            {
                result = false;
            }

            return result;
        }

    }
}
