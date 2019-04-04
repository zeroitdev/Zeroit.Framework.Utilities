// ***********************************************************************
// Assembly         : Zeroit.Framework.Utilities
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="AjaxRequest.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Cache;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zeroit.Framework.Utilities.Web
{
    /// <summary>
    /// This class performs AjaxRequests.
    /// </summary>
    public class AjaxRequest
    {
        #region Events

        /// <summary>
        /// The event that is invoked once the request completed.
        /// </summary>
        public event AjaxHandler OnComplete;

        /// <summary>
        /// The event that is invoked once the request fails.
        /// </summary>
        public event AjaxHandler OnError;

        /// <summary>
        /// The event that is invoked once the request succeeds.
        /// </summary>
        public event AjaxResponseHandler OnSuccess;

        #endregion

        #region Members

        /// <summary>
        /// The header
        /// </summary>
        IDictionary<string, string> header;
        /// <summary>
        /// The body
        /// </summary>
        string body;
        /// <summary>
        /// The request
        /// </summary>
        HttpWebRequest request;
        /// <summary>
        /// The response
        /// </summary>
        HttpWebResponse response;
        /// <summary>
        /// The task
        /// </summary>
        Task task;

        #endregion

        #region ctor

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="options">The options.</param>
        public AjaxRequest(AjaxRequestOptions options)
        {
            Options = options;
            header = new Dictionary<string, string>();
            body = string.Empty;
            var url = options.DirectUrl;

            if (options.Type == AjaxRequestType.GET)
                url = options.DirectUrl + "?" + options.EncodedNameValuePairs;

            request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = Options.Type.ToString();
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            request.Timeout = Options.Timeout * 1000;

            if(!string.IsNullOrEmpty(Options.MimeType))
                request.ContentType = Options.MimeType;

            request.AllowAutoRedirect = true;
            request.Date = DateTime.Now;

            if(!string.IsNullOrEmpty(Options.Accepts))
                request.Accept = Options.Accepts;

            if (!string.IsNullOrEmpty(Options.UserName))
                SetAuthorizationHeader(Options.UserName, Options.Password ?? string.Empty);

            // See: http://en.wikipedia.org/wiki/List_of_HTTP_header_fields
            if(!Options.DiscardRequestedWith)
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");

            foreach (string key in Options.Headers.Keys)
                request.Headers[key] = Options.Headers[key].ToString();

            if (Options.Complete != null)
                OnComplete += Options.Complete;

            if (Options.Success != null)
                OnSuccess += Options.Success;

            if (Options.Error != null)
                OnError += Options.Error;

            task = new Task(PerformRequest);
            ReadyState = Zeroit.Framework.Utilities.Web.ReadyState.Uninitialized;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Aborts the current Ajax request.
        /// </summary>
        /// <returns>The current instance.</returns>
        public AjaxRequest Abort()
        {
            if (Running)
            {
                request.Abort();
                Running = false;
                task.Dispose();
            }

            return this;
        }

        /// <summary>
        /// Starts the current Ajax request.
        /// </summary>
        /// <returns>The current instance.</returns>
        public AjaxRequest Invoke()
        {
            if (!Running)
            {
                ReadyState = Zeroit.Framework.Utilities.Web.ReadyState.Open;
                IsResolved = true;
                Running = true;

                if (Options.BeforeSend != null)
                    Options.BeforeSend(this, new AjaxEventArgs(Options));

                if (Options.Async)
                {
                    task.ContinueWith(HandleResponse)
                        .ContinueWith(FinishResponse, TaskScheduler.FromCurrentSynchronizationContext());
                    task.Start();
                }
                else
                {
                    task.RunSynchronously();
                    HandleResponse(task);
                    FinishResponse(task);
                }

                ReadyState = Zeroit.Framework.Utilities.Web.ReadyState.Sent;
            }

            return this;
        }

        /// <summary>
        /// Creates a XML document from the ResponseText.
        /// </summary>
        /// <returns>The XDocument instance containing the XML nodes.</returns>
        public XDocument CreateXmlObject()
        {
            if (string.IsNullOrEmpty(ResponseText))
                return new XDocument();

            return XDocument.Parse(ResponseText);
        }

        /// <summary>
        /// Creates a JSON object from the ResponseText.
        /// </summary>
        /// <returns>The dynamic JSON object.</returns>
        public dynamic CreateJsonObject()
        {
            if (string.IsNullOrEmpty(ResponseText))
                return new { } as dynamic;

            return DynamicJsonConverter.Instance.Deserialize(ResponseText, typeof(object)) as dynamic;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Sets the authorization header.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        void SetAuthorizationHeader(string username, string password)
        {
            var authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers.Add("Authorization", "Basic " + authInfo);
        }

        /// <summary>
        /// Setups the request.
        /// </summary>
        void SetupRequest()
        {
            var query = Options.EncodedNameValuePairs;
            var stream = request.GetRequestStream();
            var content = Encoding.UTF8.GetBytes(query);
            stream.Write(content, 0, content.Length);
        }

        /// <summary>
        /// Performs the request.
        /// </summary>
        void PerformRequest()
        {
            if (Options.Type != AjaxRequestType.GET)
                SetupRequest();

            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;

                if (response == null)
                    throw;
            }
        }

        /// <summary>
        /// Handles the response.
        /// </summary>
        /// <param name="task">The task.</param>
        void HandleResponse(Task task)
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                ReadyState = Zeroit.Framework.Utilities.Web.ReadyState.Receiving;
                StatusCode = response.StatusCode;
                StatusText = response.StatusDescription;
                LastModified = response.LastModified;
                ResponseUrl = response.ResponseUri;
                ResponseType = response.ContentType;
                ReadResponse(response.ContentEncoding);

                foreach (string key in response.Headers.Keys)
                    header.Add(key, response.Headers[key]);
            }
        }

        /// <summary>
        /// Finishes the response.
        /// </summary>
        /// <param name="task">The task.</param>
        void FinishResponse(Task task)
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                ResponseDataType = Options.DataType;
                var ev = new DataFilterEventArgs(Options, ResponseText);

                if (Options.DataType == AjaxDataType.Guess)
                    ResponseDataType = GuessDataType();

                if (Options.Filters.ContainsKey(ResponseDataType))
                    (Options.Filters[ResponseDataType] as AjaxFilterHandler).Invoke(this, ev);
                else
                    DefaultFilter(ev);

                ResponseText = ev.ModifiedData;
                var ro = CreateObject(ResponseDataType);
                var args = new AjaxResponseEventArgs(Options, ResponseText, ro);
                IsResolved = true;

                if (Options.StatusCodeHandlers.ContainsKey(StatusCode))
                    (Options.StatusCodeHandlers[StatusCode] as AjaxResponseHandler).Invoke(this, args);

                if (OnSuccess != null)
                    OnSuccess.Invoke(this, args);
            }
            else
            {
                if (OnError != null)
                    OnError.Invoke(this, new AjaxEventArgs(Options));
            }

            ReadyState = Zeroit.Framework.Utilities.Web.ReadyState.Loaded;

            if (response != null)
                response.Close();

            if (OnComplete != null)
                OnComplete.Invoke(this, new AjaxEventArgs(Options));
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns>System.Object.</returns>
        object CreateObject(AjaxDataType dt)
        {
            if (Options.ProcessData)
            {
                var methods = GetType().GetMethods();

                foreach (var method in methods)
                    if (method.Name.Equals("Create" + dt.ToString() + "Object"))
                        return method.Invoke(this, null);
            }
            
            return ResponseText;
        }

        /// <summary>
        /// Reads the response.
        /// </summary>
        /// <param name="encoding">The encoding.</param>
        void ReadResponse(string encoding)
        {
            if (string.IsNullOrEmpty(encoding))
                encoding = "utf-8";

            var enc = Encoding.GetEncoding(encoding) ?? Encoding.UTF8;
            var buffer = new byte[4096];
            var length = 0;
            var sb = new StringBuilder();
            var stream = response.GetResponseStream();

            while ((length = stream.Read(buffer, 0, buffer.Length)) > 0)
                sb.Append(enc.GetString(buffer, 0, length));

            ResponseText = sb.ToString();
        }

        /// <summary>
        /// Defaults the filter.
        /// </summary>
        /// <param name="ev">The <see cref="DataFilterEventArgs"/> instance containing the event data.</param>
        void DefaultFilter(DataFilterEventArgs ev)
        {
            //TODO
        }

        /// <summary>
        /// Guesses the type of the data.
        /// </summary>
        /// <returns>AjaxDataType.</returns>
        AjaxDataType GuessDataType()
        {
            //TODO

            if (ResponseType.Contains("application/x-javascript"))
                return AjaxDataType.Jsonp;
            else if (ResponseType.Contains("application/atom+xml"))
                return AjaxDataType.Xml;

            var sanatized = ResponseText.Replace(" ", string.Empty);

            if (sanatized.StartsWith("{"))
                return AjaxDataType.Json;
            else if (sanatized.StartsWith("<?xml"))
                return AjaxDataType.Xml;
            else if (sanatized.StartsWith("<"))
                return AjaxDataType.Html;

            return AjaxDataType.Script;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the headers from the response.
        /// </summary>
        /// <value>The reponse header.</value>
        public IDictionary<string, string> ReponseHeader { get { return header; } }

        /// <summary>
        /// Gets a value if the request has been rejected.
        /// </summary>
        /// <value><c>true</c> if this instance is rejected; otherwise, <c>false</c>.</value>
        public bool IsRejected { get; private set; }

        /// <summary>
        /// Gets a value if the request has been completed successfully.
        /// </summary>
        /// <value><c>true</c> if this instance is resolved; otherwise, <c>false</c>.</value>
        public bool IsResolved { get; private set; }

        /// <summary>
        /// Gets the options that have been used for this request.
        /// </summary>
        /// <value>The options.</value>
        public AjaxRequestOptions Options { get; private set; }

        /// <summary>
        /// Gets the url that responded to the request.
        /// </summary>
        /// <value>The response URL.</value>
        public Uri ResponseUrl { get; private set; }

        /// <summary>
        /// Gets the mime type of the response.
        /// </summary>
        /// <value>The type of the response.</value>
        public string ResponseType { get; private set; }

        /// <summary>
        /// Gets the status description.
        /// </summary>
        /// <value>The status text.</value>
        public string StatusText { get; private set; }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets the response text.
        /// </summary>
        /// <value>The response text.</value>
        public string ResponseText { get; private set; }

        /// <summary>
        /// Gets the date of the last modification of the response.
        /// </summary>
        /// <value>The last modified.</value>
        public DateTime LastModified { get; private set; }

        /// <summary>
        /// Gets the current ready state.
        /// </summary>
        /// <value>The state of the ready.</value>
        public ReadyState ReadyState { get; private set; }

        /// <summary>
        /// Gets the (detected) response type.
        /// </summary>
        /// <value>The type of the response data.</value>
        public AjaxDataType ResponseDataType { get; private set; }

        /// <summary>
        /// Gets the current status of the web request.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        public bool Running { get; private set; }

        #endregion

        #region Static Methods

        /// <summary>
        /// Creates (i.e. spawns an instance and starts the request) a new AjaxRequest.
        /// </summary>
        /// <param name="options">An AjaxRequestOptions instance with all options set.</param>
        /// <returns>The AjaxRequest instance.</returns>
        public static AjaxRequest Create(AjaxRequestOptions options)
        {
            return new AjaxRequest(options).Invoke();
        }

        /// <summary>
        /// Creates (i.e. spawns an instance and starts the request) a new AjaxRequest.
        /// </summary>
        /// <param name="options">An anonymous object with all necessary options set.</param>
        /// <returns>The AjaxRequest instance.</returns>
        public static AjaxRequest Create(object options)
        {
            var opt = new AjaxRequestOptions();
            var oprops = opt.GetType().GetProperties();
            var props = options.GetType().GetProperties();

            foreach (var prop in props)
            {
                foreach (var oprop in oprops)
                {
                    if (prop.Name.Equals(oprop))
                    {
                        oprop.SetValue(opt, prop.GetValue(options, null), null);
                        break;
                    }
                }
            }

            return AjaxRequest.Create(opt);
        }

        #endregion
    }
}
