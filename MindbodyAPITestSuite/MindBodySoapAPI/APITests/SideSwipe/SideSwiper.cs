using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gallio.Framework;
using MbUnit.Framework;
using Newtonsoft.Json;

namespace MindbodySoapAPI.APITests.SideSwipe
{
    public class SideSwiper
    {
        private const string SideSwipeUrl = "http://172.20.0.45/api";
        private const int TimeOut = 30000;
        private  readonly Semaphore WaitPool = new Semaphore(16, 16);
        private readonly bool _reusable;
        private readonly bool _freshCopy;

        public SideSwiper(bool reusable, bool freshcopy)
        {
            _reusable = reusable;
            _freshCopy = freshcopy;
        }

        private string TestName
        {
            get { return TestContext.CurrentContext.Test.Name; }
        }

        public string GetMasterId(string masterName)
        {
            var website = GetMaster(masterName);

            return website.StudioId.ToString(CultureInfo.InvariantCulture);
        }

        public SideSwipeWebsite GetCopy(string masterName)
        {
            var testName = TestName;
            var reusable = _reusable;
            var freshCopy = _freshCopy;

            const string getCopyUrl = SideSwipeUrl + "/Copies/GetCopy";
            var query = string.Format("?masterName={0}&testName={1}&reusable={2}&freshCopy={3}", masterName, testName, reusable, freshCopy);

            var request = CreateRequest(getCopyUrl, query);

            var website = ReadRequest(request);
            Assert.IsTrue(website.CopiedFrom.Equals(masterName));

            return website;
        }

        private SideSwipeWebsite GetMaster(string masterName)
        {
            const string getMasterUrl = SideSwipeUrl + "/Masters/GetMaster";
            var query = string.Format("?masterName={0}", masterName);

            var request = CreateRequest(getMasterUrl, query);

            return ReadRequest(request);
        }

        private HttpWebRequest CreateRequest(string url, string query)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + query);
            request.Timeout = TimeOut;

            return request;
        }

        private SideSwipeWebsite ReadRequest(HttpWebRequest request)
        {
            WaitPool.WaitOne();
            WebResponse response;
            response = request.GetResponse();
            WaitPool.Release();

            var stream = new StreamReader(response.GetResponseStream());
            return JsonConvert.DeserializeObject<SideSwipeWebsite>(stream.ReadToEnd());
        }
    }
}
