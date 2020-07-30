using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CutList.Utility
{
    public class CutListEnums
    {
        public enum PhaseLabel
        {
            //0
            //brown (L1), black (L2), grey (L3) and blue (neutral)
            [Display(Name = "Euro Standard")]
            EuroStandard,
            //1
            //green (L1), red (L2), yellow (L3) and blue (neutral)
            [Display (Name = "Euro Alternative")]
            EuroAlternative,
            //2
            //red (L1), yellow (L2), blue (L3) and black (neutral)
            India,
            //3
            //black (L1), brown (L2), blue (L3) and grey (neutral)
            [Display(Name = "North America")]
            NorthAmerica
        }

        public enum WireColours
        {
            Black,
            Brown,
            Grey,
            Red,
            Blue,
            Green,
            Yellow,
            White,
            [Display(Name = "Yellow and green")]
            YellowGreen,
            [Display(Name = "Blue and white")]
            BlueWhite,
            [Display(Name = "Other... see notes")]
            Other
        }

        public enum AmpValues
        {
            [Display(Name = "(100-149amps)")]
            Onehundred = 100,
            [Display(Name = "(150-199amps)")]
            OneHUndredFifty = 150,
            [Display(Name = "(200-249amps)")]
            TwoHundred = 200,
            [Display(Name = "(250-299amps)")]
            TwoHundredFifty = 250,
            [Display(Name = "(300-349amps)")]
            ThreeHundred = 300,
            [Display(Name = "(350-399amps)")]
            ThreeHundredFifty = 350,
            [Display(Name = "(400-499amps)")]
            FourHundred = 400,
            [Display(Name = "(500-599amps)")]
            Fivehundred = 500,
            [Display(Name = "(600-699amps)")]
            Sixhundred = 600,
            [Display(Name = "(700-799amps)")]
            SevenHundred = 700,
            [Display(Name = "(800-899amps)")]
            Eighthundred = 800,
            [Display(Name = "(900-999amps)")]
            NineHundred = 900,
            [Display(Name = "(1000-1249amps)")]
            OneThousand = 1000,
            [Display(Name = "(1250-1449amps)")]
            OneThousandTwoHundredFifty = 1250,
            [Display(Name = "(1500-1749amps)")]
            OneThousandFiveHundred = 1500,
            [Display(Name = "(1750-1999amps)")]
            OneThousandSevenHundredFifty = 1750,
            [Display(Name = "(2000-2499amps)")]
            TwoThousand = 2000,
            [Display(Name = "(2500-2999amps)")]
            TwoThousandFiveHundred = 2500,
            [Display(Name = "(3000-3499amps)")]
            ThreeThousand = 3000,
            [Display(Name = "(3500-3999amps)")]
            ThreeThousandFiveHundred = 3500,
            [Display(Name = "(4000-4499amps)")]
            FourThousand = 4000,
            [Display(Name = "(4500-4999amps)")]
            FourThosandFiveHundred = 4500,
            [Display(Name = "(5000-5999amps)")]
            FiveThousand = 5000
        }

        public enum Material
        {
            Copper,
            Aluminium,
            Iron
        }

        public enum Stack
        {
            Single,
            Double
        }

        public enum CoverColour
        {
            Blue,
            Red,
            Green,
            Yellow,
            [Display(Name = "Other... see notes")]
            Other
        }
    }
}
