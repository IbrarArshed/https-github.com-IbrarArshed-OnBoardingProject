using System;

namespace FlexiSchools.Core.Wrapper
{
    public class CustomApiResponse
    {
        /// <summary>
        /// Gets or sets the HttpCode.
        /// </summary>
        public int HttpCode { get; set; }
        public string HttpMessage { get; set; }
        public object Payload { get; set; }
        public DateTime SentDate { get; set; }


        public CustomApiResponse()
        {

        }

        public CustomApiResponse(object payload)
        {
            this.HttpCode = (int)System.Net.HttpStatusCode.OK;
            this.Payload = payload;
        }

        public CustomApiResponse(
            DateTime sentDate,
            object payload = null,
            string message = "",
            int statusCode = 200)
        {
            this.HttpCode = statusCode;
            this.HttpMessage = message;
            this.Payload = payload;
            this.SentDate = sentDate;
        }
    }
}
