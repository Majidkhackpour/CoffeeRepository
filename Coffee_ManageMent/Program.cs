using System;
using System.Windows.Forms;
using AutoMapper;
using PersitenceLayer.Mapper;

namespace Coffee_ManageMent
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var config = new MapperConfiguration(c => { c.AddProfile(new SqlProfile()); });
            Mappings.Default = new Mapper(config);

            Application.Run(new frmMain());
        }
    }
}
