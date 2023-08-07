using CSASS.ASSA;
using System.Drawing;

namespace CSASS.Common
{
    public class C_IO
    {
        public C_IO() { }

        public static ASS_IO FromSSAtoASS(SSA_IO ssa)
        {
            ASS_IO ass = new ASS_IO();

            // Infos
            ass.Infos.Title = ssa.Infos.Title;
            ass.Infos.OriginalScript = ssa.Infos.OriginalScript;
            ass.Infos.OriginalTranslation = ssa.Infos.OriginalTranslation;
            ass.Infos.OriginalEditing = ssa.Infos.OriginalEditing;
            ass.Infos.OriginalTiming = ssa.Infos.OriginalTiming;
            ass.Infos.OriginalScriptChecking = ssa.Infos.OriginalScriptChecking;
            ass.Infos.PlayResX = ssa.Infos.PlayResX;
            ass.Infos.PlayResY = ssa.Infos.PlayResY;
            ass.Infos.PlayDepth = ssa.Infos.PlayDepth;
            ass.Infos.Wav = ssa.Infos.Wav;
            ass.Infos.LastWav = ssa.Infos.LastWav;
            ass.Infos.Timer = ssa.Infos.Timer;

            // Styles
            foreach(SSA_Style ssty in ssa.Styles)
            {
#pragma warning disable IDE0017 // Simplifier l'initialisation des objets
                ASS_Style asty = new ASS_Style();
#pragma warning restore IDE0017 // Simplifier l'initialisation des objets
                asty.Name = ssty.Name;
                asty.Fontname = ssty.Fontname;
                asty.Fontsize = ssty.Fontsize;
                asty.TextColor.CColor.Color = Color.FromArgb(ssty.AlphaLevel, ssty.PrimaryColor.CColor.Color);
                asty.KaraokeColor.CColor.Color = Color.FromArgb(ssty.AlphaLevel, ssty.SecondaryColor.CColor.Color);
                asty.OutlineColor.CColor.Color = Color.FromArgb(ssty.AlphaLevel, ssty.BackColor.CColor.Color);
                asty.ShadowColor.CColor.Color = Color.FromArgb(ssty.AlphaLevel, ssty.BackColor.CColor.Color);
                asty.Bold = ssty.Bold;
                asty.Italic = ssty.Italic;
                asty.BorderStyle = ssty.BorderStyle;
                asty.Outline = ssty.Outline;
                asty.Shadow = ssty.Shadow;
                
                switch (ssty.Alignment) // Alignment
                {
                    case 1: asty.Alignment = 1; break; // 1 => 1
                    case 2: asty.Alignment = 2; break; // 2 => 2
                    case 3: asty.Alignment = 3; break; // 3 => 3
                    case 5: asty.Alignment = 7; break; // 5 => 7
                    case 6: asty.Alignment = 8; break; // 6 => 8
                    case 7: asty.Alignment = 9; break; // 7 => 9
                    case 9: asty.Alignment = 4; break; // 9 => 4
                    case 10: asty.Alignment = 5; break; // 10 => 5
                    case 11: asty.Alignment = 6; break; // 11 => 6
                }

                asty.MarginL = ssty.MarginL;
                asty.MarginR = ssty.MarginR;
                asty.MarginV = ssty.MarginV;
                asty.Encoding = ssty.Encoding;
            }

            // Events
            foreach(SSA_Event sev in ssa.Events)
            {
                if(sev.Event.Type != C_Event.EventType.Dialogue ||
                    sev.Event.Type != C_Event.EventType.Comment) continue;

                ASS_Event ev = new ASS_Event();
                ev.Event.Type = sev.Event.Type;
                ev.Event.Layer = 0;
                ev.Event.Start = sev.Event.Start;
                ev.Event.End = sev.Event.End;
                ev.Event.Style = sev.Event.Style;
                ev.Event.Name = sev.Event.Name;
                ev.Event.MarginL = sev.Event.MarginL;
                ev.Event.MarginR = sev.Event.MarginR;
                ev.Event.MarginV = sev.Event.MarginV;
                ev.Event.Effect = sev.Event.Effect;
                ev.Event.Text = sev.Event.Text;

                ass.Events.Add(ev);
                
            }

            return ass;
        }

        public static SSA_IO FromASStoSSA(ASS_IO ass)
        {
            SSA_IO ssa = new SSA_IO();

            // Infos
            ssa.Infos.Title = ass.Infos.Title;
            ssa.Infos.OriginalScript = ass.Infos.OriginalScript;
            ssa.Infos.OriginalTranslation = ass.Infos.OriginalTranslation;
            ssa.Infos.OriginalEditing = ass.Infos.OriginalEditing;
            ssa.Infos.OriginalTiming = ass.Infos.OriginalTiming;
            ssa.Infos.OriginalScriptChecking = ass.Infos.OriginalScriptChecking;
            ssa.Infos.PlayResX = ass.Infos.PlayResX;
            ssa.Infos.PlayResY = ass.Infos.PlayResY;
            ssa.Infos.PlayDepth = ass.Infos.PlayDepth;
            ssa.Infos.Wav = ass.Infos.Wav;
            ssa.Infos.LastWav = ass.Infos.LastWav;
            ssa.Infos.Timer = ass.Infos.Timer;

            // Styles
            foreach (ASS_Style asty in ass.Styles)
            {
#pragma warning disable IDE0017 // Simplifier l'initialisation des objets
                SSA_Style ssty = new SSA_Style();
#pragma warning restore IDE0017 // Simplifier l'initialisation des objets
                ssty.Name = asty.Name;
                ssty.Fontname = asty.Fontname;
                ssty.Fontsize = asty.Fontsize;
                ssty.AlphaLevel = asty.TextColor.CColor.Color.A;
                ssty.PrimaryColor.CColor.Color = asty.TextColor.CColor.Color;
                ssty.SecondaryColor.CColor.Color = Color.Yellow;
                ssty.TertiaryColor.CColor.Color = Color.Cyan;
                ssty.BackColor.CColor.Color = asty.OutlineColor.CColor.Color;
                ssty.Bold = asty.Bold;
                ssty.Italic = asty.Italic;
                ssty.BorderStyle = asty.BorderStyle;
                ssty.Outline = asty.Outline;
                ssty.Shadow = asty.Shadow;

                switch (ssty.Alignment) // Alignment
                {
                    case 1: ssty.Alignment = 1; break; // 1 <= 1
                    case 2: ssty.Alignment = 2; break; // 2 <= 2
                    case 3: ssty.Alignment = 3; break; // 3 <= 3
                    case 4: ssty.Alignment = 9; break; // 9 <= 4
                    case 5: ssty.Alignment = 10; break; // 10 <= 5
                    case 6: ssty.Alignment = 11; break; // 11 <= 6
                    case 7: ssty.Alignment = 5; break; // 5 <= 7
                    case 8: ssty.Alignment = 6; break; // 6 <= 8
                    case 9: ssty.Alignment = 7; break; // 7 <= 9
                }

                ssty.MarginL = asty.MarginL;
                ssty.MarginR = asty.MarginR;
                ssty.MarginV = asty.MarginV;
                ssty.Encoding = asty.Encoding;
            }

            // Events
            foreach (ASS_Event aev in ass.Events)
            {
                SSA_Event ev = new SSA_Event();
                ev.Event.Type = aev.Event.Type;
                ev.Event.Marked = false;
                ev.Event.Start = aev.Event.Start;
                ev.Event.End = aev.Event.End;
                ev.Event.Style = aev.Event.Style;
                ev.Event.Name = aev.Event.Name;
                ev.Event.MarginL = aev.Event.MarginL;
                ev.Event.MarginR = aev.Event.MarginR;
                ev.Event.MarginV = aev.Event.MarginV;
                ev.Event.Effect = aev.Event.Effect;
                ev.Event.Text = aev.Event.Text;

                ssa.Events.Add(ev);

            }

            return ssa;
        }
    }
}
