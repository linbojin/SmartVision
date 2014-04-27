using System;
using System.Collections;

namespace IPCamera
{
	/// <summary>
	/// ViewCollection 页面集合类
	/// </summary>
	public class ViewCollection : CollectionBase
	{
        // 根据index查询页面
		public View this[int index]
		{
			get
			{
				return ((View) InnerList[index]);
			}
		}

        // 根据名字获得页面
        public View GetView(string name)
        {
            foreach (View view in InnerList)
            {
                if ((view.Name == name))
                    return view;
            }
            return null;
        }

		// 把新页面加到集合中
		public void Add(View view)
		{
			InnerList.Add(view);
		}

        // 把页面从集合中移除
		public void Remove(View view)
		{
			InnerList.Remove(view);
		}

	}
}
