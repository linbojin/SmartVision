using System;

namespace IPCamera
{
	/// <summary>
	/// IWizardPage - 向导页面接口
	/// </summary>
	public interface IWizardPage
	{
        //状态改变事件
		event EventHandler StateChanged;

		//信息重置事件
		//event EventHandler Reset;

        //页面名字
		string PageName { get; }

		//描述属性
		string PageDescription { get; }

		// 完成，当页面设置完成，可以进入下一页
		bool Completed { get; }

        // 呈现页面
		void Display();
        
        // 应用配置
		bool Apply();
	}
}
