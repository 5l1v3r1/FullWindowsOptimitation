using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullWindowsOptimitation_FWO {
    public sealed class Config {

        //Advanced Developer // Debug
        public const bool MODE_DEBUG = true;                                                    // Modo desarrollador
        const string LOG_NAME = "FWO log.txt";
        const string PATH_LOG = @"O:\" + LOG_NAME;                                                  // C:\Users\sebas\3D Objects

        public static void LOG(string process, string texto, bool result, string path = PATH_LOG) {
            DateTime date = DateTime.Now;   // Obtiene fecha exacta
            if (MODE_DEBUG) {
                string resultS = string.Empty;
                if (result) { resultS = "Exito"; } else { resultS = "Error"; }
                File.AppendAllText(path, $"|{date}| [{process}] {texto} |{resultS}| \n");
            }
        }


    }
}
