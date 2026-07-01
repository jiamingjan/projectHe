using System.Text.Json;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;
using Service;
using IRepository;
using System.Linq.Expressions;
using WebAppCore.DbExtensions;
using AutoMapper;
using MyTool;
using SixLabors.ImageSharp.Formats.Gif;
using System.Security.Cryptography;
using System.Text;
using NPOI.HSSF.Record;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Newtonsoft.Json;
using Repository;
using System.Net.Http.Headers;
using WebAppCore.ViewModels.DeepSeek;
//using Newtonsoft.Json;


namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public class AiAppService : IAiAppService
	{  		
        public AiAppService()
        {       
        }

		public async Task<string> CallAiApi(AiCompany company, int model, string question, string imagePath = null)
		{
			VueResMsg<string> res = new VueResMsg<string>();
			try
			{
				using (var client = new HttpClient())
				{					
					string resData = "";
					var jsonString = "";
					var url = "";
					string desc = "";
					string apiKey = "";
					
					if (company == AiCompany.COM_DEEPSEEK)
					{
						url = DeepSeekConst.API_URL;
						jsonString = buildDeepSeekRequestBody(model,question);// 构建请求体
						desc = "DeepSeek";
						apiKey = DeepSeekConst.API_KEY;
					}
					else if (company == AiCompany.COM_GPT)
					{
						url = GptConst.API_URL;
						jsonString = buildGtpRequestBody(question);// 构建请求体
						desc = "Gpt";
						apiKey = GptConst.API_KEY;
					}
					else if (company == AiCompany.COM_AlICLOUD) //这里专门弄图像
					{
						url = AliCloudConst.API_URL;
						if(string.IsNullOrEmpty(imagePath))
							jsonString = this.buildAliCloudRequestBody(question);// 构建请求体						
						else
							jsonString = this.buildAliCloudImageRequestBody(question,imagePath);// 构建图像请求体

						desc = "AliYun";
						apiKey = AliCloudConst.API_KEY;
					}
					

					// 设置请求头
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

					// 发送 POST 请求
					var response = await client.PostAsync(url, content);

					if (response.IsSuccessStatusCode)
					{
						//return await response.Content.ReadAsStringAsync();
						var responseContent = await response.Content.ReadAsStringAsync();
						var resultModel = JsonConvert.DeserializeObject<Response>(responseContent);
						if (resultModel != null && resultModel.Choices.Count > 0)
						{
							StringBuilder sb = new StringBuilder();
							for (int i = 0; i < resultModel.Choices.Count; i++)
								sb.Append(resultModel.Choices[i].Message.Content);
							resData = sb.ToString();
						} 
						else
							resData = await response.Content.ReadAsStringAsync();
						res.SetOK();
						res.data = resData;
					}
					else
					{
						resData = $"{desc} Api 请求失败: {response.StatusCode}";
						res.SetFail((int)response.StatusCode, $"{desc} Api 请求失败");
					}
				}
			}
			catch(Exception ex) {
				res.SetFail(-1, $" Api 请求失败:{ex.Message}");
			}
			return JsonConvert.SerializeObject(res);
		}

		private string buildDeepSeekRequestBody(int model, string question)
		{
			var requestBody = new Request();
			if(model == 0)
				requestBody.model = DeepSeekConst.DEFAULT_MODEL;
			else
				requestBody.model = "deepseek-reasoner";
			requestBody.temperature = DeepSeekConst.DEFAULT_TEMPERATURE;
			requestBody.max_tokens =  1000;
			ReqMessage message = new ReqMessage();
			message.role = DeepSeekConst.DEFAULT_ROLE;
			message.content = question;
			requestBody.messages = new List<ReqMessage>();
			requestBody.messages.Add(message);

			var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
			return jsonString;
		}

		// 构建请求体	
		private string buildGtpRequestBody(string question)
		{
			var requestBody = new Request(); //这个共用
			requestBody.model = GptConst.DEFAULT_MODEL;
			requestBody.temperature = GptConst.DEFAULT_TEMPERATURE;
			requestBody.max_tokens = 1000;
			ReqMessage message = new ReqMessage();
			message.role = GptConst.DEFAULT_ROLE;
			message.content = question;
			requestBody.messages = new List<ReqMessage>();
			requestBody.messages.Add(message);

			var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
			return jsonString;
		}

		// 构建请求体	
		private string buildAliCloudRequestBody(string question)
		{
			var requestBody = new Request(); //这个共用
			requestBody.model = AliCloudConst.DEFAULT_MODEL;
			requestBody.temperature = AliCloudConst.DEFAULT_TEMPERATURE;
			requestBody.max_tokens = 1000;
			ReqMessage message = new ReqMessage();
			message.role = AliCloudConst.DEFAULT_ROLE;
			message.content = question;
			requestBody.messages = new List<ReqMessage>();
			requestBody.messages.Add(message);

			var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
			return jsonString;
		}

		// 构建阿里图像请求体	
		private string buildAliCloudImageRequestBody(string question, string imagePath)
		{
			var requestBody = new RequestImage(); //这个共用
			requestBody.model = "qwen-vl-max-latest";
			requestBody.temperature = AliCloudConst.DEFAULT_TEMPERATURE;
			requestBody.max_tokens = 1000;
			ReqImageMessage message = new ReqImageMessage();
			message.role = AliCloudConst.DEFAULT_ROLE;
			message.content = new List<ImageContent>();
			ImageContent image = new ImageContent();
			image.type = "image_url";
			image.image_url = new Url();
			string base64Image = Convert.ToBase64String(File.ReadAllBytes(imagePath)); // 将图片文件转换为Base64字符串
			
			string extension = Path.GetExtension(imagePath);
			// 移除开头的点，如果需要的话
			string cleanExtension = extension.TrimStart('.');
			string format = cleanExtension;
			if (cleanExtension.ToLower().Equals("jpg"))
				format = "jpeg";
			
			image.image_url.url = "data:image/"+format+";base64,"+ base64Image;
			message.content.Add(image);			

			ImageContent imgQuestion = new ImageContent();
			imgQuestion.type = "text";
			imgQuestion.text = question;
			message.content.Add(imgQuestion);

			requestBody.messages = new List<ReqImageMessage>();
			requestBody.messages.Add(message);

			var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
			return jsonString;
		}

	}
}