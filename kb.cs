using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.Mime.MediaTypeNames;
using static TestForTutorial.kb;

namespace TestForTutorial
{
    public static class kb
    {
        public static ReplyKeyboardMarkup StartMenu = new(new[]
        {
            new KeyboardButton[] { "Личный кабинет", "Товары" },
            new KeyboardButton[] { "Контакты", "Написать отзыв"}
        })
        { ResizeKeyboard = true };

        public static InlineKeyboardMarkup PrivateCabinetUnderButtons = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Мои скидки", callbackData: "my_discounts"),
                InlineKeyboardButton.WithCallbackData(text: "Купить товары", callbackData: "buy goods")
            }
        });
        public static InlineKeyboardMarkup MyOrdersUnderButtons = new(new[] //test inline buttons
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Заказы", callbackData: "orders")

            }
        });
        public static InlineKeyboardMarkup ContactInfoUnderButtons = new(new[] //test inline buttons
        {
            new[]
            {
                InlineKeyboardButton.WithUrl(text: "Dead Games", url: "https://t.me/+n6X8IdI-s5A1MmQ0"), //Should be checked everyday if it has limit
                InlineKeyboardButton.WithUrl(text: "KALIBRY MODS", url: "https://t.me/KALIBRYMODS")
            },
            new[]
            {
                InlineKeyboardButton.WithUrl(text: "Саня", url: "https://t.me/Rasta9man69"),
                //@YaKpYTT
                InlineKeyboardButton.WithUrl(text: "YaKpYTT", url: "https://t.me/YaKpYTT"),

            }
        });
        public static InlineKeyboardMarkup showPrivilegeChoiseForSimplyUsers = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "Pubg mobile", callbackData: "For_SimpleUsers") }
            
        });

        public static InlineKeyboardMarkup showPrivilegeChoiseForResellersOnly = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "Pubg mobile", callbackData: "For_SimpleUsers") },
            new[] { InlineKeyboardButton.WithCallbackData(text: "Для ресселеров", callbackData: "For_Sponsors") },
            

        });

        public static InlineKeyboardMarkup showCurrencyChoise = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "Гривны", callbackData: "hryvnias") },
            new[] { InlineKeyboardButton.WithCallbackData(text: "Рубли", callbackData: "rubli") },
            
        });

        public static InlineKeyboardMarkup showCurrencyChoiseForSponsors = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "Доллары", callbackData: "dollars") },
        });

        public static InlineKeyboardMarkup showPaymentVariants = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "Списать сумму с аккаунта", callbackData: "Buy_via_Account") },
        });

        public static InlineKeyboardMarkup showCategoriesOfGoodsUnderButtons = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Android no root", callbackData: "Android_no_root")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Android root", callbackData: "Android_root")
            },

            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "IOS", callbackData: "ios_"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "For PC", callbackData: "for_PC")
            }


        });


        

        public static InlineKeyboardMarkup showAndroidNoRootGoodsUnderButtons = new(new[]
        {

            //////////////////////NEW//////////////////////////////////////
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Uki", callbackData: "Uki_Android_nroot_soft")
            },

            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "DESERTSTORM", callbackData: "DESERTSTORM_Android_nroot_soft")
            },

            ////////////////////////////////////////////
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Zolo", callbackData: "Zolo_Android_nroot_soft")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Nerohole", callbackData: "Nerohole_Android_nroot_soft")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "SHIELD", callbackData: "SHIELD_Android_nroot_soft")
            },

            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "KING MOD", callbackData: "KING_MOD_Android_nroot_soft")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "FITE MOD", callbackData: "FITE_MOD_Android_nroot_soft")
            },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Back_to_Cotegories") } //Back button

        });

        public static InlineKeyboardMarkup showAndroidRootGoodsUnderButtons = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "root ZOLO", callbackData: "ZOLO_root_soft") },


            //new[] { InlineKeyboardButton.WithCallbackData(text: "OWM", callbackData: "OWM_root_soft") },


            new[] { InlineKeyboardButton.WithCallbackData(text: "root X-Shooter", callbackData: "X-Shooter_root_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Back_to_Cotegories") } //Back button

        });

        public static InlineKeyboardMarkup showIOSGoodsUnderButtons = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "Vn", callbackData: "Vn_IOSsoft") },


            new[] { InlineKeyboardButton.WithCallbackData(text: "IOS Star", callbackData: "IOS_Star_IOSsoft") },


            new[] { InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Back_to_Cotegories") } //Back button
        });

        //public static InlineKeyboardMarkup showPCGoodsUnderButtons = new(new[]
        //{
        //    new[] { InlineKeyboardButton.WithCallbackData(text: "ANUBIS", callbackData: "ANUBIS_PCsoft") },

        //    new[] { InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Back_to_Cotegories") } //Back button
        //});

        public static InlineKeyboardMarkup showBackButtonOnly = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Back_to_Cotegories") } //Back button
        });

        ///////////////////////////////////////////////////////FOR SPONSORS///////////////////////////////////////////////////////



        public static InlineKeyboardMarkup showCategoriesOfGoodsUnderButtonsForSponsors = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Android no root", callbackData: "Android_no_root_ForSponsors")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Android root", callbackData: "Android_root_ForSponsors")
            },

            new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "IOS", callbackData: "ios_ForSponsors"),
            },

        });


        public static InlineKeyboardMarkup showAndroidNoRootGoodsUnderButtonsForSponsors = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "VN", callbackData: "VN_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Zolo", callbackData: "Zolo_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Nerohol", callbackData: "Nerohol_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "KING MOD", callbackData: "KINGMOD_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "OWM MOD", callbackData: "OWMMOD_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Hassan", callbackData: "Hassan_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Uki", callbackData: "Uki_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "HarlyMod", callbackData: "HarlyMod_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "DESERTSTORM", callbackData: "DESERTSTORM_ForSponsors_Android_nroot_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Fite Mod", callbackData: "FiteMod_ForSponsors_Android_nroot_soft") },

            
            new[] { InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Back_to_Cotegories") } //Back button
        });

        public static InlineKeyboardMarkup showAndroidRootGoodsUnderButtonsForSponsors = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "root Star", callbackData: "Star_ForSponsors_Android_root_soft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Back_to_Cotegories") } //Back button
        });



        public static InlineKeyboardMarkup showAndroidIOSGoodsUnderButtonsForSponsors = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "IOS SponsorStar", callbackData: "Star_ForSponsors_IOSsoft") },

            new[] { InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Back_to_Cotegories") } //Back button
        });


        ///////////////////////////////////////////////////////FOR SPONSORS///////////////////////////////////////////////////////

        public static InlineKeyboardMarkup showCommentMessageUnderButtons = new(new[]
        {
            new[] { InlineKeyboardButton.WithUrl(text: "Написать отзыв", "https://t.me/+svvaQ-cb_wkwNTQ8") }
        });

        //new commands

        public static InlineKeyboardMarkup ConfirmOrRejectBuyingProduct = new(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData(text: "Подтвердить", callbackData: "Confirm_Buying_Product") },
            new[] { InlineKeyboardButton.WithCallbackData(text: "Отклонить", callbackData: "Reject_Buying_Product") }
        });




        public enum Category
        {
            AndroidNoRoot,
            AndroidRoot,
            IOS,
            PC
        }
        /// <summary>
        /// Category string array
        /// </summary>
        public static string[] cotegoriesArray = new string[] //should be changed in case enum Category changing 
        {
            $"{Category.AndroidNoRoot}",
            $"{Category.AndroidRoot}",
            $"{Category.IOS}",
            $"{Category.PC}"
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DaysPricePairs">where Key - duration and Value - price</param>
        /// <param name="productName"></param>
        /// <param name="cotegory"></param>
        /// <param name="rusOrUkrorDol"></param>
        /// <returns></returns>
        public static InlineKeyboardMarkup GeneratePrices(Dictionary<string, string> DaysPricePairs, string productName, Category cotegory, string rusOrUkrorDol)
        //InlineKeyboardMarkup inlineKeyboardMarkupOfPriviousMessage
        {

            IEnumerable<IEnumerable<InlineKeyboardButton>> inlineKeyboardButtons = null;

            List<IEnumerable<InlineKeyboardButton>> inlineKeyboardList = inlineKeyboardButtons?.ToList() ?? new List<IEnumerable<InlineKeyboardButton>>();

            foreach (var item in DaysPricePairs)
            {
                //inlineKeyboardMarkup = new(InlineKeyboardButton.WithCallbackData(text: $"{productName} • {item.Value} • {item.Key}",
                //    callbackData: $"{cotegory}_{productName}_{item.Value}_{item.Key}_{UkrorRus}"));

                // Convert the array to a list
                
                if (rusOrUkrorDol == "ukr")
                {
                    InlineKeyboardButton[] newKeyboardRow = new[] 
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"{productName} • {item.Value}₴ • {item.Key} дней", //where item.Value - price and item.Key - duration
                        callbackData: $"price_{cotegory}_{productName}_{item.Value}_{item.Key}_{rusOrUkrorDol}")

                    };
                    inlineKeyboardList.Add(newKeyboardRow);
                }
                if (rusOrUkrorDol == "rus")
                {
                    InlineKeyboardButton[] newKeyboardRow = new[]
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"{productName} • {item.Value}₽ • {item.Key} дней",
                        callbackData: $"price_{cotegory}_{productName}_{item.Value}_{item.Key}_{rusOrUkrorDol}")

                    };
                    inlineKeyboardList.Add(newKeyboardRow);
                }
                if (rusOrUkrorDol == "dol")
                {
                    InlineKeyboardButton[] newKeyboardRow = new[]
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"{productName} • {item.Value}$ • {item.Key} дней",
                        callbackData: $"price_{cotegory}_{productName}_{item.Value}_{item.Key}_{rusOrUkrorDol}")

                    };
                    inlineKeyboardList.Add(newKeyboardRow);
                }
            }
            InlineKeyboardButton[] deleteButtonAndChangeCurrency = new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Назад🔙", callbackData: "Back_to_Cotegories"),
                InlineKeyboardButton.WithCallbackData(text: "Сменить валюту💱", callbackData: "Change_Currency")
            };
        inlineKeyboardList.Add(deleteButtonAndChangeCurrency);
            // Convert the list back to an array if necessary
            inlineKeyboardButtons = inlineKeyboardList.ToArray();
            InlineKeyboardMarkup inlineKeyboardMarkup = new(inlineKeyboardButtons.ToArray());
            return inlineKeyboardMarkup;
        }

        public static InlineKeyboardMarkup GeneratePrices(Dictionary<string, string> DaysPricePairs, string productName, string cotegory, string rusOrUkrorDol)
        //InlineKeyboardMarkup inlineKeyboardMarkupOfPriviousMessage
        {

            IEnumerable<IEnumerable<InlineKeyboardButton>> inlineKeyboardButtons = null;

            List<IEnumerable<InlineKeyboardButton>> inlineKeyboardList = inlineKeyboardButtons?.ToList() ?? new List<IEnumerable<InlineKeyboardButton>>();

            foreach (var item in DaysPricePairs)
            {
                //inlineKeyboardMarkup = new(InlineKeyboardButton.WithCallbackData(text: $"{productName} • {item.Value} • {item.Key}",
                //    callbackData: $"{cotegory}_{productName}_{item.Value}_{item.Key}_{UkrorRus}"));

                // Convert the array to a list

                if (rusOrUkrorDol == "ukr")
                {
                    InlineKeyboardButton[] newKeyboardRow = new[]
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"{productName} • {item.Value}₴ • {item.Key} дней", //where item.Value - price and item.Key - duration
                        callbackData: $"price_{cotegory}_{productName}_{item.Value}_{item.Key}_{rusOrUkrorDol}")

                    };
                    inlineKeyboardList.Add(newKeyboardRow);
                }
                if (rusOrUkrorDol == "rus")
                {
                    InlineKeyboardButton[] newKeyboardRow = new[]
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"{productName} • {item.Value}₽ • {item.Key} дней",
                        callbackData: $"price_{cotegory}_{productName}_{item.Value}_{item.Key}_{rusOrUkrorDol}")

                    };
                    inlineKeyboardList.Add(newKeyboardRow);
                }
                if (rusOrUkrorDol == "dol")
                {
                    InlineKeyboardButton[] newKeyboardRow = new[]
                    {
                        InlineKeyboardButton.WithCallbackData(text: $"{productName} • {item.Value}$ • {item.Key} дней",
                        callbackData: $"price_{cotegory}_{productName}_{item.Value}_{item.Key}_{rusOrUkrorDol}")

                    };
                    inlineKeyboardList.Add(newKeyboardRow);
                }
            }
            InlineKeyboardButton[] deleteButtonAndChangeCurrency = new[]
            {
                InlineKeyboardButton.WithCallbackData(text: "Назад🔙", callbackData: "Back_to_Cotegories"),
                InlineKeyboardButton.WithCallbackData(text: "Сменить валюту💱", callbackData: "Change_Currency")
            };
            inlineKeyboardList.Add(deleteButtonAndChangeCurrency);
            // Convert the list back to an array if necessary
            inlineKeyboardButtons = inlineKeyboardList.ToArray();
            InlineKeyboardMarkup inlineKeyboardMarkup = new(inlineKeyboardButtons.ToArray());
            return inlineKeyboardMarkup;
        }
    }

}