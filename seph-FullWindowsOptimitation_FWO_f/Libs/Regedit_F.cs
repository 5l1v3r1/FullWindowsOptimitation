using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace seph_FullWindowsOptimitation_FWO_f.Libs
{
    public class Regedit_F {
       
        private String mensaje = "";

        public string readRegistry_value(byte key_n, string key_ruta, string key_conteiner, string key_name) {
            
            RegistryKey k;
            // Variable donde se almacena la ruta completa donde se encuentra el key
            string key_ruta_complete ;

            // Ésta condición verificará si es necesario colocar un *\* 
            // en la ruta completa del registro
            if (key_ruta != "") {
                key_ruta_complete = key_ruta + @"\" + key_conteiner;
            } else {
                key_ruta_complete = key_conteiner;
            }

           // k = Registry.CurrentUser.OpenSubKey(key_ruta_complete, true);
            //object obj;
            //obj = k.GetValue(key_name,RegistryValueKind.String);

            //if (obj != null) {

                //ensaje = k.GetValue(key_name,RegistryValueKind.String);
                mensaje = (string) Registry.GetValue(@"HKEY_CURRENT_USER\" + key_ruta_complete, "esta", "Default if TestExpand does not exist.");
                
            //}
 
            return mensaje;
        }
        public string createOrWriteRegistry_conteiner(byte key_n,  string key_ruta, string key_conteiner){

            RegistryKey rConteiner;
            string key_ruta_complete = key_ruta + @"\" + key_conteiner;

            try {

                switch (key_n) {
                    case 1:
                        rConteiner = Registry.ClassesRoot.CreateSubKey(key_ruta_complete);
                        key_ruta = @"HKEY_CLASSES_ROOT\" + key_ruta;
                        break;
                    case 2:
                        rConteiner = Registry.CurrentUser.CreateSubKey(key_ruta_complete);
                        key_ruta = @"HKEY_CURRENT_USER\" + key_ruta;
                        break;
                    case 3:
                        rConteiner = Registry.LocalMachine.CreateSubKey(key_ruta_complete);
                        key_ruta = @"HKEY_LOCAL_MACHINE\" + key_ruta;
                        break;
                    case 4:
                        rConteiner = Registry.Users.CreateSubKey(key_ruta_complete);
                        key_ruta = @"HHKEY_USERS\" + key_ruta;
                        break;
                    case 5:
                        rConteiner = Registry.CurrentConfig.CreateSubKey(key_ruta_complete);
                        key_ruta = @"HKEY_CURRENT_CONFIG\" + key_ruta;
                        break;
                    default:
                        mensaje = "No se pudo crear el contendor, usted debe ingresar un numero entre [1,2,3,4,5]";
                        break;
                }

                //Verifica el *mensaje* por defecto del Switch
                if (mensaje == ""){
                    mensaje = "Se creó el Contenedor: " + key_conteiner + " en: " + key_ruta;
                }
                
            } catch (Exception e ) {
                mensaje = "No se puedo crear el contenedor: "+key_conteiner+":: Error: "+e;

            }
            return mensaje;
        }
        public string createOrWriteRegistry_value(byte key_n, string key_ruta, string key_conteiner, string key_name, string key_value) {

            RegistryKey rValue;
            string key_ruta_complete = key_ruta + @"\" + key_conteiner;

            try {

                switch (key_n) {
                    case 1:
                        rValue = Registry.ClassesRoot.CreateSubKey(key_ruta_complete);
                        rValue.SetValue(key_name, key_value, RegistryValueKind.String);
                        key_ruta = @"HKEY_CLASSES_ROOT\" + key_ruta;
                        break;
                    case 2:
                        rValue = Registry.CurrentUser.CreateSubKey(key_ruta_complete);
                        rValue.SetValue(key_name, key_value, RegistryValueKind.String);
                        key_ruta = @"HKEY_CURRENT_USER\" + key_ruta;
                        break;
                    case 3:
                        rValue = Registry.LocalMachine.CreateSubKey(key_ruta_complete);
                        rValue.SetValue(key_name, key_value, RegistryValueKind.String);
                        key_ruta = @"HKEY_LOCAL_MACHINE\" + key_ruta;
                        break;
                    case 4:
                        rValue = Registry.Users.CreateSubKey(key_ruta_complete);
                        rValue.SetValue(key_name, key_value, RegistryValueKind.String);
                        key_ruta = @"HKEY_CURRENT_USER\" + key_ruta;
                        break;
                    case 5:
                        rValue = Registry.CurrentConfig.CreateSubKey(key_ruta_complete);
                        rValue.SetValue(key_name, key_value, RegistryValueKind.String);
                        key_ruta = @"HKEY_USERS\" + key_ruta;
                        break;
                    default:
                        mensaje = "No se pudo crear el contendor, usted debe ingresar un numero entre [1,2,3,4,5]";
                        break;
                }

                //Verifica el *mensaje* por defecto del Switch
                if (mensaje == "") {
                    mensaje = "Se creó la llave : *" +key_name+ "* con el valor *"+ key_value+"*, en la ruta: "+ key_ruta_complete ;
                }

            } catch (Exception e) {
                mensaje = "No se puedo crear el contenedor: " + key_conteiner + ":: Error: " + e;

            }
          
            return mensaje;
        }
        public string deleteRegistry_conteiner(byte key_n, string key_ruta, string key_conteiner) {
            // Borra toda la carpeta, sin excepciones, incluyendo valores y claves

            RegistryKey k;

            try {

                switch (key_n) {
                    case 1:
                        k = Registry.ClassesRoot.OpenSubKey(key_ruta, true);
                        k.DeleteSubKeyTree(key_conteiner);
                        key_ruta = @"HKEY_CLASSES_ROOT\" + key_ruta;
                        break;
                    case 2:
                        k = Registry.CurrentUser.OpenSubKey(key_ruta, true);
                        k.DeleteSubKeyTree(key_conteiner);
                        key_ruta = @"HKEY_CURRENT_USER\" + key_ruta;
                        break;
                    case 3:
                        k = Registry.LocalMachine.OpenSubKey(key_ruta, true);
                        //k.DeleteSubKeyTree(key_conteiner);
                        key_ruta = @"HKEY_LOCAL_MACHINE\" + key_ruta;
                        break;
                    case 4:
                        k = Registry.Users.OpenSubKey(key_ruta, true);
                        k.DeleteSubKeyTree(key_conteiner);
                        key_ruta = @"HKEY_CURRENT_USER\" + key_ruta;
                        break;
                    case 5:
                        k = Registry.CurrentConfig.OpenSubKey(key_ruta, true);
                        k.DeleteSubKeyTree(key_conteiner);
                        key_ruta = @"HKEY_USERS\" + key_ruta;
                        break;
                    default:
                        mensaje = "No se pudo crear el contendor, usted debe ingresar un numero entre [1,2,3,4,5]";
                        break;
                }

            } catch (Exception e) {

                mensaje = "Hubo un error al eliminar el Key: "+e;
                
            }

            return mensaje;
        }

        public string deleteRegistry_value(byte key_n, string key_ruta, string key_conteiner, string key_name) {
            // Borra toda la carpeta, sin excepciones, incluyendo valores y claves

            RegistryKey k;

            // Variable donde se almacena la ruta completa donde se encuentra el key
            string key_ruta_complete;       

            // Ésta condición verificará si es necesario colocar un *\* 
            // en la ruta completa del registro
            if (key_ruta != "") {
                key_ruta_complete = key_ruta + @"\" + key_conteiner;
            } else {
                key_ruta_complete = key_conteiner;
            }

            try {

                switch (key_n) {
                    case 1:
                        k = Registry.ClassesRoot.OpenSubKey(key_ruta_complete, true);
                        k.DeleteValue(key_name);
                        key_ruta = @"HKEY_CLASSES_ROOT\" + key_ruta;
                        k.Close();
                        break;
                    case 2:
                        k = Registry.CurrentUser.OpenSubKey(key_ruta_complete, true);
                        k.DeleteValue(key_name);
                        key_ruta = @"HKEY_CURRENT_USER\" + key_ruta;
                        k.Close();
                        break;
                    case 3:
                        k = Registry.LocalMachine.OpenSubKey(key_ruta_complete, true);
                        k.DeleteValue(key_name);
                        key_ruta = @"HKEY_LOCAL_MACHINE\" + key_ruta;
                        k.Close();
                        break;
                    case 4:
                        k = Registry.Users.OpenSubKey(key_ruta_complete, true);
                        k.DeleteValue(key_name);
                        key_ruta = @"HKEY_USERS\" + key_ruta;
                        k.Close();
                        break;
                    case 5:
                        k = Registry.CurrentConfig.OpenSubKey(key_ruta_complete, true);
                        k.DeleteValue(key_name);
                        key_ruta = @"HKEY_CURRENT_CONFIG\" + key_ruta;
                        k.Close();
                        break;
                    default:
                        mensaje = "No se pudo crear el contendor, usted debe ingresar un numero entre [1,2,3,4,5]";
                        break;
                }

                

            } catch (Exception e) {

                mensaje = "Hubo un error al eliminar el Key: " + e;

            }

            //Verifica el *mensaje* por defecto del Switch
            if (mensaje == "") {
                mensaje = "Se eleiminó la variable" + key_conteiner + " en: " + key_ruta;
            }

            return mensaje;
        }


    }
}