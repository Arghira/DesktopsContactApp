using System;
using System.Windows;

namespace DesktopsContactApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string dataBaseName = "Contacts.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string dataBasePath = System.IO.Path.Combine(folderPath, dataBaseName);
    }
}
