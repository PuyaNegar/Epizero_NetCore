using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Functions;
using Common.Objects;
using Newtonsoft.Json;

namespace Common.Service
{
	public class SmsService : IDisposable
	{
		private WebClient _client;
		//******************************************************************************************************************** 
		public SmsService()
		{
			_client = new WebClient();
			_client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
		}
		//******************************************************************************************************************** 
		string GetApiKey()
		{
			return AppConfigProvider.GetSmsApiKey();
		}
		//******************************************************************************************************************** 
		public SysResult Send(string MobileNumber, string Message)
		{
			try
			{
				string urlPrefix = "https://api.kavenegar.com/v1/" + GetApiKey() + "/sms/send.json";
				var strResult = _client.UploadString(urlPrefix, "post", SmsResquestGenarator(MobileNumber, Message));
				string smsResponse = "";
				return new SysResult()
				{
					IsSuccess = true,
					Message = "sms با موفقیت ارسال گردید",
					Value = smsResponse
				};
			}
			catch (WebException ex)
			{
				var responseStream = new System.IO.StreamReader(ex.Response.GetResponseStream());
				return new SysResult() { IsSuccess = false, Message = "سیستم با خطا مواجه شد", Value = responseStream.ReadToEnd() };
			}
		}
		//******************************************************************************************************************** 
		public SysResult Send(List<string> MobileNumbers, string Message, long? unixDateTime)
		{
			try
			{
				string urlPrefix = "https://api.kavenegar.com/v1/" + GetApiKey() + "/sms/sendarray.json";
				var strResult = _client.UploadString(urlPrefix, "post", SmsResquestGenarator(MobileNumbers, Message, unixDateTime));
				string smsResponse = "";
				return new SysResult()
				{
					IsSuccess = true,
					Message = "sms با موفقیت ارسال گردید",
					Value = smsResponse
				};
			}
			catch (WebException ex)
			{
				var responseStream = new System.IO.StreamReader(ex.Response.GetResponseStream());
				return new SysResult() { IsSuccess = false, Message = "سیستم با خطا مواجه شد", Value = responseStream.ReadToEnd() };
			}
		}
		//******************************************************************************************************************** 
		public SysResult SendWithTemplate(string MobileNumber, string Templete, string Token_1, string Token_10 = null, string Token_20 = null, string Token_2 = null, string Token_3 = null)
		{
			try
			{
				string a = "https://api.kavenegar.com/v1/" + GetApiKey() + "/verify/lookup.json";
				var strResult = _client.UploadString(a, "post", SmsResquestGenarator(MobileNumber, Templete, Token_1, Token_10, Token_20, Token_2, Token_3));
				string smsResponse = "";
				return new SysResult()
				{
					IsSuccess = true,
					Message = "sms با موفقیت ارسال گردید",
					Value = smsResponse
				};
			}
			catch (WebException ex)
			{
				var responseStream = new System.IO.StreamReader(ex.Response.GetResponseStream());
				return new SysResult() { IsSuccess = false, Message = "سیستم با خطا مواجه شد", Value = responseStream.ReadToEnd() };
			}
		}
		//******************************************************************************************************************** 
		public static string GetSmsStatusText(int statusCode)
		{
			string reusltText;
			switch (statusCode)
			{
				case 1:
					reusltText = "در صف ارسال قرار گرفت";
					break;
				case 2:
					reusltText = "زمانبندی انجام شد";
					break;
				case 4:
					reusltText = "به مخابرات ارسال شد";
					break;
				case 10:
					reusltText = "پیام با موفقیت تحویل داده شد";
					break;
				case 11:
					reusltText = "به مخابرات ارسال شد";
					break;
				case 14:
					reusltText = "گیرنده بلاک شده است";
					break;
				case 100:
					reusltText = "شناسه پیامک نا معتبر هست";
					break;
				default:
					reusltText = "وضعیت برگشتی ناشناخته می باشد";
					break;
			}
			return reusltText;
		}
		//******************************************************************************************************************** 
		string SmsResquestGenarator(string MobileNumber, string Message)
		{
			var str = $"receptor={MobileNumber}&sender={AppConfigProvider.GetSmsSenderLine()}&message={Message}";
			return str;
		}

		//******************************************************************************************************************** 
		string SmsResquestGenarator(List<string> MobileNumbers, string Message, long? unixDateTime)
		{
			var obj = new GroupSmsObject() { message = new List<string>(), sender = new List<string>(), receptor = new List<string>() };
			foreach (var mobileNumber in MobileNumbers)
			{
				obj.receptor.Add(mobileNumber);
				obj.sender.Add(AppConfigProvider.GetSmsSenderLine());
				obj.message.Add(Message);

			}
			var data = new List<KeyValuePair<string, string>>
			{
			   new KeyValuePair<string, string>("receptor", JsonConvert.SerializeObject( obj.receptor)),
			   new KeyValuePair<string, string>("sender", JsonConvert.SerializeObject( obj.sender)),
			   new KeyValuePair<string, string>("message", JsonConvert.SerializeObject( obj.message)),
			};
			if (unixDateTime != null)
				data.Add(new KeyValuePair<string, string>("date", unixDateTime.ToString()));
			return new FormUrlEncodedContent(data).ReadAsStringAsync().Result;

		}
		//******************************************************************************************************************** 
		string SmsResquestGenarator(string MobileNumber, string Templete, string Token_1, string Token_10, string Token_20, string Token_2, string Token_3)
		{
			var str = $"receptor={MobileNumber}&token={Token_1}&template={Templete}";
			if (!string.IsNullOrEmpty(Token_10))
				str += $"&token10={Token_10}";
			if (!string.IsNullOrEmpty(Token_20))
				str += $"&token20={Token_20}";
			if (!string.IsNullOrEmpty(Token_2))
				str += $"&token2={Token_2}";
			if (!string.IsNullOrEmpty(Token_3))
				str += $"&token3={Token_3}";
			return str;
		}
		//******************************************************************************************************************** 
		#region DisposeObject
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//******************************************************************************************************************** 
		protected virtual void Dispose(bool disposing)
		{
			_client?.Dispose();
		}
		#endregion
		//******************************************************************************************************************** 
	}
}