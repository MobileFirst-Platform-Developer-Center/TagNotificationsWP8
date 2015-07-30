/**
* Copyright 2015 IBM Corp.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TagNotificationsWP8.Resources;
using IBM.Worklight;
using Newtonsoft.Json.Linq;

namespace TagNotificationsWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        private WLClient client;
        public static MainPage _this;

        // Constructor
        public MainPage()
        {
            _this = this;
            InitializeComponent();

            ReceivedTextBlock.Text = "";
            AboutBox.Text = "IBM MobileFirst Platform\nPush Notification Sample - Tags";

            client = WLClient.getInstance();
            WLPush push = client.getPush();
            OnReadyToSubscribeListener MyOnReadyListener = new OnReadyToSubscribeListener();
            push.onReadyToSubscribeListener = MyOnReadyListener;
            MyNotificationListener NotificationListener = new MyNotificationListener();
            push.notificationListener = NotificationListener;
            client.connect(new MyConnectResponseListener(this));
        }

        public void AddTextToReceivedTextBlock(String param)
        {
            ReceivedTextBlock.Text += param;
        }

        private void IsSubscribed_Click(object sender, RoutedEventArgs e)
        {
            Boolean Tag1Sub = client.getPush().isTagSubscribed("tag1");
            Boolean Tag2Sub = client.getPush().isTagSubscribed("tag2");

            MessageBox.Show("tag1 : " + Tag1Sub + "\ntag2 : " + Tag2Sub);
        }

        private void SubscribeTag1_Click(object sender, RoutedEventArgs e)
        {
            MySubscribeListener SubListener = new MySubscribeListener();
            client.getPush().subscribeTag("tag1", null, SubListener);
        }

        private void SubscribeTag2_Click(object sender, RoutedEventArgs e)
        {
            MySubscribeListener SubListener = new MySubscribeListener();
            client.getPush().subscribeTag("tag2", null, SubListener);
        }

        private void UnsubscribeTag1_Click(object sender, RoutedEventArgs e)
        {
            MyUnsubscribeListener UnsubListener = new MyUnsubscribeListener();
            client.getPush().unsubscribeTag("tag1", UnsubListener);
        }

        private void UnsubscribeTag2_Click(object sender, RoutedEventArgs e)
        {
            MyUnsubscribeListener UnsubListener = new MyUnsubscribeListener();
            client.getPush().unsubscribeTag("tag2", UnsubListener);
        }
    }
}