using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionDecryption;
using System.Data;
using System.Data.SqlClient;

namespace EventViewerVisualizer
{
    public class InputModel
    {
        string output_Tran_Code;

        public string Output_Tran_Code
        {
            get { return output_Tran_Code; }
            set { output_Tran_Code = value; }
        }
        string output_Tran_Stream;

        public string Output_Tran_Stream
        {
            get { return output_Tran_Stream; }
            set { output_Tran_Stream = value; }
        }
        string output_Tran_Stream_Order;

        public string Output_Tran_Stream_Order
        {
            get { return output_Tran_Stream_Order; }
            set { output_Tran_Stream_Order = value; }
        }
    }
    public class Utility
    {
        public int insertIntoSimulatorDB(string dbDetails, InputModel inputModel)
        {
            int status = 0;
            string sqlstatement = null;
            DataSet objDataSet = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection con = new SqlConnection(dbDetails))
                {
                    con.Open();
                    sqlstatement = @"insert into Output (Output_Tran_Code,Output_Tran_Stream,Output_Tran_Stream_Order) 
                            values ('" + inputModel.Output_Tran_Code + "', '" + inputModel.Output_Tran_Stream + "','" + inputModel.Output_Tran_Stream_Order + "')";// Check user login details

                    cmd.CommandText = sqlstatement;
                    cmd.Connection = con;

                    //cmd.Parameters.AddWithValue("@Code", dataArray);
                    status = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            return status;
        }
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
                    keyValue.SetValue("CustomFilter", userSetting.DBDetails);
                    keyValue.SetValue("LogName", userSetting.LogName);
                    keyValue.SetValue("Source", userSetting.Source);

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
                    key.SetValue("CustomFilter", userSetting.DBDetails);
                    key.SetValue("LogName", userSetting.LogName);
                    key.SetValue("Source", userSetting.Source);

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
                settingData.DBDetails = key.GetValue("CustomFilter").ToString();
                settingData.LogName = key.GetValue("LogName").ToString();
                settingData.Source = key.GetValue("Source").ToString();
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
        public string DBDetails { get; set; }
        public string LogName { get; set; }
        public string Source { get; set; }
    }
}
