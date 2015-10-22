using System;
using EloBuddy;
using EloBuddy.SDK;  
using EloBuddy.SDK.Events;
using SharpDX;

namespace DevTool
{

    public class Script
    {

        public static int INFO_EXTRA_RANGE = 25;
        public static void log(string log)
        {

            Chat.Print("[Simple DevTool] " + log);
        }

        static void Main(string[] args)
        {
            log("Loaded.");
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        static Vector3 simplifyVec(Vector3 vec)
        {
            vec.X = float.Parse(String.Format("{0:0.0}", vec.X));
            vec.Y = float.Parse(String.Format("{0:0.0}", vec.Y));
            vec.Z = float.Parse(String.Format("{0:0.0}", vec.Z));
            return vec;
        }
        static void Loading_OnLoadingComplete(EventArgs args)
        {
            Game.OnTick += Game_OnTick;
            Drawing.OnEndScene += Drawing_OnEndScene;
        }


        static void Drawing_OnEndScene(EventArgs args)
        {
            Drawing.DrawText(10, 10, System.Drawing.Color.Yellow, "Cursor World Coords: " + simplifyVec(Game.CursorPos));
            Drawing.DrawText(10, 25, System.Drawing.Color.Yellow, "My Hero Coords: " + simplifyVec(Player.Instance.Position));
            
            int xOff = 0;
            foreach (var obj in ObjectManager.Get<AttackableUnit>() )
            {

                if (Game.CursorPos.Distance(obj, true) <= (obj.BoundingRadius + INFO_EXTRA_RANGE) * (obj.BoundingRadius + INFO_EXTRA_RANGE))
                {
                    int yOff = 0;
                    int Y_OFF_INC = 15;
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "Name: "+ obj.Name);
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "Position: " + simplifyVec(obj.Position));
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "NetworkId: " + obj.NetworkId);
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "Type: " + obj.Type);
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "Team: " + obj.Team);
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "BoundingRadius: " + obj.BoundingRadius);
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "BBox.Minimum: " + simplifyVec(obj.BBox.Minimum));
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "BBox.Maximum: " + simplifyVec(obj.BBox.Maximum));
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "Direction: " + simplifyVec(obj.Direction));
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "MaxHealth: " + obj.MaxHealth);
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "AttackShield: " + obj.AttackShield);
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "MagicShield: " + obj.MagicShield);
                    Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "PathfindingCollisionRadius: " + obj.PathfindingCollisionRadius);
               
                    if (obj is Obj_AI_Base)
                    {
                        Obj_AI_Base ai = (Obj_AI_Base)obj;
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "ServerPosition: " + ai.ServerPosition);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "BaseAttackDamage: " + ai.BaseAttackDamage);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "AttackSpeedMod: " + ai.AttackSpeedMod);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "MoveSpeed: " + ai.MoveSpeed);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "TotalAttackDamage: " + ai.TotalAttackDamage);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "TotalMagicalDamage: " + ai.TotalMagicalDamage);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "Armor: " + ai.Armor);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "AttackRange: " + ai.AttackRange);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "CastRange: " + ai.CastRange);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "PercentLocalGoldRewardMod: " + ai.PercentLocalGoldRewardMod);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "PercentHPRegenMod: " + ai.PercentHPRegenMod);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "BaseSkinName: " + ai.BaseSkinName);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "ArmorMaterial: " + obj.ArmorMaterial);
                        Drawing.DrawText(10 + xOff, 40 + (yOff += Y_OFF_INC), System.Drawing.Color.Magenta, "WeaponMaterial: " + obj.WeaponMaterial);
                    }
                    xOff += 300;
                }
            }
        }


        static void Game_OnTick(EventArgs args)
        {

        }
  
    }
}
