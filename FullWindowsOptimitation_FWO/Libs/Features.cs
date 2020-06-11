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

        public static void UAC(bool active = true) {
            string path = @"Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
            try {
                if (active) {
                    Registry.CreateKeyValue_DWORD(path, "EnableLUA", 0);
                    Registry.CreateKeyValue_DWORD(path, "FilterAdministratorToken", 0);
                    Registry.CreateKeyValue_DWORD(path, "EnableUIADesktopToggle", 0);
                    Registry.CreateKeyValue_DWORD(path, "ConsentPromptBehaviorAdmin", 0);
                    Registry.CreateKeyValue_DWORD(path, "ConsentPromptBehaviorUser", 0);
                    Registry.CreateKeyValue_DWORD(path, "EnableInstallerDetection", 0);
                    Registry.CreateKeyValue_DWORD(path, "ValidateAdminCodeSignatures", 0);
                    Registry.CreateKeyValue_DWORD(path, "EnableSecureUIAPaths", 0);
                    Registry.CreateKeyValue_DWORD(path, "PromptOnSecureDesktop", 0);
                } else {
                    Registry.CreateKeyValue_DWORD(path, "EnableLUA", 1);
                    Registry.CreateKeyValue_DWORD(path, "FilterAdministratorToken", 1);
                    Registry.CreateKeyValue_DWORD(path, "EnableUIADesktopToggle", 1);
                    Registry.CreateKeyValue_DWORD(path, "ConsentPromptBehaviorAdmin", 1);
                    Registry.CreateKeyValue_DWORD(path, "ConsentPromptBehaviorUser", 1);
                    Registry.CreateKeyValue_DWORD(path, "EnableInstallerDetection", 1);
                    Registry.CreateKeyValue_DWORD(path, "ValidateAdminCodeSignatures", 1);
                    Registry.CreateKeyValue_DWORD(path, "EnableSecureUIAPaths", 1);
                    Registry.CreateKeyValue_DWORD(path, "PromptOnSecureDesktop", 1);
                }
                Config.LOG("WindowsDefender", "Activar o Desactivar", true);
            } catch {
                Config.LOG("WindowsDefender", "Activar o Desactivar", false);
            }
        }

        public static void dsfsd() { 
        
        }



    }
}
