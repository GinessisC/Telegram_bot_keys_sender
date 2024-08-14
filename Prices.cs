using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
namespace TestForTutorial
{
    /// <summary>
    /// price structure: Key(duration) = left; Value(price) = right
    /// </summary>
    public static class Prices
    {
        //public static int amountOfGoods = 1;
        
        public static Dictionary<string, string> DaysPricePairsUki = new Dictionary<string, string>()
        {
            { "1 день", "80"},
            { "3 день", "190"},
            { "7 дней", "381"},
            { "30 дней ", "760"},
            { "60 дней ", "1100"},
        };

        public static Dictionary<string, string> DaysPricePairsDESERTSTORM = new Dictionary<string, string>()
        {
            { "1 день", "90"},
            { "3 день", "250"},
            { "7 дней", "465"},
            { "30 дней ", "1120"},
        };

        public static Dictionary<string, string> DaysPricePairsZolo = new Dictionary<string, string>()
        {
            { "1 день", "80"},
            { "3 дня", "180"},
            { "7 дней", "375"},
            { "14 дней", "400"},
            { "30 дней ", "700"},
            { "60 дней", "900"},
        };

        public static Dictionary<string, string> DaysPricePairsNerohole = new Dictionary<string, string>()
        {
//            1 день 100
//7 дней 500
//30 дней 1100
            { "1 день", "100"},
            { "7 дней", "500"},
            { "30 дней", "1180"}
        };
        public static Dictionary<string, string> DaysPricePairsSHIELD = new Dictionary<string, string>()
        {

            { "1 день", "90"},
            { "7 дней", "400"},
            { "30 дней", "800"}
        };

        public static Dictionary<string, string> DaysPricePairsKINGMOD = new Dictionary<string, string>()
        {
            { "1 день", "120"},
            { "7 дней", "500"},
            { "30 дней", "1100"}
        };

        public static Dictionary<string, string> DaysPricePairsFITEMOD = new Dictionary<string, string>()
        {
            { "1 день", "75"},
            { "3 дня", "150"},
            { "7 дней", "260"},
            { "14 дней", "400"},
            { "30 дней ", "550"},
            { "60 дней", "700"},
        };
        

        public static Dictionary<string, string> DaysPricePairsOWMMOD = new Dictionary<string, string>()
        {
            { "1 день", "80"},
            { "3 дня", "190"},
            { "7 дней", "380"},
            { "14 дней", "500"},
            { "30 дней ", "760"},
            { "60 дней", "1100"},
        };

        

        
        ///////////////////////////////   ANDROID ROOT   /////////////////////////////////////


        public static Dictionary<string, string> DaysPricePairsRootZolo = new Dictionary<string, string>()
        {
            { "1 день", "80"},
            { "3 дня", "180"},
            { "7 дней", "375"},
            { "14 дней", "400"},
            { "30 дней ", "700"},
            { "60 дней", "900"},
        };

        

        public static Dictionary<string, string> DaysPricePairsRootXShooter = new Dictionary<string, string>()
        {
            { "1 день", "160"},
            { "7 дней", "480"},
            { "30 дней ", "1000"},

        };

        ///////////////////////////////   IOS   /////////////////////////////////////



        public static Dictionary<string, string> DaysPricePairsVn = new Dictionary<string, string>()
        {

            { "1 день", "200"},
            { "7 дней", "700"},
            { "30 дней ", "1400"},

        };

        public static Dictionary<string, string> DaysPricePairsIOSStar = new Dictionary<string, string>()
        {
            { "1 день", "130"},
            { "7 дней", "450"},
            { "30 дней ", "900"},

        };


        ///////////////////////////////   PC   /////////////////////////////////////


        public static Dictionary<string, string> DaysPricePairsPCANUBIS = new Dictionary<string, string>()
        {


            { "1 день", "220"},
            { "7 дней", "650"},
            { "30 дней ", "1600"},

        };





        ////////////////////////////////////////////////////    FOR RUBS    ////////////////////////////////////////////////////////////////



        public static Dictionary<string, string> DaysPricePairsDESERTSTORM_rus = new Dictionary<string, string>()
        {
            { "1 день", "220"},
            { "3 день", "500"},
            { "7 дней", "1000"},
            { "30 дней ", "2400"},
        };

        public static Dictionary<string, string> DaysPricePairsUki_rus = new Dictionary<string, string>()
        {
            { "1 день", "190"},
            { "3 день", "450"},
            { "7 дней", "900"},
            { "30 дней ", "1800"},
            { "60 дней ", "2600"},
        };


        public static Dictionary<string, string> DaysPricePairsZolo_rus = new Dictionary<string, string>() 
        {
            { "1 день", "190"},
            { "3 дня", "430"},
            { "7 дней", "800"},
            { "14 дней", "1000"},
            { "30 дней ", "1400"},
            { "60 дней", "1800"},
        };

        public static Dictionary<string, string> DaysPricePairsNerohole_rus = new Dictionary<string, string>()
        {
            { "1 день", "270"},
            { "7 дней", "1200"},
            { "30 дней", "2400"}
        };
        public static Dictionary<string, string> DaysPricePairsSHIELD_rus = new Dictionary<string, string>()
        {
            

            { "1 день", "260"},
            { "7 дней", "900"},
            { "30 дней", "1900"}
        };

        public static Dictionary<string, string> DaysPricePairsKINGMOD_rus = new Dictionary<string, string>()
        {
            
            { "1 день", "280"},
            { "7 дней", "1000"},
            { "30 дней", "2400"}
        };

        public static Dictionary<string, string> DaysPricePairsFITEMOD_rus = new Dictionary<string, string>()
        {
            { "1 день", "150"},
            { "3 дня", "390"},
            { "7 дней", "500"},
            { "14 дней", "900"},
            { "30 дней ", "1200"},
            { "60 дней", "1500"},
        };
        

        public static Dictionary<string, string> DaysPricePairsOWMMOD_rus = new Dictionary<string, string>()
        {
            { "1 день", "190"},
            { "3 дня", "450"},
            { "7 дней", "900"},
            { "14 дней", "1200"},
            { "30 дней ", "1800"},
            { "60 дней", "2600"},
        };

        

        
        ///////////////////////////////   ANDROID ROOT   /////////////////////////////////////


        public static Dictionary<string, string> DaysPricePairsRootZolo_rus = new Dictionary<string, string>()
        {
            { "1 день", "80"},
            { "3 дня", "180"},
            { "7 дней", "375"},
            { "14 дней", "400"},
            { "30 дней ", "700"},
            { "60 дней", "900"},
        };

        

        public static Dictionary<string, string> DaysPricePairsRootXShooter_rus = new Dictionary<string, string>()
        {
            { "1 день", "160"},
            { "7 дней", "480"},
            { "30 дней ", "1000"},

        };

        ///////////////////////////////   IOS   /////////////////////////////////////



        public static Dictionary<string, string> DaysPricePairsVn_rus = new Dictionary<string, string>()
        {
            { "1 день", "400"},
            { "7 дней", "1500"},
            { "30 дней ", "2700"},

        };

        public static Dictionary<string, string> DaysPricePairsIOSStar_rus = new Dictionary<string, string>()
        {

            

            { "1 день", "300"},
            { "7 дней", "1000"},
            { "30 дней ", "2000"},

        };


        ///////////////////////////////   PC   /////////////////////////////////////


        public static Dictionary<string, string> DaysPricePairsPCANUBIS_rus = new Dictionary<string, string>()
        {
            { "1 день", "450"},
            { "7 дней", "1500"},
            { "30 дней ", "3500"},

        };
        ////////////////////////////////////////////////////    NEW POINT: FOR FOUNDERS    ////////////////////////////////////////////////////////////////


        
        public static Dictionary<string, string> DaysPricePairsVNForSponsors = new Dictionary<string, string>()
        {
            { "1", "0,7"},
            { "7", "3,5"},
            { "30 ", "6,5"},
        };
        public static Dictionary<string, string> DaysPricePairsZoloForSponsors = new Dictionary<string, string>()
        {
            { "1", "0,6"},
            { "3", "1,5"},
            { "7", "2,35"},
            { "14", "3,3"},
            { "30", "5,7"},
            { "60", "7,5"},

        };

        public static Dictionary<string, string> DaysPricePairsNeroholeForSponsors = new Dictionary<string, string>()
        {
            //duration : price in $
            { "1", "1,3"},
            { "3", "7"},
            { "30", "16"},
        };

        public static Dictionary<string, string> DaysPricePairsKINGMODForSponsors = new Dictionary<string, string>()
        {
            { "1", "1,3"},
            { "3", "7"},
            { "30", "16"},
        };

        public static Dictionary<string, string> DaysPricePairsOWMMODForSponsors = new Dictionary<string, string>()
        {
            { "1", "0,9"},
            { "3", "1,8"},
            { "7", "3,5"},
            { "30", "6"},
        };

        public static Dictionary<string, string> DaysPricePairsHassanForSponsors = new Dictionary<string, string>()
        {
            { "1", "0,9"},
            { "3", "1,8"},
            { "7", "3,5"},
            { "30", "6"},
        };

        public static Dictionary<string, string> DaysPricePairsUkiForSponsors = new Dictionary<string, string>()
        {
            { "1", "1" },
            { "3", "2" },
            { "7", "4" },
            { "14", "6" },
            { "30", "8" },
        };

        public static Dictionary<string, string> DaysPricePairsHarlyModForSponsors = new Dictionary<string, string>()
        {
            { "1", "0,9"},
            { "3", "1,8"},
            { "7", "3,5"},
            { "30", "6"},
        };
        public static Dictionary<string, string> DaysPricePairsDESERTSTORMForSponsors = new Dictionary<string, string>()
        {
            { "1", "1,1" },
            { "3", "2,8" },
            { "7", "4,5" },
            { "30", "14" },
        };
        public static Dictionary<string, string> DaysPricePairsFiteModForSponsors = new Dictionary<string, string>()
        {
            { "1", "1" },
            { "3", "2" },
            { "7", "4" },
            { "14", "6" },
            { "30", "8" },
        };

        //////////////////////////////////////////ROOT////////////////////////////////////

        public static Dictionary<string, string> DaysPricePairsRootStarForSponsors = new Dictionary<string, string>()
        {
            { "1", "2" } ,
            { "7", "5,2" } ,
            { "30", "10,2" },
        };

        //////////////////////////////////////////IOS////////////////////////////////////




        public static Dictionary<string, string> DaysPricePairsIOSStarForSponsors = new Dictionary<string, string>()
        {
            { "1", "2" } ,
            { "7", "5,75" } ,
            { "30", "12" },
        };


        public static bool IsCallbackPrice(CallbackQuery callbackQuery)
        {
            return callbackQuery.Data.StartsWith("price_");
        }

        //Price`s model:
        //price_{cotegory}_{productName}_{item.Value}_{item.Key}_{rusOrUkr}
        //where item.Value - price and item.Key - duration
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////


