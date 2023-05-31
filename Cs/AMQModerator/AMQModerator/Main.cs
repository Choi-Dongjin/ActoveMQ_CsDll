using System;

namespace AMQModerator
{
    public class Main
    {
        public static ActiveMQMorderator Morderator { get; set; } = null;

        public static ActiveMQConsumer Consumer { get; set; } = null;

        public static ActiveMQProducer Producer { get; set; } = null;

        #region Common

        /// <summary>
        /// 브로커 URL 확인
        /// </summary>
        /// <param name="brokerUri"> 브로커 URL </param>
        /// <returns> 접속 가능 여부 </returns>
        [DllExport]
        public static bool BrokerUriIsLive(string brokerUri)
        {
            if (ActiveMQHelper.IsConnected(brokerUri))
                return true;
            else
                return false;
        }

        #endregion Common

        /// <summary>
        /// 초기화
        /// </summary>
        /// <param name="brokerUri"> 브로커 URL </param>
        /// <param name="destinationName"> Q or Topic 이름</param>
        /// <returns></returns>
        [DllExport]
        public static bool Initialize(string brokerUri, string destinationName)
        {
            try
            {
                Main.Morderator = new ActiveMQMorderator(brokerUri, destinationName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool ConsumerInitialize(string brokerUri, string destinationName)
        {
            try
            {
                Main.Consumer = new ActiveMQConsumer(brokerUri, destinationName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool ProducerInitialize(string brokerUri, string destinationName)
        {
            try
            {
                Main.Producer = new ActiveMQProducer(brokerUri, destinationName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool IsConnected(bool value)
        {
            if (!value)
                return false;
            return Main.Morderator.IsConnected();
        }

        [DllExport]
        public static bool ConsumerIsConnected(bool value)
        {
            if (!value)
                return false;
            return Main.Consumer.IsConnected();
        }

        [DllExport]
        public static bool ProducerIsConnected(bool value)
        {
            if (!value)
                return false;
            return Main.Producer.IsConnected();
        }

        /// <summary>
        /// 메시지 전송
        /// </summary>
        /// <param name="mess"> 전송할 데이터 </param>
        /// <returns></returns>
        [DllExport]
        public static bool SendMessage(string mess)
        {
            if (Main.Morderator is null)
            {
                Console.WriteLine("Main.Morderator is not Init");
                return false;
            }

            try
            {
                Main.Morderator.SendMessage(mess);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool ProducerSendMessage(string mess)
        {
            if (Main.Producer is null)
            {
                Console.WriteLine("Main.Producer is not Init");
                return false;
            }

            try
            {
                Main.Producer.SendMessage(mess);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool SendMessageStandard(string mess, string nmsType)
        {
            if (Main.Morderator is null)
            {
                Console.WriteLine("Main.Morderator is not Init");
                return false;
            }

            try
            {
                Main.Morderator.SendMessageStandard(mess, nmsType);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool ProducerSendMessageStandard(string mess, string nmsType)
        {
            if (Main.Producer is null)
            {
                Console.WriteLine("Main.Producer is not Init");
                return false;
            }

            try
            {
                int mode = 2;

                //if (Main.Morderator != null)
                //{
                //    if (Main.Morderator.ReceiveIMessage != null)
                //        mode = 1;
                //}
                //else if (Main.Consumer != null)
                //{
                //    if (Main.Consumer.ReceiveIMessage != null)
                //        mode = 2;
                //}

                switch (mode)
                {
                    case 1:
                        Main.Producer.SendMessageStandard(mess, nmsType, Main.Morderator.ReceiveIMessage);
                        return true;
                    case 2:
                        Main.Producer.SendMessageStandard(mess, nmsType, Main.Consumer.ReceiveIMessage);
                        return true;
                    default: return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 데이터 수신
        /// </summary>
        /// <param name="value"> 확인 value </param>
        /// <returns> 수신된 데이터 </returns>
        [DllExport]
        public static string ReceiveMessage(bool value)
        {
            if (!value)
                return "False Value";

            if (Main.Morderator is null)
            {
                Console.WriteLine("Main.Morderator is not Init");
                return "Main.consumer is not Init";
            }

            try
            {
                string data = Main.Morderator.ReceiveMessage();
                if (data == null)
                    return "Null mess";
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        [DllExport]
        public static string ConsumerReceiveMessage(bool value)
        {
            if (!value)
                return "False Value";

            if (Main.Consumer is null)
            {
                Console.WriteLine("Main.Consumer is not Init");
                return "Main.consumer is not Init";
            }

            try
            {
                string data = Main.Consumer.ReceiveMessage();
                if (data == null)
                    return "Null mess";
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        /// <summary>
        /// 중재자 종료
        /// </summary>
        /// <param name="value"> 확인 vlaue </param>
        /// <returns></returns>
        [DllExport]
        public static bool MorderatorDispose(bool value)
        {
            if (!value)
                return false;

            if (Main.Morderator is null)
            {
                return false;
            }

            try
            {
                Main.Morderator.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool ConsumerDispose(bool value)
        {
            if (!value)
                return false;

            if (Main.Consumer is null)
            {
                return false;
            }

            try
            {
                Main.Consumer.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool ProducerDispose(bool value)
        {
            if (!value)
                return false;

            if (Main.Producer is null)
            {
                return false;
            }

            try
            {
                Main.Producer.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [DllExport]
        public static bool TESTInitSendMess_AIRQ(bool value)
        {
            Main.Morderator.TESTInitSendMess_AIRQ();
            return true;
        }
    }
}