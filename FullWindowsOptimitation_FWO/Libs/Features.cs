using Microsoft.Win32;
using System;

namespace FullWindowsOptimitation_FWO.Libs {
    sealed public class Features {

        static RegistryTools Registry = new RegistryTools();



        public static void WindowsDefender(bool active = true) {
            string path = @"Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender";
            string nameValue = @"DisableAntiSpyware";
            try {
                if (active) {
                    Registry.CreateKeyValue_DWORD(path, nameValue, 0);
                } else {
                    Registry.CreateKeyValue_DWORD(path, nameValue, 1);
                }
                Config.LOG("WindowsDefender", "Activar o Desactivar", true);
            } catch  {
                Config.LOG("WindowsDefender", "Activar o Desactivar", false);
            }
        }

        public static void UAC() {


            
        }



    }
}
