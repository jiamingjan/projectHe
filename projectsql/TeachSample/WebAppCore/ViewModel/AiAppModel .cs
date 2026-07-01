
namespace WebAppCore.ViewModels.DeepSeek
{
	public enum AiCompany
	{
		COM_DEEPSEEK = 0,		
		COM_AlICLOUD = 1, //阿里云百炼、千问
		COM_GPT = 2, //OPAI
	}

	public class DeepSeekConst
	{
		/// <summary>
		/// 领域——温度
		/// </summary>
		public static Dictionary<string, float> fieldTemps { get; set; }
			= new Dictionary<string, float>() {
				{"代码生成/数学解题",0.0f },
				{"数据抽取/分析",1.0f },
				{"通用对话/翻译",1.3f },
				{"创意类写作/诗歌创作",1.5f },
			};
		public static string BASE_URL = "https://api.deepseek.com/v1";
		public static string API_KEY = "sk-XXX"; // 替换为你的 API 密钥
		public static string API_URL = BASE_URL + "/chat/completions"; // 替换为实际的 API 端点

		public static string DEFAULT_MODEL = "deepseek-chat"; //deepseek-chat deepseek-coder  deepseek-reasoner
		public static string DEFAULT_ROLE = "user"; // 	
		public static float DEFAULT_TEMPERATURE = 0.7f; // 
	}

	public class GptConst
	{
		public static string BASE_URL = "https://yibuapi.com/v1";
		public static string API_KEY = WebAppCore.ViewModels.Claude.ClaudeConst.API_KEY; //和Claude 都用的中转:一步api(一个中转api）
		public static string API_URL = BASE_URL + "/chat/completions"; // 替换为实际的 API 端点

		public static string DEFAULT_MODEL = "gpt-4o-mini";
		public static string DEFAULT_ROLE = "user"; // 	
		public static float DEFAULT_TEMPERATURE = 0.7f; // 
	}

	public class AliCloudConst
	{		
		public static string BASE_URL = "https://dashscope.aliyuncs.com/compatible-mode/v1";
		public static string API_KEY = "sk-XXX";
		public static string API_URL = BASE_URL + "/chat/completions"; // 替换为实际的 API 端点

		public static string DEFAULT_MODEL = "qwen-vl-plus-latest";//"qwen-vl-plus";
		public static string DEFAULT_ROLE = "user"; // 	
		public static float DEFAULT_TEMPERATURE = 0.7f; // 
	}

	///////////////////////////////////////////////////////////////////////////////
	////// 下面是请求结构定义
	///////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// 下面是请求对话内容
	/// </summary>
	public class ReqMessage
	{
		/// <summary>
		/// role: 指定消息的角色，可能值为
		///	system: 设置对话的上下文或指示（如“您是帮助用户的助手”）
		///	user: 用户输入的内容（如“Hello!”）
		///	assistant: 模型的回复（通常由 API 自动生成，不需要手动设置）
		/// </summary>
		public string role { get; set; } //这里一定是小写

		/// <summary>
		/// content: 消息的具体内容。
		/// </summary>
		public string content { get; set; } //这里一定是小写	
		
	}

	public class Url
	{
		public string url { get; set; }
	}
	public class ImageContent
	{
		public string type { get; set; } //如果图像，则值为 image_url
		 //"image_url": {
   //       # 需要注意：传入Base64编码前需要增加前缀 data:image/{图片格式};base64,{Base64编码}：
   //       # PNG图片："url":  f"data:image/png;base64,{base64_image}"
   //       # JEPG图片："url":  f"data:image/jpeg;base64,{base64_image}"
   //       # WEBP图片："url":  f"data:image/webp;base64,{base64_image}"
   //       "url":  f"data:image/<IMAGE_FORMAT>;base64,{base64_image}
		public Url image_url { get; set; }

		//上传图片的同时，需要提问，这里是提问	
		public string text { get; set; } //这里一定是小写
	}

	public class ReqImageMessage
	{
		/// <summary>
		/// role: 指定消息的角色，可能值为
		///	system: 设置对话的上下文或指示（如“您是帮助用户的助手”）
		///	user: 用户输入的内容（如“Hello!”）
		///	assistant: 模型的回复（通常由 API 自动生成，不需要手动设置）
		/// </summary>
		public string role { get; set; } //这里一定是小写

		/// <summary>
		/// content: 消息的具体内容。
		/// </summary>
		public List<ImageContent> content { get; set; } //这里一定是小写
											 //
		
	}

	public class RequestImage
	{
		/// <summary>
		/// model是调用的模型
		/// </summary>
		//model = "deepseek-reasoner", // 调用 DeepSeek-R1
		//model = "deepseek-chat", // 调用 DeepSeek-V3
		//deepseek-coder 代码生成？
		public string model { get; set; }


		/// <summary>
		/// messages是一个数组，用于定义对话内容。
		/// </summary>
		public List<ReqImageMessage> messages { get; set; }


		/// <summary>
		/// temperature 参数默认为 1.0
		/// 建议您根据如下表格，按使用场景设置 temperature
		/// 场景					温度
		///	代码生成/数学解题   	0.0
		///	数据抽取/分析			1.0
		///	通用对话				1.3
		///	翻译					1.3
		///	创意类写作/诗歌创作		1.5
		/// </summary>
		public float temperature { get; set; }

		/// <summary>
		/// stream: 是否启用流式传输。默认为 false，表示不启用流式传输。如果设置为 true，API 会实时返回生成内容，适合需要实时Interaction的场景
		/// </summary>
		public bool stream { get; set; } = false;

		//如未指定 max_tokens，默认最大输出长度为 4K。请调整 max_tokens 以支持更长的输出
		public long max_tokens { get; set; }
		//其他还有许多参数这里略
		//max_tokens stop top_p top_k frequency_penalty n response_format tools
	}

	public class Request
	{
		/// <summary>
		/// model是调用的模型
		/// </summary>
		//model = "deepseek-reasoner", // 调用 DeepSeek-R1
		//model = "deepseek-chat", // 调用 DeepSeek-V3
		//deepseek-coder 代码生成？
		public string model { get; set; }


		/// <summary>
		/// messages是一个数组，用于定义对话内容。
		/// </summary>
		public List<ReqMessage> messages { get; set; }


		/// <summary>
		/// temperature 参数默认为 1.0
		/// 建议您根据如下表格，按使用场景设置 temperature
		/// 场景					温度
		///	代码生成/数学解题   	0.0
		///	数据抽取/分析			1.0
		///	通用对话				1.3
		///	翻译					1.3
		///	创意类写作/诗歌创作		1.5
		/// </summary>
		public float temperature { get; set; }

		/// <summary>
		/// stream: 是否启用流式传输。默认为 false，表示不启用流式传输。如果设置为 true，API 会实时返回生成内容，适合需要实时Interaction的场景
		/// </summary>
		public bool stream { get; set; } = false;

		//如未指定 max_tokens，默认最大输出长度为 4K。请调整 max_tokens 以支持更长的输出
		public long max_tokens { get; set; }
		//其他还有许多参数这里略
		//max_tokens stop top_p top_k frequency_penalty n response_format tools
	}




	///////////////////////////////////////////////////////////////////////////////
	////// 下面是返回结构定义
	///////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// 
	/// </summary>
	public class Response
	{
		public string Id { get; set; }
		public string Object { get; set; }
		public long Created { get; set; }
		public string Model { get; set; }
		public List<Choice> Choices { get; set; }
		public Usage Usage { get; set; }
		public string SystemFingerprint { get; set; }

		// 重写ToString方法以便更好地显示对象信息
		public override string ToString()
		{
			return $"DeepSeekResponse(Id={Id}, Object={Object}, Created={Created}, Model={Model}, Choices={string.Join(", ", Choices)}, Usage={Usage}, SystemFingerprint={SystemFingerprint})";
		}
	}

	public class Choice
	{
		public int Index { get; set; }
		public Message Message { get; set; }
		// 其他Choice相关的属性...

		// 重写ToString方法以便更好地显示Choice信息（这里仅展示Index和Message作为示例）
		public override string ToString()
		{
			return $"Choice(Index={Index}, Message={Message})";
		}
	}

	public class Message
	{
		public string Role { get; set; }
		public string Content { get; set; }
		// 其他Message相关的属性...
	}

	public class Usage
	{
		public int PromptTokens { get; set; }
		public int CompletionTokens { get; set; }
		public int TotalTokens { get; set; }
		// 其他Usage相关的属性，包括嵌套的字典等，可以根据需要添加
	}
}