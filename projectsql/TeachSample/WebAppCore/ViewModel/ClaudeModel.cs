
namespace WebAppCore.ViewModels.Claude
{
	public class ClaudeConst
	{

		public static string BASE_URL = "https://yibuapi.com/v1";
		public static string API_KEY = "sk-uykEn5orVPXkRgUy6wzHkXFS4DR8f4DJX0uSPBgP9eaVODlA"; // 替换为你的 API 密钥	
		public static string DEFAULT_MODEL = "claude-3-7-sonnet-latest";
		public static string DEFAULT_ROLE = "user"; // 	
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

	public class ClaudeRequest
	{
		/// <summary>
		/// model是调用的模型
		/// </summary>
		//model = "claude-3-7-sonnet-latest"还有其他版本
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

		//其他还有许多参数这里略
		//max_tokens stop top_p top_k frequency_penalty n response_format tools
	}




	///////////////////////////////////////////////////////////////////////////////
	////// 下面是返回结构定义
	///////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// 
	/// </summary>
	public class ClaudeResponse
	{
		public string id { get; set; }
		public string type { get; set; } //"message"
		public string role { get; set; }//"assistant"
		public string model { get; set; }
		public List<Choice> content { get; set; }
		public Usage usage { get; set; }
		public string stop_reason { get; set; }

		// 重写ToString方法以便更好地显示对象信息
		public override string ToString()
		{
			return $"ClaudeResponse(Id={id}, type={type}, role={role}, model={model}, content={string.Join(", ", content)}, usage={usage}, stop_reason={stop_reason})";
		}
	}

	public class Choice
	{
		public string type { get; set; }//"text"
		public string text { get; set; }
		// 其他Choice相关的属性...

		// 重写ToString方法以便更好地显示Choice信息（这里仅展示Index和Message作为示例）
		public override string ToString()
		{
			return $"Choice(type={type}, text={text})";
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
		public int input_tokens { get; set; }
		public int cache_creation_input_tokens { get; set; }
		public int cache_read_input_tokens { get; set; }
		public int output_tokens { get; set; }
		// 其他Usage相关的属性，包括嵌套的字典等，可以根据需要添加
	}
}