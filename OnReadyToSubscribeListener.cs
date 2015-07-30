﻿/**
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
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using IBM.Worklight;
using Newtonsoft.Json.Linq;

namespace TagNotificationsWP8
{
    class OnReadyToSubscribeListener : WLOnReadyToSubscribeListener
    {
        public void onReadyToSubscribe()
        {
            /* We are now ready to subscribe. Enable all the required buttons */
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                MainPage._this.IsSubscribed.IsEnabled = true;
                MainPage._this.SubscribeTag1.IsEnabled = true;
                MainPage._this.SubscribeTag2.IsEnabled = true;
                MainPage._this.UnsubscribeTag1.IsEnabled = true;
                MainPage._this.UnsubscribeTag2.IsEnabled = true;
                MessageBox.Show("You are now ready to subscribe to push notifications");
            });
        }
    }
}
