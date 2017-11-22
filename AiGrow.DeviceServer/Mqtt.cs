using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using AiGrow.Model;
using AiGrow.Business;
using AiGrow.DeviceServer;
using System.Web.Script.Services;
using System.Web.Services;

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
        //D:\visual studio\MQTTAmazon\MQTTAmazon\certificates
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
            client.Subscribe(new[] { "/aigrow_common" }, new[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            // while (true)
            //{
            //    //listen good!
            //}

        }

        public static void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            BaseResponse response = new BaseResponse();
            string JSONMessage = System.Text.Encoding.UTF8.GetString(e.Message);

            try
            {
                BaseRequest request = new JavaScriptSerializer().Deserialize<BaseRequest>(JSONMessage);
                if (request.command == null)
                {
                    return;
                }

                switch (request.command)
                {
                    case "dataEntry":
                        int device_id = (request.deviceID).getDeviceID();
                        if (device_id < 0)
                        {
                            response.errorMessage = UniversalProperties.UNKNOWN_COMPONENT;
                            response.errorCode = UniversalProperties.EC_UnknownComponent;
                            response.success = false;
                        }
                        else if (device_id == 1)
                        {
                            BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                            new DatabaseUpdate().greenhouseDeviceDataEntry(dataRequest);
                            response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = dataRequest.deviceID;
                        }
                        else if (device_id == 2)
                        {
                            BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                            new DatabaseUpdate().bayDeviceDataEntry(dataRequest);
                            response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = dataRequest.deviceID;
                        }
                        else if (device_id == 3)
                        {
                            BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                            new DatabaseUpdate().bayLineDeviceDataEntry(dataRequest);
                            response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = dataRequest.deviceID;
                        }

                        break;

                    case "registerGreenhouse":

                        GreenhouseRequest gr = new JavaScriptSerializer().Deserialize<GreenhouseRequest>(JSONMessage);

                        foreach (BayRequest bay in gr.listOfBays)
                        {
                            bool registered = new RegisterComponent().registerBay(bay);
                            if (!registered)
                            {
                                response.errorMessage = UniversalProperties.bayNotRegsitered;
                                response.errorCode = UniversalProperties.EC_RegistrationError;
                                response.success = false;
                                break;
                            }
                        }
                        response.message = UniversalProperties.GREENHOUSE_REGISTERED_SUCCESSFULLY;
                        response.success = true;
                        response.deviceID = gr.deviceID;
                        break;

                    case "registerBay":
                        BayRequest bayRequest = new JavaScriptSerializer().Deserialize<BayRequest>(JSONMessage);
                        bool bayRegistered = new RegisterComponent().registerBay(bayRequest);
                        if (!bayRegistered)
                        {
                            response.errorMessage = UniversalProperties.bayNotRegsitered;
                            response.errorCode = UniversalProperties.EC_RegistrationError;
                            response.success = false;
                            break;
                        }
                        response.message = UniversalProperties.BAY_REGISTERED_SUCCESSFULLY;
                        response.success = true;
                        response.deviceID = bayRequest.bay_unique_id;
                        break;

                    case "registerBayDevice":
                        BayDeviceRequest bayDevice = new JavaScriptSerializer().Deserialize<BayDeviceRequest>(JSONMessage);
                        new DatabaseUpdate().registerBayDevice(bayDevice);
                        response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
                        response.success = true;
                        response.deviceID = bayDevice.bay_device_unique_id;
                        break;

                    case "registerBayLine":
                        BayLineRequest bayLine = new JavaScriptSerializer().Deserialize<BayLineRequest>(JSONMessage);
                        bool lineRegistered = new RegisterComponent().registerBayLine(bayLine);
                        if (!lineRegistered)
                        {
                            response.errorMessage = UniversalProperties.lineNotRegsitered;
                            response.errorCode = UniversalProperties.EC_RegistrationError;
                            response.success = false;
                            break;
                        }
                        response.message = UniversalProperties.LINE_REGISTERED_SUCCESSFULLY;
                        response.success = true;
                        response.deviceID = bayLine.bay_line_unique_id;
                        break;

                    case "registerBayLineDevice":
                        BayLineDeviceRequest bayLineDevice = new JavaScriptSerializer().Deserialize<BayLineDeviceRequest>(JSONMessage);
                        new DatabaseUpdate().registerBayLineDevice(bayLineDevice);
                        response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
                        response.success = true;
                        response.deviceID = bayLineDevice.bay_line_device_unique_id;
                        break;

                    case "registerBayRack":
                        BayRackRequest bayRack = new JavaScriptSerializer().Deserialize<BayRackRequest>(JSONMessage);
                        bool rackRegistered = new RegisterComponent().registerBayRack(bayRack);
                        if (!rackRegistered)
                        {
                            response.errorMessage = UniversalProperties.rackNotRegsitered;
                            response.errorCode = UniversalProperties.EC_RegistrationError;
                            response.success = false;
                            break;
                        }  
                        response.message = UniversalProperties.RACK_REGISTERED_SUCCESSFULLY;
                        response.success = true;
                        response.deviceID = bayRack.bay_rack_unique_id;
                        break;


                    //*****************************USE DEVICE ENTRY FOR ALL OTHER QUERIES***********************

                    default:
                        break;
                }
            }
            catch 
            {
                response.errorMessage = UniversalProperties.unknownError;
                response.errorCode = UniversalProperties.EC_UnhandledError;
                response.success = false;
            }
            string responseJSON = new JavaScriptSerializer().Serialize(response);
            Publish("/aigrow_common", responseJSON);
        }
        public static void Publish(string Topic, string content)
        {
            //convert to pfx using openssl - see confluence
            //you'll need to add these two files to the project and copy them to the output (not included in source control deliberately!)

            var client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);
            //message to publish - could be anything
            var message = "Insert your message here";
            //client naming has to be unique if there was more than one publisher
            client.Connect("clientid1");
            //publish to the topic
            client.Publish(Topic, Encoding.UTF8.GetBytes(content));
            //this was in for debug purposes but it's useful to see something in the console
            if (client.IsConnected)
            {
                Debug.WriteLine("SUCCESS!");
            }
            //wait so that we can see the outcome


        }
    }
}