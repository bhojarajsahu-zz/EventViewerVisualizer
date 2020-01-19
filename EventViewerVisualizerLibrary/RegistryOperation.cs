using EncryptionDecryption;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventViewerVisualizerLibrary
{
    public static class RegistryOperation
    {
        public static void updateRegistryValue(SettingData userSetting)
        {
            try
            {
                RegistryKey keyValue = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\EventViewerVisualizer", true);
                if (keyValue != null)
                {
                    keyValue.SetValue("SystemName", Encryption.Encrypt(userSetting.SystemName.ToString(), "EventViewerVisualizer"));
                    keyValue.SetValue("TXNPath", Encryption.Encrypt(userSetting.TXNPath, "EventViewerVisualizer"));
                    keyValue.SetValue("TellerFilter", userSetting.UserFilter);
                    keyValue.SetValue("TXNFilter", userSetting.TXNFilter);
                    keyValue.SetValue("CustomFilter", userSetting.CustomFilter);
                    //key.SetValue("DecryptPassword", passwordDecrypt(passwordEncrypt("abc@gmail.com", "ProgrammingUtility"), "ProgrammingUtility"));
                    keyValue.Close();
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\EventViewerVisualizer");
                    key.SetValue("SystemName", Encryption.Encrypt(userSetting.SystemName.ToString(), "EventViewerVisualizer"));
                    key.SetValue("TXNPath", Encryption.Encrypt(userSetting.TXNPath, "EventViewerVisualizer"));
                    key.SetValue("TellerFilter", userSetting.UserFilter);
                    key.SetValue("TXNFilter", userSetting.TXNFilter);
                    key.SetValue("CustomFilter", userSetting.CustomFilter);
                    //key.SetValue("DecryptPassword", passwordDecrypt(passwordEncrypt("abc@gmail.com", "ProgrammingUtility"), "ProgrammingUtility"));
                    key.Close();
                }
            }
            catch (Exception ex) { }
        }
        public static bool checkRegistryValue()
        {
            bool status = false;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\EventViewerVisualizer");
            if (key != null)
            {

                if (key != null)
                {
                    if (!string.IsNullOrEmpty(key.GetValue("TXNPath").ToString()))
                        status = true;
                    else
                        status = false;
                }
                else
                    status = false;
                key.Close();
            }
            else
                status = false;
            return status;
        }
        public static SettingData getSettingDetails()
        {
            SettingData settingData = new SettingData();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\EventViewerVisualizer");
            if (key != null)
            {
                settingData.SystemName = Decryption.Decrypt(key.GetValue("SystemName").ToString(), "EventViewerVisualizer");
                settingData.TXNPath = Decryption.Decrypt(key.GetValue("TXNPath").ToString(), "EventViewerVisualizer");
                settingData.UserFilter = key.GetValue("TellerFilter").ToString();
                settingData.TXNFilter = key.GetValue("TXNFilter").ToString();
                settingData.CustomFilter = key.GetValue("CustomFilter").ToString();
                key.Close();
            }
            else
                settingData = null;
            return settingData;
        }
        public static string getSystemName()
        {
            string systemName = string.Empty;
            systemName = Environment.MachineName;
            return systemName;
        }
    }
    public class SettingData
    {
        public string SystemName { get; set; }
        public string TXNPath { get; set; }
        public string UserFilter { get; set; }
        public string TXNFilter { get; set; }
        public string CustomFilter { get; set; }
    }
}
