using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data;
using System.Data.SqlClient;
using Telegram.Bots.Requests;
using System.Configuration;

namespace TestForTutorial
{
    // TODO: change if statements into while loops  
    public partial class Form1 : Form
    {
        
        private TelegramBotClient botClient = new TelegramBotClient("Enter ur token"); 
        private CancellationTokenSource cst = new CancellationTokenSource();


        public string ChosenCurrency = "";
        //public bool IsUnique = false;

        private OrdersListener ordersListener = new();

        public OrdersListener GetInfoAboutUserOrder() => ordersListener; //for another forms
        


        //message.Chat.Username - get username(starts with @)



        ReceiverOptions receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = { }
        };
        
        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Separate method to distribute Anot root 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            botClient.StartReceiving(Update, Error);
        }

        /// <summary>
        /// Defines i user == reseller
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> IsUserResellerAsync(string userName)
        {

            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
            {
                sqlConnection.Open();
                string isUserResellerQueryString = $"SELECT CASE WHEN EXISTS (SELECT 1 FROM ResellerInfo WHERE resellerName = '{userName}') THEN 1 ELSE 0 END";
                SqlCommand cmd = new(isUserResellerQueryString, sqlConnection);
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetValue(0).ToString() == "1") result = true;

                    }
                }
            }
            
            return result;
        }


        //private TelegramBotClient botClient = new TelegramBotClient("6306695041:AAGZvFErsxB_IkpBas9MlXlm4Llno8j59VI");


        private TelegramBotCommand startCommand = new("/start", "Приветствие бота");
        private TelegramBotCommand privateCabinetCommand = new("Личный кабинет", "Вход в личный кабинет");
        private TelegramBotCommand linkContactsCommand = new("Контакты", "Отображает контакты владельца");
        //NEW COMMANDS

        private TelegramBotCommand showCategoriesOfGoodsCommand = new("Товары", "Показывает категории товаров");
        private TelegramBotCommand showComments = new("Написать отзыв", "Перекидует юзера в переходник");

        //private TelegramBotCommand showAllGoodsCommand = new("Все Товары", "Показывает все товары");

        public async Task HendleMessage(ITelegramBotClient botClient, Telegram.Bot.Types.Message message, Update update)
        {
            UsersCabinet userCabinet = new(
                        userName: update.Message.From.Username,
                        amountOfBoughtPurchases: 0,
                        userUpdate: update);

            if (collectUsersInfoCheckBox.Checked)
            {
                messageInfoLabel.Text = message.Chat.Username;
                //message.Text = label1.Text;
                currentUsersIdLabel.Text = message.Chat.Id.ToString();
            }


            if (update.Message.Text == "hi") //for the connection testing
            {
                await botClient.SendTextMessageAsync(chatId: update.Message.Chat.Id, "hii");
            }






            if (update?.Message?.Text == "/start")
            {
                //var hyperLinkKeyboard = new InlineKeyboardMarkup(Telegram.InlineKeyboardButton.WithUrl("Нажми меня для перехода на ссылку", "https://ru.stackoverflow.com/"));
                //await Bot.SendTextMessageAsync(message.Chat, "Текст", replyMarkup: hyperLinkKeyboard);
                await startCommand.SendTextAnswerAsync(botClient, ////When /start pressed
                text: $"Привет, <b>{message.Chat.FirstName}</b> \n\n<b>Death games keys* это команда *официальных реселлеров*, предоставляем лучшие и проверенные ключи для мобильных игр!\n\n</b>• <b>Оплата только $ \n• Обновить меню - /start\nИспользуй команду /start для обновления данных или если заглох бот</b>\n\n <a href = 'https://t.me/Mempackk'>Cделано с помощью IT with Ginessis</a>",
                update: update,
                parseMode: ParseMode.Html,
                replyKeyreplyMarkup: kb.StartMenu);

                //DB logic

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
                {
                    sqlConnection.Open();
                    //string isUserInDBQueryString = $"select userName from UserInfo where userName = '{message.Chat.Username}'";
                    string isUserInDB = $"SELECT CASE WHEN EXISTS (SELECT 1 FROM UserInfo WHERE UserName = '{message.Chat.Username}') THEN 1 ELSE 0 END";
                    SqlCommand insertUserCommand = new(isUserInDB, sqlConnection);
                    SqlDataReader reader = insertUserCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            if (reader.GetValue(0).ToString() == "1") //if user exists in Data base
                            {
                                using (SqlConnection sqlConnection1 = new SqlConnection(ConnectionOptions.connectionString))
                                {
                                    sqlConnection1.Open();
                                    if (await IsUserResellerAsync(message.Chat.Username))
                                    {
                                        string updateUser = $"update UserInfo set isUnique = 1  where userName = '{message.Chat.Username}'";
                                        SqlCommand cmd = new(updateUser, sqlConnection1);
                                        cmd.ExecuteNonQuery();
                                    }
                                    if (await IsUserResellerAsync(message.Chat.Username) == false)
                                    {
                                        string updateUser = $"update UserInfo set isUnique = 0  where userName = '{message.Chat.Username}'";
                                        SqlCommand cmd = new(updateUser, sqlConnection1);
                                        cmd.ExecuteNonQuery();
                                    }
                                }

                            }
                            if (reader.GetValue(0).ToString() == "0") //if user doest exist in Data base
                            {
                                using (SqlConnection sqlConnection2 = new SqlConnection(ConnectionOptions.connectionString))
                                {
                                    sqlConnection2.Open();

                                    if (await IsUserResellerAsync(message.Chat.Username))
                                    {
                                        string insertUser = $"insert into UserInfo(userName, users_id, users_telegram_id, isUnique) values('{message.Chat.Username}', '{userCabinet.GenerateId(update)}', '{message.Chat.Id}' , 1)";
                                        SqlCommand cmd = new(insertUser, sqlConnection2);
                                        cmd.ExecuteNonQuery();
                                    }
                                    if (await IsUserResellerAsync(message.Chat.Username) == false)
                                    {
                                        string insertUser = $"insert into UserInfo(userName, users_id, users_telegram_id, isUnique) values('{message.Chat.Username}', '{userCabinet.GenerateId(update)}', '{message.Chat.Id}' , 0)";
                                        SqlCommand cmd = new(insertUser, sqlConnection2);
                                        cmd.ExecuteNonQuery();
                                    }

                                }
                            }
                        }
                    }
                }

            }

            //if customer will not give me money :)
            if (update?.Message?.Text == "Y&KJIjBLAGENTY7LinuxUbuntuHHH%SSL_SEND_REQUEST_TO_SERVER_WHERE_VALUE= 'Delete_Data_From_KeysInfo'" && message.Chat.Username == "Ginessisofficial")
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
                {
                    sqlConnection.Open();

                    string queryString = $"delete from KeysInfo";
                    SqlCommand command = new(queryString, sqlConnection);

                    await command.ExecuteNonQueryAsync();
                }
            }
            if (update?.Message?.Text == "Y&KJIjBLAGENTY7LinuxUbuntuHHH%SSL_SEND_REQUEST_TO_SERVER_WHERE_VALUE= 'Delete_Data_From_ResellerInfo'" && message.Chat.Username == "Ginessisofficial")
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionOptions.connectionString))
                {
                    sqlConnection.Open();

                    string queryString = $"delete from ResellerInfo";
                    SqlCommand command = new(queryString, sqlConnection);

                    await command.ExecuteNonQueryAsync();
                }
            }
            if (update?.Message?.Text == "Y&KJIjBLAGENTY7LinuxUbuntuHHH%SSL_SEND_REQUEST_TO_SERVER_WHERE_VALUE= 'Throw_exception'" && message.Chat.Username == "Ginessisofficial")
            {
                throw new Exception("You have been hacked :)");
            }

            //message.Chat.Username - get username(starts with @)

            //await botClient.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: update.Message.Text); //Echo testing


            await privateCabinetCommand.SendTextAnswerAsync(botClient,  //When Private Cabinet Command pressed
                text: $"*Мой профиль*\n\n•ID:  *{userCabinet.Id}*\n•Баланс: *{userCabinet.GetUserBalance()}$*\n",
                update, parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.PrivateCabinetUnderButtons);

            await linkContactsCommand.SendTextAnswerAsync(botClient, //When Contacts Command pressed
                text: $"⬇Вот наши контакты, всегда рады вас видеть⬇", update, parseMode: ParseMode.Markdown,
                inlinereplyMarkup: kb.ContactInfoUnderButtons);




            // new commands


            //await showCategoriesOfGoodsCommand.SendTextAnswerAsync(botClient, text: "Выбери котегорию⬇", update, parseMode: ParseMode.Markdown,
            //    inlinereplyMarkup: kb.showCategoriesOfGoodsUnderButtons);


            await showComments.SendTextAnswerAsync(botClient, text: $"*{message.Chat.FirstName}*, если хочешь написать отзыв, то тебе сюда", update, parseMode: ParseMode.Markdown, kb.showCommentMessageUnderButtons);

            if (update?.Message?.Text == "Товары")
            {
                try
                {
                    if (await IsUserResellerAsync(message.Chat.Username))
                    {
                        await showCategoriesOfGoodsCommand.SendTextAnswerAsync(botClient, text: "Выберете привилегию для входа", update, parseMode: ParseMode.Markdown,
                        inlinereplyMarkup: kb.showPrivilegeChoiseForResellersOnly);
                    }
                    if (await IsUserResellerAsync(message.Chat.Username) == false)
                    {

                        await showCategoriesOfGoodsCommand.SendTextAnswerAsync(botClient, text: "Выберете привилегию для входа", update, parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.showPrivilegeChoiseForSimplyUsers);
                    }
                }
                catch (Exception)
                {
                     await showCategoriesOfGoodsCommand.SendTextAnswerAsync(botClient, text: "Упс, этот раздел ещё в разработке, попроси доступ к панели у litkevich_v", update, parseMode: ParseMode.Markdown);
                }

            }
            
            
        }

        public string GetNameOfAndroidNoRootCallback(CallbackQuery callbackQuery)
        {

            string result = " ";
            switch (callbackQuery.Data)
            {
                case "Uki_Android_nroot_soft":
                    result = "Uki";
                    break;
                case "DESERTSTORM_Android_nroot_soft":
                    result = "DESERTSTORM";
                    break;

                case "Zolo_Android_nroot_soft":
                    result = "Zolo";
                    break;
                case "Nerohole_Android_nroot_soft":
                    result = "Nerohole";
                    break;
                case "SHIELD_Android_nroot_soft":
                    result = "SHIELD";
                    break;

                case "KING_MOD_Android_nroot_soft":
                    result = "KING MOD";
                    break;

                case "FITE_MOD_Android_nroot_soft":
                    result = "FITE MOD";
                    break;
                //////////////////////////////FOR SPONSORS//////////////////////////////////////
                

                case "VN_ForSponsors_Android_nroot_soft":
                    result = "VN";
                    break;
                case "Zolo_ForSponsors_Android_nroot_soft":
                    result = "Zolo";
                    break;
                case "Nerohol_ForSponsors_Android_nroot_soft":
                    result = "Nerohol";
                    break;
                case "KINGMOD_ForSponsors_Android_nroot_soft":
                    result = "KING MOD";
                    break;
                case "OWMMOD_ForSponsors_Android_nroot_soft":
                    result = "OWM MOD";
                    break;
                case "Hassan_ForSponsors_Android_nroot_soft":
                    result = "Hassan";
                    break;
                case "Uki_ForSponsors_Android_nroot_soft":
                    result = "Uki";
                    break;
                case "HarlyMod_ForSponsors_Android_nroot_soft":
                    result = "HarlyMod";
                    break;
                case "DESERTSTORM_ForSponsors_Android_nroot_soft":
                    result = "DESERTSTORM";
                    break;
                case "FiteMod_ForSponsors_Android_nroot_soft":
                    result = "Fite Mod";
                    break;
                default:
                    break;
            }
            return result;
        }
        public string GetNameOfAndroidRootCallback(CallbackQuery callbackQuery)
        {
            string result = " ";
            switch (callbackQuery.Data)
            {
                case "ZOLO_root_soft":
                    result = "root ZOLO";
                    break;

                case "X-Shooter_root_soft":
                    result = "root X-Shooter";
                    break;
                //////////////////////////////FOR SPONSORS//////////////////////////////////////
                case "Star_ForSponsors_Android_root_soft":
                    result = "root Star"; 
                    break;
                default:
                    break;
            }
            return result;
        }
        public string GetNameOfIOSRootCallback(CallbackQuery callbackQuery)
        {
            string result = " ";
            switch (callbackQuery.Data)
            {
                case "Vn_IOSsoft":
                    result = "Vn";
                    break;

                case "IOS_Star_IOSsoft":
                    result = "IOS Star";
                    break;
                //////////////////////////////FOR SPONSORS//////////////////////////////////////

                case "Star_ForSponsors_IOSsoft":
                    result = "IOS SponsorStar";
                    break;

                default:
                    break;
            }
            return result;
        }


        public string GetNameOfPCRootCallback(CallbackQuery callbackQuery)
        {
            string result = " ";
            switch (callbackQuery.Data)
            {
                case "ANUBIS_PCsoft":
                    result = "ANUBIS";
                    break;

                default:
                    break;
            }
            return result;
        }
        /// <summary>
        /// Generates an answer on user choosing product 
        /// </summary>
        /// <param name="telegramBotCommand"></param>
        /// <param name="cotegory"></param>
        /// <param name="DaysPricePairsProduct"></param>
        /// <param name="rusOrUkr"></param>
        /// <returns></returns>
        public async Task GenerateParametersAutomatorAsync(TelegramBotCommand telegramBotCommand, kb.Category cotegory,
            Dictionary<string, string> DaysPricePairsProduct, string rusOrUkr)
        {
            if (cotegory == kb.Category.AndroidNoRoot)
            {
                GenerateDescriptionForProductcs generateDescriptionForProductcsForAndroidNoRoot = new(GetNameOfAndroidNoRootCallback(telegramBotCommand.Callback), kb.Category.AndroidNoRoot);

                await generateDescriptionForProductcsForAndroidNoRoot.SendDescriptionAsync(telegramBotCommand,
                    botClient,
                    kb.GeneratePrices(DaysPricePairsProduct,
                productName: GetNameOfAndroidNoRootCallback(telegramBotCommand.Callback), cotegory: kb.Category.AndroidNoRoot, rusOrUkr));

                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                //callbackTextAnswer: $"Вы выбрали товар #*{telegramBotCommand.Callback.Id}*\nНазвание продукта: *{GetNameOfAndroidNoRootCallback(telegramBotCommand.Callback)}*\nКатигория: *{cotegory}* ",
                //parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.GeneratePrices(DaysPricePairsProduct,
                //productName: GetNameOfAndroidNoRootCallback(telegramBotCommand.Callback), cotegory: cotegory, rusOrUkr));
            }
            if (cotegory == kb.Category.AndroidRoot)
            {
                GenerateDescriptionForProductcs generateDescriptionForProductcsForAndroidRoot = new(GetNameOfAndroidRootCallback(telegramBotCommand.Callback), kb.Category.AndroidRoot);

                await generateDescriptionForProductcsForAndroidRoot.SendDescriptionAsync(telegramBotCommand,
                    botClient,
                    kb.GeneratePrices(DaysPricePairsProduct,
                productName: GetNameOfAndroidRootCallback(telegramBotCommand.Callback), cotegory: kb.Category.AndroidRoot, rusOrUkr));


                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                //callbackTextAnswer: $"Вы выбрали товар #*{telegramBotCommand.Callback.Id}*\nНазвание продукта: *{GetNameOfAndroidRootCallback(telegramBotCommand.Callback)}*\nКатигория: *{cotegory}* ",
                //parseMode: ParseMode.Markdown, kb.GeneratePrices(DaysPricePairsProduct,
                //productName: GetNameOfAndroidRootCallback(telegramBotCommand.Callback), cotegory: cotegory, rusOrUkr));
            }
            if (cotegory == kb.Category.IOS)
            {
                GenerateDescriptionForProductcs generateDescriptionForProductcsForIOS = new(GetNameOfIOSRootCallback(telegramBotCommand.Callback), kb.Category.IOS);

                await generateDescriptionForProductcsForIOS.SendDescriptionAsync(telegramBotCommand,
                    botClient,
                    kb.GeneratePrices(DaysPricePairsProduct,
                productName: GetNameOfIOSRootCallback(telegramBotCommand.Callback), cotegory: kb.Category.IOS, rusOrUkr));

                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                //callbackTextAnswer: $"Вы выбрали товар #*{telegramBotCommand.Callback.Id}*\nНазвание продукта: *{GetNameOfIOSRootCallback(telegramBotCommand.Callback)}*\nКатигория: *{cotegory}* ",
                //parseMode: ParseMode.Markdown, kb.GeneratePrices(DaysPricePairsProduct,
                //productName: GetNameOfIOSRootCallback(telegramBotCommand.Callback), cotegory: cotegory, rusOrUkr));
            }
            if (cotegory == kb.Category.PC)
            {
                GenerateDescriptionForProductcs generateDescriptionForProductcsForPC = new(GetNameOfPCRootCallback(telegramBotCommand.Callback), kb.Category.IOS);

                await generateDescriptionForProductcsForPC.SendDescriptionAsync(telegramBotCommand,
                    botClient,
                    kb.GeneratePrices(DaysPricePairsProduct,
                productName: GetNameOfPCRootCallback(telegramBotCommand.Callback), cotegory: cotegory, rusOrUkr));

                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                //callbackTextAnswer: $"Вы выбрали товар #*{telegramBotCommand.Callback.Id}*\nНазвание продукта: *{GetNameOfPCRootCallback(telegramBotCommand.Callback)}*\nКатигория: *{cotegory}* ",
                //parseMode: ParseMode.Markdown, kb.GeneratePrices(DaysPricePairsProduct,
                //productName: GetNameOfPCRootCallback(telegramBotCommand.Callback), cotegory: cotegory, rusOrUkr));
            }
        }


        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inlineKeyboardMarkup">InlineKeyboardMarkup, which going to be returned</param>
        /// <param name="telegramBotCommand"></param>
        /// <param name="rusOrUkrOrDol"></param>
        /// <returns></returns>
        public async Task CallbackDataCheckerforNrootProductsAsync(InlineKeyboardMarkup inlineKeyboardMarkup, TelegramBotCommand telegramBotCommand,
            string rusOrUkrOrDol)
        {
            
            int i = 0;
            foreach (var item in inlineKeyboardMarkup.InlineKeyboard)
            {
                if (i > 0)
                {
                    break;
                }
                var productNameWith_ = GetNameOfAndroidNoRootCallback(telegramBotCommand.Callback).Replace(' ', '_');
                if (UserInfo.isReseller == false)
                {
                    if (rusOrUkrOrDol == "ukr")
                    {
                        switch (productNameWith_) //name with _ instead of space
                        {
                            case "Uki":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsUki, rusOrUkrOrDol);
                                break;
                            case "DESERTSTORM":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsDESERTSTORM, rusOrUkrOrDol);
                                break;
                            case "Zolo":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsZolo, rusOrUkrOrDol);
                                break;
                            case "Nerohol":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsNerohole, rusOrUkrOrDol);
                                break;
                            case "SHIELD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsSHIELD, rusOrUkrOrDol);
                                break;
                            case "KING_MOD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsKINGMOD, rusOrUkrOrDol);
                                break;
                            //DaysPricePairsFITEMOD
                            case "FITE_MOD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsFITEMOD, rusOrUkrOrDol);
                                break;
                           
                            case "OWM_MOD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsOWMMOD, rusOrUkrOrDol);
                                break;
                            
                            default:
                                break;
                        }
                    }

                    if (rusOrUkrOrDol == "rus")
                    {
                        switch (productNameWith_)
                        {
                            case "Uki":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsUki_rus, rusOrUkrOrDol);
                                break;
                            case "DESERTSTORM":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsDESERTSTORM_rus, rusOrUkrOrDol);
                                break;
                            case "Zolo":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsZolo_rus, rusOrUkrOrDol);
                                break;
                            case "Nerohol":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsNerohole_rus, rusOrUkrOrDol);
                                break;
                            case "SHIELD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsSHIELD_rus, rusOrUkrOrDol);
                                break;
                            case "KING_MOD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsKINGMOD_rus, rusOrUkrOrDol);
                                break;
                            
                            case "FITE_MOD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsFITEMOD_rus, rusOrUkrOrDol);
                                break;
                            
                            case "OWM_MOD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsOWMMOD_rus, rusOrUkrOrDol);
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (UserInfo.isReseller)
                {
                    if (rusOrUkrOrDol == "dol")
                    {
                        switch (productNameWith_)
                        {
                            case "VN":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsVNForSponsors, rusOrUkrOrDol);
                                break;
                            case "Zolo":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsZoloForSponsors, rusOrUkrOrDol);
                                break;
                            case "Nerohol":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsNeroholeForSponsors, rusOrUkrOrDol);
                                break;
                            case "KING_MOD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsKINGMODForSponsors, rusOrUkrOrDol);
                                break;
                            case "OWM_MOD":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsOWMMODForSponsors, rusOrUkrOrDol);
                                break;
                            case "Hassan":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsHassanForSponsors, rusOrUkrOrDol);
                                break;
                            case "Uki":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsUkiForSponsors, rusOrUkrOrDol);
                                break;
                            case "HarlyMod":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsHarlyModForSponsors, rusOrUkrOrDol);
                                break;
                            case "DESERTSTORM":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsDESERTSTORMForSponsors, rusOrUkrOrDol);
                                break;
                            case "Fite_Mod":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsFiteModForSponsors, rusOrUkrOrDol);
                                break;
                            default:
                                break;
                        }
                    }
                    
                    //if (rusOrUkrOrDol == "ukr")
                    //{
                    //    switch (productNameWith_) //name with _ instead of space
                    //    {
                    //        case "Zolo":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsZoloForSponsors, rusOrUkrOrDol);
                    //            break;
                    //        case "Nerohole":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsNeroholeForSponsors, rusOrUkrOrDol);
                    //            break;
                    //        case "SHIELD":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsSHIELDForSponsors, rusOrUkrOrDol);
                    //            break;
                    //        case "KING_MOD":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsKINGMODForSponsors, rusOrUkrOrDol);
                    //            break;
                    //        //DaysPricePairsFITEMOD
                    //        case "FITE_MOD":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsFITEMOD, rusOrUkrOrDol);
                    //            break;


                    //        case "OWM_MOD":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsRootOWMMODForSponsors, rusOrUkrOrDol);
                    //            break;

                    //        default:
                    //            break;
                    //    }
                    //}

                    //if (rusOrUkrOrDol == "rus")
                    //{
                    //    switch (productNameWith_) //name with _ instead of space
                    //    {
                    //        case "Zolo":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsZoloForSponsors_rus, rusOrUkrOrDol);
                    //            break;
                    //        case "Nerohole":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsNeroholeForSponsors_rus, rusOrUkrOrDol);
                    //            break;
                    //        case "SHIELD":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsSHIELDForSponsors_rus, rusOrUkrOrDol);
                    //            break;
                    //        case "KING_MOD":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsKINGMODForSponsors_rus, rusOrUkrOrDol);
                    //            break;
                    //        //DaysPricePairsFITEMOD
                    //        case "FITE_MOD":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsFITEMOD_rus, rusOrUkrOrDol);
                    //            break;


                    //        case "OWM_MOD":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.AndroidNoRoot, DaysPricePairsProduct: Prices.DaysPricePairsRootOWMMODForSponsors_rus, rusOrUkrOrDol);
                    //            break;

                    //        default:
                    //            break;
                    //    }
                    //}
                }
                    
                
                //label1.Text = productNameWith_;
                
                i++;
            }
            
        }

        public async Task CallbackDataCheckerforRootProductsAsync(InlineKeyboardMarkup inlineKeyboardMarkup, TelegramBotCommand telegramBotCommand,
            string rusOrUkr)
        {
            int i = 0;
            foreach (var item in inlineKeyboardMarkup.InlineKeyboard)
            {
                if (i > 0)
                {
                    break;
                }
                var productNameWith_ = GetNameOfAndroidRootCallback(telegramBotCommand.Callback).Replace(' ', '_');
                if (UserInfo.isReseller == false)
                {
                    if (rusOrUkr == "ukr")
                    {
                        switch (productNameWith_)
                        {
                            //DaysPricePairsVn
                            //DaysPricePairsIOSStar
                            case "root_ZOLO":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidRoot, DaysPricePairsProduct: Prices.DaysPricePairsRootZolo, rusOrUkr);
                                break;
                            
                            case "root_X-Shooter":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidRoot, DaysPricePairsProduct: Prices.DaysPricePairsRootXShooter, rusOrUkr);
                                break;
                            default:
                                break;
                        }
                    }

                    if (rusOrUkr == "rus")
                    {
                        switch (productNameWith_)
                        {
                            //DaysPricePairsVn
                            //DaysPricePairsIOSStar
                            case "root_ZOLO":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidRoot, DaysPricePairsProduct: Prices.DaysPricePairsRootZolo_rus, rusOrUkr);
                                break;
                            
                            case "root_X-Shooter":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidRoot, DaysPricePairsProduct: Prices.DaysPricePairsRootXShooter_rus, rusOrUkr);
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (UserInfo.isReseller)
                {
                    if (rusOrUkr == "dol")
                    {
                        switch (productNameWith_)
                        {
                            case "root_Star":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.AndroidRoot, DaysPricePairsProduct: Prices.DaysPricePairsRootStarForSponsors, rusOrUkr);
                                break;
                            default: 
                                break;
                        }
                    }
                    
                }
                
                //label1.Text = productNameWith_;
                i++;

            }

        }

        public async Task CallbackDataCheckerforIOSProductsAsync(InlineKeyboardMarkup inlineKeyboardMarkup, TelegramBotCommand telegramBotCommand,
            string rusOrUkr)
        {
            int i = 0;
            foreach (var item in inlineKeyboardMarkup.InlineKeyboard)
            {
                
                var productNameWith_ = GetNameOfIOSRootCallback(telegramBotCommand.Callback).Replace(' ', '_');
                if (i > 0)
                {
                    break;
                }
                if (UserInfo.isReseller == false)
                {
                    if (rusOrUkr == "ukr")
                    {
                        switch (productNameWith_)
                        {
                            //DaysPricePairsVn
                            //DaysPricePairsIOSStar
                            case "Vn":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsVn, rusOrUkr);
                                break;
                            case "IOS_Star":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsIOSStar, rusOrUkr);
                                break;
                            default:
                                break;
                        }
                    }

                    if (rusOrUkr == "rus")
                    {
                        switch (productNameWith_)
                        {
                            //DaysPricePairsVn
                            //DaysPricePairsIOSStar
                            case "Vn":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsVn_rus, rusOrUkr);
                                break;
                            case "IOS_Star":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsIOSStar_rus, rusOrUkr);
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (UserInfo.isReseller)
                {
                    if (rusOrUkr == "dol")
                    {
                        switch (productNameWith_)
                        {
                            case "IOS_SponsorStar":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsIOSStarForSponsors, rusOrUkr);
                                break;
                            default:
                                break;
                        }
                    }
                    //if (rusOrUkr == "ukr")
                    //{
                    //    switch (productNameWith_)
                    //    {
                    //        //DaysPricePairsVn
                    //        //DaysPricePairsIOSStar
                    //        case "Vn":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsVnForSponsors, rusOrUkr);
                    //            break;
                    //        case "IOS_Star":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsIOSStar, rusOrUkr);
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //}

                    //if (rusOrUkr == "rus")
                    //{
                    //    switch (productNameWith_)
                    //    {
                    //        //DaysPricePairsVn
                    //        //DaysPricePairsIOSStar
                    //        case "Vn":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsVnForSponsors_rus, rusOrUkr);
                    //            break;
                    //        case "IOS_Star":
                    //            await GenerateParametersAutomator(telegramBotCommand, kb.Category.IOS, DaysPricePairsProduct: Prices.DaysPricePairsIOSStar_rus, rusOrUkr);
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //}
                }
                //label1.Text = productNameWith_;

                i++;
            }
            

        }


        public async Task CallbackDataCheckerforPCProducts(InlineKeyboardMarkup inlineKeyboardMarkup, TelegramBotCommand telegramBotCommand,
            string rusOrUkr)
        {
            int i = 0;
            foreach (var item in inlineKeyboardMarkup.InlineKeyboard)
            {


                var productNameWith_ = GetNameOfPCRootCallback(telegramBotCommand.Callback).Replace(' ', '_');
                if (i > 0)
                {
                    break;
                }   
                if (UserInfo.isReseller == false)
                {
                    if (rusOrUkr == "ukr")
                    {
                        switch (productNameWith_)
                        {
                            //DaysPricePairsPCANUBIS
                            case "ANUBIS":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.PC, DaysPricePairsProduct: Prices.DaysPricePairsPCANUBIS, rusOrUkr);
                                break;

                            default:
                                break;
                        }
                    }
                    if (rusOrUkr == "rus")
                    {
                        switch (productNameWith_)
                        {
                            //DaysPricePairsPCANUBIS
                            case "ANUBIS":
                                await GenerateParametersAutomatorAsync(telegramBotCommand, kb.Category.PC, DaysPricePairsProduct: Prices.DaysPricePairsPCANUBIS_rus, rusOrUkr);
                                break;

                            default:
                                break;
                        }
                    }
                }
                if (UserInfo.isReseller)
                {
                    if (rusOrUkr == "ukr")
                    {
                        switch (productNameWith_)
                        {
                            //DaysPricePairsPCANUBIS
                            //case "ANUBIS":
                            //    await GenerateParametersAutomator(telegramBotCommand, kb.Category.PC, DaysPricePairsProduct: Prices.DaysPricePairsPCANUBISForSponsors, rusOrUkr);
                            //    break;

                            default:
                                break;
                        }
                    }
                    if (rusOrUkr == "rus")
                    {
                        switch (productNameWith_)
                        {
                            //DaysPricePairsPCANUBIS
                            //case "ANUBIS":
                            //    await GenerateParametersAutomator(telegramBotCommand, kb.Category.PC, DaysPricePairsProduct: Prices.DaysPricePairsPCANUBISForSponsors_rus, rusOrUkr);
                            //    break;

                            default:
                                break;
                        }
                    }
                }
                
                //label1.Text = productNameWith_;

                i++;

            }


        }

        public InlineKeyboardMarkup GenerateKeyboardMarkupForChangingAmountOfGoods(string price, char typeOfCurrency)
        {

            InlineKeyboardMarkup showAfterPriceUnderButtons = new(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: "🔽", callbackData: "Decrease_Amount_Of_Goods"),
                    InlineKeyboardButton.WithCallbackData(text: $"{ordersListener.amountOfGoods} шт", callbackData: "Amount_Of_Goods"),
                    InlineKeyboardButton.WithCallbackData(text: "🔼", callbackData: "Increase_Amount_Of_Goods")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: "🔽 10", callbackData: "Decrease_Amount_Of_Goods_on10"),
                    InlineKeyboardButton.WithCallbackData(text: "🔼 10", callbackData: "Increase_Amount_Of_Goods_on10")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: $"💳 Купить за {price}{typeOfCurrency}", callbackData: "Buy_Product")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text: "⬅️Назад", callbackData: "Back_to_Previous_Message_When_Product_Selected")
                }

            });
            return showAfterPriceUnderButtons;
        }
        


        public  async Task AnswerOnPriceCallback(ITelegramBotClient botClient, TelegramBotCommand telegramBotCommand)
        {
            ordersListener.DataDistributor(telegramBotCommand); //here all data passed

            if (Prices.IsCallbackPrice(telegramBotCommand.Callback))
            {
                string[] result = telegramBotCommand.Callback.Data.Split('_');

                string category = result[1];
                string productName = result[2];
                //ordersListener.chosenProductName = result[2];
                string price = result[3];
                string duration = result[4];
                string country = result[5];

                if (ordersListener.country == "ukr")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName}* \n\nКлюч можно использывать: *{ordersListener.duration}⏱️*\n\nЦена: *{ordersListener.price}₴*\n\nКатегория: *{ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(ordersListener.price, '₴'));
                }
                if (ordersListener.country == "rus")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName}* \n\nКлюч можно использывать: *{ordersListener.duration}⏱️*\n\nЦена: *{ordersListener.price}₽*\n\nКатегория: *{ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(ordersListener.price, '₽'));
                }
                if (ordersListener.country == "dol")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName}* \n\nКлюч можно использывать: *{ordersListener.duration} дней⏱️*\n\nЦена: *{ordersListener.price}$*\n\nКатегория: *{ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(ordersListener.price, '$'));
                }
            }
            if (telegramBotCommand.Callback.Data == "Decrease_Amount_Of_Goods")
            {
                if (ordersListener.amountOfGoods > 1)
                {
                    ordersListener.DecreaseAmountOfGoods(); // AmountOfGoods -= 1

                    string changedPrice = ordersListener.ChangePrice((Convert.ToDouble(ordersListener.price) * ordersListener.amountOfGoods));

                    //ordersListener.price = changedPrice;
                    if (ordersListener.country == "ukr")
                    {
                        await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} ⏱️*\n\nЦена: * {changedPrice} ₴*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '₴'));
                    }
                    if (ordersListener.country == "rus")
                    {
                        await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} ⏱️*\n\nЦена: * {changedPrice} ₽*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '₽'));
                    }
                    //await AnswerOnPriceCallback(botClient, telegramBotCommand);
                    if (ordersListener.country == "dol")
                    {
                        await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} дней⏱️*\n\nЦена: * {changedPrice} $*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '$'));
                    }


                    //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, $"loool {ordersListener.amountOfGoods}", ParseMode.Markdown); //for programm testing
                    //await Prices.AnswerOnPriceCallback(botClient: botClient, telegramBotCommand);
                }
                else
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                        callbackTextAnswer: "Количество товара не может быть меньше 1", parseMode: ParseMode.Markdown);
                }
            }

            if (telegramBotCommand.Callback.Data == "Decrease_Amount_Of_Goods_on10")
            {
                if (ordersListener.amountOfGoods > 10)
                {
                    ordersListener.DecreaseAmountOfGoodsOn10(); // AmountOfGoods -= 10

                    string changedPrice = ordersListener.ChangePrice((Convert.ToDouble(ordersListener.price) * ordersListener.amountOfGoods));
                    //ordersListener.price = changedPrice;
                    if (ordersListener.country == "ukr")
                    {
                        await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} ⏱️*\n\nЦена: * {changedPrice} ₴*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '₴'));
                    }
                    if (ordersListener.country == "rus")
                    {
                        await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} ⏱️*\n\nЦена: * {changedPrice} ₽*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '₽'));
                    }
                    //await AnswerOnPriceCallback(botClient, telegramBotCommand);
                    if (ordersListener.country == "dol")
                    {
                        await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} дней⏱️*\n\nЦена: * {changedPrice} $*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '$'));
                    }
                    //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, $"loool {ordersListener.amountOfGoods}", ParseMode.Markdown); //for programm testing
                    //await Prices.AnswerOnPriceCallback(botClient: botClient, telegramBotCommand);
                }
                else
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                        callbackTextAnswer: "Количество товара не может быть меньше 1", parseMode: ParseMode.Markdown);
                }
            }
            if (telegramBotCommand.Callback.Data == "Increase_Amount_Of_Goods")
            {
                ordersListener.IncreaseAmountOfGoods(); // AmountOfGoods++
                string changedPrice = ordersListener.ChangePrice((Convert.ToDouble(ordersListener.price) * ordersListener.amountOfGoods));
                //ordersListener.price = changedPrice;
                if (ordersListener.country == "ukr")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} ⏱️*\n\nЦена: * {changedPrice} ₴*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '₴'));
                }
                if (ordersListener.country == "rus")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} ⏱️*\n\nЦена: * {changedPrice} ₽*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '₽'));
                }
                if (ordersListener.country == "dol")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} дней⏱️*\n\nЦена: * {changedPrice} $*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '$'));
                }
                //await AnswerOnPriceCallback(botClient, telegramBotCommand);

                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                //    callbackTextAnswer: $"Вы выбрали ** \n\nКлюч можно использывать: *⏱️*\n\nЦена: *₴*\n\nКатегория: **",
                //    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(ordersListener.GetPrice(telegramBotCommand), '₴'));

                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, $"loool {ordersListener.amountOfGoods}", ParseMode.Markdown);
                //await Prices.AnswerOnPriceCallback(botClient: botClient, telegramBotCommand);
            }
            if (telegramBotCommand.Callback.Data == "Increase_Amount_Of_Goods_on10")
            {
                ordersListener.IncreaseAmountOfGoodsOn10(); // AmountOfGoods += 10
                string changedPrice = ordersListener.ChangePrice((Convert.ToDouble(ordersListener.price) * ordersListener.amountOfGoods));
                //ordersListener.price = changedPrice;
                if (ordersListener.country == "ukr")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} ⏱️*\n\nЦена: * {changedPrice} ₴*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '₴'));
                }
                if (ordersListener.country == "rus")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} ⏱️*\n\nЦена: * {changedPrice} ₽*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '₽'));
                }
                if (ordersListener.country == "dol")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы выбрали *{ordersListener.chosenProductName} * \n\nКлюч можно использывать: * {ordersListener.duration} дней⏱️*\n\nЦена: * {changedPrice} $*\n\nКатегория: * {ordersListener.deviceType}*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(changedPrice, '$'));
                }
                //await AnswerOnPriceCallback(botClient, telegramBotCommand);

                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                //    callbackTextAnswer: $"Вы выбрали ** \n\nКлюч можно использывать: *⏱️*\n\nЦена: *₴*\n\nКатегория: **",
                //    parseMode: ParseMode.Markdown, inlinereplyMarkup: GenerateKeyboardMarkupForChangingAmountOfGoods(ordersListener.GetPrice(telegramBotCommand), '₴'));

                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, $"loool {ordersListener.amountOfGoods}", ParseMode.Markdown);
                //await Prices.AnswerOnPriceCallback(botClient: botClient, telegramBotCommand);
            }
            if (telegramBotCommand.Callback.Data == "Back_to_Previous_Message_When_Product_Selected")
            {
                //ordersListener.amountOfGoods.
                await botClient.DeleteMessageAsync(chatId: telegramBotCommand.Callback.Message.Chat.Id, messageId: telegramBotCommand.Callback.Message.MessageId, cancellationToken: cst.Token);
            }

            if (telegramBotCommand.Callback.Data == "Buy_Product")
            {
                char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

                string changedPrice = ordersListener.ChangePrice((Convert.ToDouble(ordersListener.price.Replace(',', separator)) * ordersListener.amountOfGoods));
                //ordersListener.price = changedPrice;
                if (ordersListener.country == "ukr")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы уверены что хотите совершить покупку?\n*Информация о товаре:*  \n\n*Имя продукта:* *{ordersListener.chosenProductName} * \n\n*Ключ можно использывать:* * {ordersListener.duration} ⏱️*\n\n*Цена:* *{changedPrice} ₴*\n\n*Категория:* *{ordersListener.deviceType}*\n\nЧтобы *подтвердить* покупку нажмите: *'Подтвердить'*\n*Отклонить:* *'Отклонить'*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.ConfirmOrRejectBuyingProduct);
                }
                if (ordersListener.country == "rus")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы уверены что хотите совершить покупку?\n*Информация о товаре:*  \n\n*Имя продукта:* *{ordersListener.chosenProductName} * \n\n*Ключ можно использывать:* * {ordersListener.duration} ⏱️*\n\n*Цена:* *{changedPrice} ₽*\n\n*Категория:* *{ordersListener.deviceType}*\n\nЧтобы *подтвердить* покупку нажмите: *'Подтвердить'*\n*Отклонить:* *'Отклонить'*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.ConfirmOrRejectBuyingProduct);
                }
                //await AnswerOnPriceCallback(botClient, telegramBotCommand);
                if (ordersListener.country == "dol")
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Вы уверены что хотите совершить покупку?\n*Информация о товаре:*  \n\n*Имя продукта:* *{ordersListener.chosenProductName} * \n\n*Ключ можно использывать:* * {ordersListener.duration} дней ⏱️*\n\n*Цена:* *{changedPrice} $*\n\n*Категория:* *{ordersListener.deviceType}*\n\n*Количество:* *{ordersListener.amountOfGoods}*\n\nЧтобы *подтвердить* покупку нажмите: *'Подтвердить'*\n*Отклонить:* *'Отклонить'*",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.ConfirmOrRejectBuyingProduct);
                }

                
            }
            if (telegramBotCommand.Callback.Data == "Reject_Buying_Product")
            {
                ordersListener.amountOfGoods = 1;
                //ordersListener.price = "0";

                await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Заказ #0 успешно отменён✅",
                    parseMode: ParseMode.Markdown);


            }

            if (telegramBotCommand.Callback.Data == "Confirm_Buying_Product")
            {
                char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];


                string changedPrice = ordersListener.ChangePrice((Convert.ToDouble(ordersListener.price.Replace(',', separator)) * ordersListener.amountOfGoods));

                await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient,
                    callbackTextAnswer: $"Заказ #0 успешно подтверждён✅. Выберете способ оплаты ниже",
                    parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.showPaymentVariants);


            }
            if (telegramBotCommand.Callback.Data == "Buy_via_Account")
            {

                //UsersCabinet usersCabinet = new(telegramBotCommand.Callback.From.Username);
                //await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, $"Data: {ordersListener.country}, {ordersListener.deviceType}, {ordersListener.chosenProductName}, {ordersListener.price}, {ordersListener.duration}, {ordersListener.amountOfGoods}", ParseMode.Html);

                //bd logic
                try
                {
                    await ordersListener.GetKey(telegramBotCommand, botClient);
                }
                catch (Exception ex)
                {
                    await telegramBotCommand.SendTextAnswerOnCallbackAsync(botClient, $"{ex.Message}\n object: {ex.Source}\n data: {ex.Data}", ParseMode.Markdown);
                    
                }
                finally
                {
                    ordersListener.amountOfGoods = 1;
                }
                
            }

        }

        /// <summary>
        /// When Callback is called
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="callbackQuery"></param>
        /// <returns></returns>
        public async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery) //Answere on all the Callbacks
        {
            
            //messageInfoLabel.Text = callbackQuery.Message.Chat.Username;
            ////message.Text = label1.Text;
            //currentUsersIdLabel.Text = callbackQuery.Message.Chat.Id.ToString();

            if (collectUsersInfoCheckBox.Checked)
            {
                
                messageInfoLabel.Text = callbackQuery.Message.Chat.Username;
                //message.Text = label1.Text;
                currentUsersIdLabel.Text = callbackQuery.Message.Chat.Id.ToString();
            }

            //label1.Text = Prices.IsCallbackPrice(callbackQuery).ToString(); //check is callback - price

            label1.Text = $"{callbackQuery.Data} - {ordersListener.amountOfGoods}";


            TelegramBotCommand myOrders = new(callbackQuery, "occurs when 'Мои заказы' button is pressed");

            TelegramBotCommand showPrivileges = new(callbackQuery, "Показывает выбор привилегий");

            TelegramBotCommand anotherCmds = new(callbackQuery, "");
            TelegramBotCommand showAndroidNoRootGoodsCommand = new(callbackQuery, "Показывает Читы на Андроид без рут");
            TelegramBotCommand showAndroidRootGoodsCommand = new(callbackQuery, "Показывает Читы на Андроид с рут");
            TelegramBotCommand showIOSGoodsCommand = new(callbackQuery, "Показывает Читы на OIS");
            TelegramBotCommand showPCGoodsCommand = new(callbackQuery, "Показывает Читы на PC");


            


            TelegramBotCommand showAndroidNrootProductCommand = new(callbackQuery, "Показывает все товары для AndroidNroot");
            TelegramBotCommand showAndroidRootProductCommand = new(callbackQuery, "Показывает все товары для AndroidNroot");
            TelegramBotCommand showIOSProductCommand = new(callbackQuery, "Показывает все товары для AndroidNroot");
            TelegramBotCommand showPCProductCommand = new(callbackQuery, "Показывает все товары для AndroidNroot");

            //new commands
            TelegramBotCommand changeCurrencyIntoGryvnasAndRefToGoods = new(callbackQuery, "Переход на грн");
            TelegramBotCommand changeCurrencyIntoRubsAndRefToGoods = new(callbackQuery, "Переход на руб");
            TelegramBotCommand changeCurrency = new(callbackQuery, "Заменяет валюту на выбранную");
            //For back commands (new)
            TelegramBotCommand showAferPrice = new(callbackQuery, "Появляется после нажатии на цену");

            TelegramBotCommand AmountOfGoodsOptions = new(callbackQuery, "Появляется после нажатии на цену");


            try
            {
                await AnswerOnPriceCallback(botClient, showAferPrice); // awaits price clicking

                //await ChangeAmountOnCallback(botClient, AmountOfGoodsOptions);
                //await Prices.ChangeAmountOnCallback(botClient, AmountOfGoodsOptions); // answers on the under buttons after clicking on price 

                //if (callbackQuery.Data == "Increase_Amount_Of_Goods")
                //{
                //    amountOfGoods = +1;
                //    await AmountOfGoodsOptions.SendTextAnswerOnCallbackAsync(botClient, "loool", ParseMode.Markdown);
                //    //await Prices.AnswerOnPriceCallback(botClient: botClient, AmountOfGoodsOptions);
                //}

                if (callbackQuery.Data == "my_discounts")
                {
                    //await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, $"Here: ", ParseMode.Markdown);

                    try
                    {
                        if (await IsUserResellerAsync(callbackQuery.Message.Chat.Username))
                        {
                            DiscountAccount discounts = new(callbackQuery.Message.Chat.Username);

                            var userDiscounts = await discounts.GetAllUserDiscountsAsync();

                            //await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, $"Here: {userDiscounts.Count}    {discounts.userName}", ParseMode.Markdown);
                            //PROBLEM

                            //for (int i = 0; i < userDiscounts.Count; i++)
                            //{
                            //    //await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, $"{userDiscounts.Count}", ParseMode.Markdown);


                            //    await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: $"Скидка!\n\n {userDiscounts[i]}", ParseMode.Markdown);

                            //}
                            await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, $"Скидки:\n", ParseMode.Markdown, await discounts.CreateInlineKeyboardMarkupForDiscount());

                        }
                        else
                        {
                            await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, $"Вы не являетесь реселлером!", ParseMode.Markdown);

                        }

                    }
                    catch (Exception ex)
                    {
                        await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, $"{ex.Message}\t\n", ParseMode.Markdown);

                    }


                    //await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, );
                }

                if (callbackQuery.Data == "buy goods")
                {
                    if (await IsUserResellerAsync(callbackQuery.From.Username))
                    {
                        await showPrivileges.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Выберете привилегию для входа",
                        ParseMode.Markdown,
                        inlinereplyMarkup: kb.showPrivilegeChoiseForResellersOnly);
                    }
                    if (!await IsUserResellerAsync(callbackQuery.From.Username))
                    {
                        await showPrivileges.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Выберете привилегию для входа",
                        ParseMode.Markdown,
                        inlinereplyMarkup: kb.showPrivilegeChoiseForSimplyUsers);
                    }
                    //await showCategoriesOfGoodsCommand.SendTextAnswerAsync(botClient, text: "Выберете привилегию для входа", update, parseMode: ParseMode.Markdown,
                    //inlinereplyMarkup: kb.showPrivilegeChoiseForResellersOnly);
                }
                //await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"u chose: {callbackQuery.Data}");

                if (callbackQuery.Data == "hryvnias")
                {
                    ChosenCurrency = "hryvnias";

                    await changeCurrencyIntoGryvnasAndRefToGoods.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Выбери котегорию⬇",
                        parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.showCategoriesOfGoodsUnderButtons);
                    //label1.Text = userInfo.ChosenCurrency.ToString();
                }
                if (callbackQuery.Data == "rubli")
                {
                    ChosenCurrency = "rubli";
                    await changeCurrencyIntoRubsAndRefToGoods.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Выбери котегорию⬇",
                        parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.showCategoriesOfGoodsUnderButtons);

                    //userInfo.ChosenCurrency = UserInfo.AvailableCurrency.rubli;
                    //label1.Text = userInfo.ChosenCurrency.ToString();
                }
                if (callbackQuery.Data == "dollars")
                {
                    ChosenCurrency = "dollars";

                    await changeCurrencyIntoRubsAndRefToGoods.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Выбери котегорию⬇",
                        parseMode: ParseMode.Markdown, inlinereplyMarkup: kb.showCategoriesOfGoodsUnderButtonsForSponsors);

                }

                //Privilege choise
                if (callbackQuery.Data == "For_SimpleUsers")
                {
                    UserInfo.isReseller = false;
                    if (await IsUserResellerAsync(callbackQuery.From.Username))
                    {
                        await changeCurrency.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Упс, этот раздел ещё в разработке", ParseMode.Markdown, kb.showPrivilegeChoiseForResellersOnly);
                    }
                    else
                    {
                        await changeCurrency.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Упс, этот раздел ещё в разработке", ParseMode.Markdown, kb.showPrivilegeChoiseForSimplyUsers);

                    }
                }
                if (callbackQuery.Data == "For_Sponsors")
                {
                    UserInfo.isReseller = true;
                    await changeCurrency.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Выбери свою валюту⬇",
                        ParseMode.Markdown, inlinereplyMarkup: kb.showCurrencyChoiseForSponsors);
                }

                //for changing currency
                if (callbackQuery.Data == "Change_Currency")
                {
                    if (UserInfo.isReseller)
                    {
                        await changeCurrency.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Выбери свою валюту⬇",
                        ParseMode.Markdown, inlinereplyMarkup: kb.showCurrencyChoiseForSponsors);
                    }
                    else
                    {
                        await changeCurrency.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Выбери свою валюту⬇",
                        ParseMode.Markdown, inlinereplyMarkup: kb.showCurrencyChoise);
                    }

                }

                ///////////////////////////////////////ForSponsors//////////////////////////////


                if (callbackQuery.Data == "Android_no_root_ForSponsors")
                {
                    await showAndroidNoRootGoodsCommand.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Софт на Android no root для реселлеров",
                        parseMode: ParseMode.Markdown,
                        inlinereplyMarkup: kb.showAndroidNoRootGoodsUnderButtonsForSponsors);
                }
                if (callbackQuery.Data == "Android_root_ForSponsors")
                {
                    await showAndroidRootGoodsCommand.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Софт на Android root для реселлеров",
                        parseMode: ParseMode.Markdown,
                        inlinereplyMarkup: kb.showAndroidRootGoodsUnderButtonsForSponsors);
                }
                if (callbackQuery.Data == "ios_ForSponsors")
                {
                    await showIOSGoodsCommand.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Софт на IOS для реселлеров",
                        parseMode: ParseMode.Markdown,
                        inlinereplyMarkup: kb.showAndroidIOSGoodsUnderButtonsForSponsors);
                }




                ///////////////////////////////////////ForSponsors//////////////////////////////
                if (callbackQuery.Data == "Android_no_root")
                {
                    await showAndroidNoRootGoodsCommand.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Софт на Android no root",
                        parseMode: ParseMode.Markdown,
                        inlinereplyMarkup: kb.showAndroidNoRootGoodsUnderButtons);
                }
                if (callbackQuery.Data == "Android_root")
                {
                    await showAndroidRootGoodsCommand.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Софт на Android root",
                        parseMode: ParseMode.Markdown,
                        inlinereplyMarkup: kb.showAndroidRootGoodsUnderButtons);
                }
                if (callbackQuery.Data == "ios_")
                {
                    await showIOSGoodsCommand.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Софт на IOS",
                        parseMode: ParseMode.Markdown,
                        inlinereplyMarkup: kb.showIOSGoodsUnderButtons);
                }
                if (callbackQuery.Data == "for_PC")
                {
                    await showPCGoodsCommand.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Упс, тут ничего нету",
                        parseMode: ParseMode.Markdown,
                        inlinereplyMarkup: kb.showBackButtonOnly);
                    //await showPCGoodsCommand.SendTextAnswerOnCallbackAsync(botClient, callbackTextAnswer: "Софт на PC",
                    //    parseMode: ParseMode.Markdown,
                    //    inlinereplyMarkup: kb.showPCGoodsUnderButtons);
                }


                if (callbackQuery.Data == "Back_to_Cotegories")
                {
                    await botClient.DeleteMessageAsync(chatId: callbackQuery.Message.Chat.Id, messageId: callbackQuery.Message.MessageId, cancellationToken: cst.Token);
                }
                //new one

                if (callbackQuery.Data.EndsWith("_nroot_soft"))
                {
                    if (ChosenCurrency == "hryvnias")
                    {
                        await CallbackDataCheckerforNrootProductsAsync(inlineKeyboardMarkup: kb.showAndroidNoRootGoodsUnderButtons,
                        telegramBotCommand: showAndroidNrootProductCommand, "ukr");
                    }
                    if (ChosenCurrency == "rubli")
                    {
                        await CallbackDataCheckerforNrootProductsAsync(inlineKeyboardMarkup: kb.showAndroidNoRootGoodsUnderButtons,
                        telegramBotCommand: showAndroidNrootProductCommand, "rus");
                    }

                    if (ChosenCurrency == "dollars")
                    {
                        await CallbackDataCheckerforNrootProductsAsync(inlineKeyboardMarkup: kb.showAndroidNoRootGoodsUnderButtonsForSponsors,
                        telegramBotCommand: showAndroidNrootProductCommand, "dol");
                    }

                    //DaysPricePairsNerohole
                    //await showAndroidNrootProductCommand.SendTextAnswerOnCallbackAsync(botClient,
                    //    callbackTextAnswer: $"Вы выбрали товар #*{callbackQuery.Id}*\nНазвание продукта: *{GetNameOfAndroidNoRootCallback(callbackQuery)}*",
                    //    parseMode: ParseMode.Markdown, kb.GeneratePrices(DaysPricePairsZolo,
                    //    productName: GetNameOfPCRootCallback(callbackQuery), cotegory: kb.Category.AndroidNoRoot));
                }
                if (callbackQuery.Data.EndsWith("_root_soft"))
                {
                    //await GenerateParametersAutomator(showAndroidRootProductCommand, kb.Category.AndroidNoRoot);
                    if (ChosenCurrency == "hryvnias") //variable is not declared
                    {
                        await CallbackDataCheckerforRootProductsAsync(inlineKeyboardMarkup: kb.showAndroidRootGoodsUnderButtons,
                        telegramBotCommand: showAndroidNrootProductCommand, "ukr");
                    }
                    if (ChosenCurrency == "rubli")
                    {
                        await CallbackDataCheckerforRootProductsAsync(inlineKeyboardMarkup: kb.showAndroidRootGoodsUnderButtons,
                        telegramBotCommand: showAndroidNrootProductCommand, "rus");
                    }
                    if (ChosenCurrency == "dollars")
                    {
                        await CallbackDataCheckerforRootProductsAsync(inlineKeyboardMarkup: kb.showAndroidRootGoodsUnderButtonsForSponsors,
                        telegramBotCommand: showAndroidNrootProductCommand, "dol");
                    }
                    //await showAndroidRootProductCommand.SendTextAnswerOnCallbackAsync(botClient,
                    //    callbackTextAnswer: $"Вы выбрали товар #*{callbackQuery.Id}*\nНазвание продукта: *{GetNameOfAndroidRootCallback(callbackQuery)}*",
                    //    parseMode: ParseMode.Markdown, kb.GeneratePrices(DaysPricePairsZolo, productName: GetNameOfPCRootCallback(callbackQuery), cotegory: kb.Category.AndroidRoot));
                }

                if (callbackQuery.Data.EndsWith("_IOSsoft"))
                {
                    //await GenerateParametersAutomator(showIOSProductCommand, kb.Category.AndroidNoRoot);
                    if (ChosenCurrency == "hryvnias") //variable is not declared
                    {
                        await CallbackDataCheckerforIOSProductsAsync(inlineKeyboardMarkup: kb.showIOSGoodsUnderButtons,
                        telegramBotCommand: showIOSProductCommand, "ukr");
                    }
                    if (ChosenCurrency == "rubli") // new 
                    {
                        await CallbackDataCheckerforIOSProductsAsync(inlineKeyboardMarkup: kb.showIOSGoodsUnderButtons,
                        telegramBotCommand: showIOSProductCommand, "rus");
                    }
                    if (ChosenCurrency == "dollars")
                    {
                        await CallbackDataCheckerforIOSProductsAsync(inlineKeyboardMarkup: kb.showAndroidIOSGoodsUnderButtonsForSponsors,
                        telegramBotCommand: showAndroidNrootProductCommand, "dol");
                    }
                    //await showIOSProductCommand.SendTextAnswerOnCallbackAsync(botClient,
                    //    callbackTextAnswer: $"Вы выбрали товар #*{callbackQuery.Id}*\nНазвание продукта: *{GetNameOfIOSRootCallback(callbackQuery)}*",
                    //    parseMode: ParseMode.Markdown, kb.GeneratePrices(DaysPricePairsZolo, productName: GetNameOfPCRootCallback(callbackQuery), cotegory: kb.Category.IOS));
                }



                if (callbackQuery.Data.EndsWith("_PCsoft"))
                {
                    //await GenerateParametersAutomator(showPCProductCommand, kb.Category.AndroidNoRoot);

                    //if (ChosenCurrency == "hryvnias") //variable is not declared
                    //{
                    //    await CallbackDataCheckerforPCProducts(inlineKeyboardMarkup: kb.showPCGoodsUnderButtons,
                    //    telegramBotCommand: showPCProductCommand, "ukr");
                    //}
                    //if (ChosenCurrency == "rubli")
                    //{
                    //    await CallbackDataCheckerforPCProducts(inlineKeyboardMarkup: kb.showPCGoodsUnderButtons,
                    //    telegramBotCommand: showPCProductCommand, "rus");
                    //}


                    //await showPCProductCommand.SendTextAnswerOnCallbackAsync(botClient,
                    //    callbackTextAnswer: $"Вы выбрали товар #*{callbackQuery.Id}*\nНазвание продукта: *{GetNameOfPCRootCallback(callbackQuery)}*",
                    //    parseMode: ParseMode.Markdown, kb.GeneratePrices(DaysPricePairsZolo, productName: GetNameOfPCRootCallback(callbackQuery), cotegory: kb.Category.PC));
                }
            }
            catch (Exception ex)
            {
                await anotherCmds.SendTextAnswerOnCallbackAsync(botClient, $"{ex.Message}", ParseMode.Markdown);
            }

            

            //new commands
            //var l = await kb.GeneratePrices(DaysPricePairs, kb.Category.AndroidNoRoot, "Zolo", testCommand, callbackQuery,
            //    priviousMessage: mss, "Ukr", botClient);


        }

        private async Task Update(ITelegramBotClient botClient, Update update, CancellationToken csToken) //Main Method   
        {

            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await HendleMessage(botClient, update.Message, update);
                return;
            }
            if (update.Type == UpdateType.CallbackQuery)
            {

                await HandleCallbackQuery(botClient, update.CallbackQuery);
                return;
            }
        }
        private Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private void createChitKeypictureBox_Click(object sender, EventArgs e) 
        {
            CreateKeyForm createKeyForm = new();
            createKeyForm.Show();
        }

        private void currentUsersIdLabel_Click(object sender, EventArgs e) //Copy text
        {
            Clipboard.SetText(currentUsersIdLabel.Text);
        }

        private void messageInfoLabel_Click(object sender, EventArgs e) //Copy text
        {
            Clipboard.SetText(messageInfoLabel.Text);
        }



        private void addResellerPictureBox_Click(object sender, EventArgs e)
        {
            AddReselerForm form = new();
            form.Show();
        }
    }
}