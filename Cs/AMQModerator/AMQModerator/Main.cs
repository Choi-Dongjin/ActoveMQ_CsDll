using System;

namespace AMQModerator
{
    public class Main
    {
        public static ActiveMQProducer producer = null;
        public static ActiveMQConsumer consumer = null;

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

        #region Producer

        /// <summary>
        /// 생산자 초기화
        /// </summary>
        /// <param name="brokerUri"> 브로커 URL </param>
        /// <param name="queueOrTopicName"> Q or Topic 이름</param>
        /// <returns></returns>
        [DllExport]
        public static bool ProducerInitialize(string brokerUri, string queueOrTopicName)
        {
            try
            {
                Main.producer = new ActiveMQProducer(brokerUri, queueOrTopicName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 메시지 전송
        /// </summary>
        /// <param name="mess"> 전송할 데이터 </param>
        /// <returns></returns>
        [DllExport]
        public static bool ProducerSendMessage(string mess)
        {
            if (Main.producer is null)
            {
                Console.WriteLine("Main.producer is not Init");
                return false;
            }

            try
            {
                Main.producer.SendMessage(mess);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 생산자 종료
        /// </summary>
        /// <param name="value"> 확인 vlaue </param>
        /// <returns></returns>
        [DllExport]
        public static bool ProducerDispose(bool value)
        {
            if (!value)
                return false;

            if (Main.producer is null)
            {
                Console.WriteLine("Main.producer is not Init");
                return false;
            }

            try
            {
                Main.producer.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion Producer

        #region Consumer

        /// <summary>
        /// 소비자 초기화
        /// </summary>
        /// <param name="brokerUri"> 브로커 URL </param>
        /// <param name="queueOrTopicName"> Q or Topic 이름 </param>
        /// <returns> 실행 확인 value </returns>
        [DllExport]
        public static bool ConsumerInitialize(string brokerUri, string queueOrTopicName)
        {
            try
            {
                Main.consumer = new ActiveMQConsumer(brokerUri, queueOrTopicName);
                return true;
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
        public static string ConsumerReceiveMessage(bool value)
        {
            if (!value)
                return "False Value";

            if (Main.consumer is null)
            {
                Console.WriteLine("Main.consumer is not Init");
                return "Main.consumer is not Init";
            }

            try
            {
                string data = Main.consumer.ReceiveMessage();
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
        public static string ConsumerGetAllReceiveMessages(bool value)
        {
            if (!value)
                return "False Value";

            if (Main.consumer is null)
            {
                Console.WriteLine("Main.consumer is not Init");
                return "Main.consumer is not Init";
            }
            try
            {
                string data = Main.consumer.GetAllMessages();
                if (string.IsNullOrWhiteSpace(data))
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
        public static bool ClearAllMessages(bool value)
        {
            if (!value)
                return false;

            if (Main.consumer is null)
            {
                Console.WriteLine("Main.consumer is not Init");
                return false;
            }

            try
            {
                Main.consumer.ClearAllMessages();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 소비자 종료
        /// </summary>
        /// <param name="value"> 확인 vlaue </param>
        /// <returns> 실행 확인 vlaue </returns>
        [DllExport]
        public static bool ConsumerDispose(bool value)
        {
            if (!value)
                return false;

            if (Main.consumer is null)
            {
                Console.WriteLine("Main.consumer is not Init");
                return false;
            }

            try
            {
                Main.consumer.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion Consumer
    }
}