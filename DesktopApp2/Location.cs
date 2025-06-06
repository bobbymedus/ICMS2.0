using System.Windows.Forms;

namespace DesktopApp2
{
    public partial class FormICMSMain
    {
        public static  class PlantLocation
        {
            public static string city;
            public static bool CTLpaper;
            public static bool RunSheetPO;
            public static bool runDebugMode = false;
        }
        public static class AdderPriceTypes
        {
            public static int LBS = 0;
            public static int SQFT = 1;
            public static int LINFT = 2;
        }
        public static class LabelPrinters
        {
            public static string tagPrinter;
            public static bool zebraTagPrinter;
            public static string shippingPrinter;
            public static bool zebraShipTagPrinter;
            public static bool printShipLabels;
            public static string OverideTag;
            public static bool OverideZebraTag;
            public static string OverideShipTag;
            public static bool OverideZebraShip;
            public static bool OveridePrintShipLabels;
            public static bool useOveride;
        }
        public static class MachineDefaults
        {
            public static string ClClSameDefaultFinish;
            public static string SSSmDefaultFinish;
            public static string scrapUnit;
            public static int HoldDown;
            public static string ReportDrive;
        }
    }
}
