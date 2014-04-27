using System;


namespace IPCamera
{
	/// <summary>
	/// View 视图类
	/// </summary>
	public class View
	{
		private int		id = 0;
		private string	name;
		private string	description = "";

		private short	cols = 2;
		private short	rows = 2;
		private short	cellWidth = 320;
		private short	cellHeight = 240;

		private int[,]	cameraIDs = new int[3, 3];

        public const int MaxRows = 3;
        public const int MaxCols = 3;

		// ID 编号属性
		public int ID
		{
			get { return id; }
			set { id = value; }
		}	

		// Name 名字属性
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		// ID 描述属性
		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		// Cols 列属性
		public short Cols
		{
			get { return cols; }
            set { cols = Math.Max((short)1, Math.Min((short)MaxCols, value)); }
		}

		// Rows 行属性
		public short Rows
		{
			get { return rows; }
			set { rows = Math.Max((short) 1, Math.Min((short)MaxRows, value)); }
		}

        // CellWidth 子页面宽 50~800
		public short CellWidth 
		{
			get { return cellWidth; }
			set { cellWidth = Math.Max((short) 50, Math.Min((short) 800, value)); }
		}

        // CellHeight 子页面高 50~800
		public short CellHeight
		{
			get { return cellHeight; }
			set { cellHeight = Math.Max((short) 50, Math.Min((short) 800, value)); }
		}
       
        /// <summary>
        /// 方法部分
        /// </summary>
		// 构造函数
		public View(string name)
		{
			this.name = name;
		}

		// 设置摄像头与子页面对应
		public void SetCamera(int row, int col, int cameraID)
		{
			cameraIDs[row, col] = cameraID;
		}

		// 根据行列定位摄像头
		public int GetCamera(int row, int col)
		{
			if ((row >= 0) && (col >= 0) && (row < MaxRows) && (col < MaxCols))
			{
				return cameraIDs[row, col];
			}
			return -1;
		}
	}
}
