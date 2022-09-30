using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GTA;
using GTA.Math;
using GTA.Native;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace GodModGTAV
{
    public class GodMod : Script
    {
        public bool onoff = false;
        public Player player = new Player(0);
        public Keys userKey;
        public ScriptSettings config;
        public GodMod() 
        {
            LoadIniFile("scripts//GodMod.ini");
            Tick += onTick; 
            KeyUp+= onKeyUp;
            KeyDown += onKeyDown;
    }

        public void LoadIniFile(string IniName)
        {
            try
            {
                config = ScriptSettings.Load(IniName);
                userKey = config.GetValue<Keys>("Setup", "TurnOn", userKey);
            }
            catch (Exception e)
            {
                UI.Notify($"Error : Something wrong with {IniName} File or is not exist.");
            }
        }

        private void onTick(object sender, EventArgs e)
        {
           
            if (onoff)
            {

                if (player.IsAlive)
                {
                    if (player.Character.Health < 1000)
                    {
                        player.Character.Health = 1000;
                    }
                }
            }

        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {

        }
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == userKey)
            {
                if(onoff == false)
                {
                    onoff = true;
                    player.Character.IsExplosionProof = true;
                    player.Character.IsFireProof = true;
                    player.Character.IsMeleeProof = true;
                    player.Character.IsBulletProof = true;
                    player.Character.IsCollisionProof = true;
                    UI.Notify("God mode is enable");

                }
                else
                {
                    onoff = false;
                    UI.Notify("God mode is Disable");
                    player.Character.IsExplosionProof = false;
                    player.Character.IsFireProof = false;
                    player.Character.IsMeleeProof = false;
                    player.Character.IsBulletProof = false;
                    player.Character.IsCollisionProof = false;
                }
            }


        }
    }
}
