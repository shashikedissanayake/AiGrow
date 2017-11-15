using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace AiGrow.DeviceServer
{
    public static class Mqtt
    {
        /// <summary>
        /// Replace this with your endpoint - it's shown in the AWS IoT console next to the REST endpoint - they're the same.
        /// </summary>
        private const string IotEndpoint = "a2o8dyvqdg4v1r.iot.us-west-2.amazonaws.com";
        /// <summary>
        /// This is the default TLS1.2 port that AWS IoT uses
        /// </summary>
        private const int BrokerPort = 8883;
        static X509Certificate caCert = X509Certificate.CreateFromSignedFile(@"D:\visual studio\MQTTAmazon\MQTTAmazon\certificates\VeriSign-Class 3-Public-Primary-Certification-Authority-G5.pem");
        //convert to pfx using openssl
        //you'll need to add these two files to the project and copy them to the output
        static X509Certificate2 clientCert = new X509Certificate2(@"D:\visual studio\MQTTAmazon\MQTTAmazon\certificates\070bf213e6-certificate.pem.pfx", "");
        /// <summary>
        /// Just build it and run it up from the bin folder before you publish a message using the publisher
        /// </summary>
        /// <param name="args">expects Nowt</param>

        public static void Subscribe()
        {

            //this is the AWS caroot.pem file that you get as part of the download
            // this doesn't have to be a new X509 type...

            var client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2 /*this is what AWS IoT uses*/);

            //event handler for inbound messages
            client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;

            //client id here is totally arbitary, but I'm pretty sure you can't have more than one client named the same.
            client.Connect("listener");

            // '#' is the wildcard to subscribe to anything under the 'root' topic
            // the QOS level here - I only partially understand why it has to be this level - it didn't seem to work at anything else.
            client.Subscribe(new[] { "/authenticate" }, new[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

             while (true)
            {
                //listen good!
            }

        }
        public static void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
           
            string s_unicode2 = System.Text.Encoding.UTF8.GetString(e.Message);
	
            
        }

    }
}