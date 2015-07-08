/*
 * COPYRIGHT LICENSE: This information contains sample code provided in source code form. You may copy, modify, and distribute
 * these sample programs in any form without payment to IBM® for the purposes of developing, using, marketing or distributing
 * application programs conforming to the application programming interface for the operating platform for which the sample code is written.
 * Notwithstanding anything to the contrary, IBM PROVIDES THE SAMPLE SOURCE CODE ON AN "AS IS" BASIS AND IBM DISCLAIMS ALL WARRANTIES,
 * EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, ANY IMPLIED WARRANTIES OR CONDITIONS OF MERCHANTABILITY, SATISFACTORY QUALITY,
 * FITNESS FOR A PARTICULAR PURPOSE, TITLE, AND ANY WARRANTY OR CONDITION OF NON-INFRINGEMENT. IBM SHALL NOT BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE USE OR OPERATION OF THE SAMPLE SOURCE CODE.
 * IBM HAS NO OBLIGATION TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS OR MODIFICATIONS TO THE SAMPLE SOURCE CODE.
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
