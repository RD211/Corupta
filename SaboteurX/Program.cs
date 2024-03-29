﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaboteurX
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
            MusicPlayerHelper.InitAllPlayers();
            MusicPlayerHelper.PlayThemeSong();
            GlobalSettings.GetFromFile();
            Application.Run(new StartScreen());
        }
    }
}
