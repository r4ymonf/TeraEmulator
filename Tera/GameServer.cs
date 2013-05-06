using System;
using System.Diagnostics;
using System.Threading;
using Communication;
using Communication.Interfaces;
using Communication.Logic;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;
using InformerLib;
using Network;
using Tera.Services;
using Utils;

namespace Tera
{
    internal class GameServer : Global
    {
        public static TcpServer TcpServer;

        protected static IScsServiceApplication ServiceApplication;

        public static void Main()
        {
            Console.CancelKeyPress += CancelEventHandler;

            try
            {
                RunServer();
            }
            catch (Exception ex)
            {
                Log.FatalException("Can't start server!!", ex);
                return;
            }

            MainLoop();

            StopServer();

            Process.GetCurrentProcess().Kill();
        }

        private static void RunServer()
        {
            Data.Data.DataPath = "data/";

            Stopwatch sw = Stopwatch.StartNew();

            AppDomain.CurrentDomain.UnhandledException += UnhandledException;

            Console.WriteLine("----===== GameServer =====----\n\n"
                              + "Starting game server\n\n"
                              + "Loading data files.\n"
                              + "-------------------------------------------");

            TcpServer = new TcpServer("*", 11101, 1000);
            Connection.SendAllThread.Start();

            OpCodes.Init();

            #region global_components

            //services
            FeedbackService = new FeedbackService();
            AccountService = new AccountService();
            PlayerService = new PlayerService();
            MapService = new MapService();
            ChatService = new ChatService();
            VisibleService = new VisibleService();
            ControllerService = new ControllerService();
            CraftService = new CraftService();
            ItemService = new ItemService();
            AiService = new AiService();
            GeoService = new GeoService();
            StatsService = new StatsService();
            ObserverService = new ObserverService();
            AreaService = new AreaService();
            InformerService = new InformerService();
            TeleportService = new TeleportService();
            PartyService = new PartyService();
            SkillsLearnService = new SkillsLearnService();
            CraftLearnService = new CraftLearnService();
            GuildService = new GuildService();
            EmotionService = new EmotionService();
            RelationService = new RelationService();
            DuelService = new DuelService();
            StorageService = new StorageService();
            TradeService = new TradeService();
            MountService = new MountService();

            //engines
            ActionEngine = new ActionEngine.ActionEngine();
            AdminEngine = new AdminEngine.AdminEngine();
            SkillEngine = new SkillEngine.SkillEngine();
            QuestEngine = new QuestEngine.QuestEngine();

            #endregion

            GlobalLogic.ServerStart();

            TcpServer.BeginListening();

            try
            {
                ServiceApplication = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(23232));
                ServiceApplication.AddService<IInformerService, InformerService>((InformerService) InformerService);
                ServiceApplication.Start();
                Log.Info("InformerService started at *:23232.");
            }
            catch (Exception ex)
            {
                Log.ErrorException("InformerService can not be started.", ex);
            }

            sw.Stop();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("           Server start in {0}", (sw.ElapsedMilliseconds/1000.0).ToString("0.00s"));
            Console.WriteLine("-------------------------------------------");
        }

        private static void StopServer()
        {
            TcpServer.ShutdownServer();
            GlobalLogic.OnServerShutdown();
        }

        // ReSharper disable FunctionNeverReturns

        protected static void UnhandledException(Object sender, UnhandledExceptionEventArgs args)
        {
            Log.FatalException("UnhandledException", (Exception) args.ExceptionObject);

            ShutdownServer();

            while (true)
                Thread.Sleep(1);
        }

        protected static void CancelEventHandler(object sender, ConsoleCancelEventArgs args)
        {
            ShutdownServer();

            while (true)
                Thread.Sleep(1);
        }

        // ReSharper restore FunctionNeverReturns
    }
}