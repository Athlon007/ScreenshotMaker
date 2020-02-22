using MSCLoader;
using UnityEngine;
using System.IO;
using System;

namespace ScreenshotMaker
{
    public class ScreenshotMaker : Mod
    {
        public override string ID => "ScreenshotMaker"; //Your mod ID (unique)
        public override string Name => "ScreenshotMaker"; //You mod name
        public override string Author => "Athlon"; //Your Username
        public override string Version => "1.0"; //Version

        // Set this to true if you will be load custom assets from Assets folder.
        // This will create subfolder in Assets folder for your mod.
        public override bool UseAssetsFolder => false;

        public override bool LoadInMenu => true;

        Keybind takeScreenshot = new Keybind("takeScreenshot", "Take Screenshot", KeyCode.F10);

        public override void OnMenuLoad()
        {
            Keybind.Add(this, takeScreenshot);
        }

        public override void Update()
        {
            if (takeScreenshot.IsDown())
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Screenshot.png";
                if (File.Exists(path))
                    File.Delete(path);
                Application.CaptureScreenshot(path, int.Parse(scale.GetValue().ToString()));
                ModConsole.Print("Screenshot Saved! (It may take a while for it to appear tho...)");
                ModConsole.Print("You can find the screenshot on your desktop.");
            }
        }

        Settings scale = new Settings("scale", "Scale (ex. typing '4' will take the screenshot 4x the size of your screen)", 1);

        public override void ModSettings()
        {
            // All settings should be created here.
            // DO NOT put anything else here that settings.
            Settings.AddTextBox(this, scale, "1");
        }
    }
}
