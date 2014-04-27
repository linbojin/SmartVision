using System;
using System.Collections;


namespace IPCamera
{
	/// <summary>
    /// CameraCollection 视频集合类 
	/// </summary>
	public class CameraCollection : CollectionBase
	{
        // 根据index查询Camera
		public Camera this[int index]
		{
			get
			{
				return ((Camera) InnerList[index]);
			}
		}

        // 根据名字获得camera    
        public Camera GetCamera(string name)
        {
            foreach (Camera camera in InnerList)
            {
                if ((camera.Name == name))
                    return camera;
            }
            return null;
        }

        // 根据cameraID获得camera
        public Camera GetCamera(int cameraID)
        {
            foreach (Camera camera in InnerList)
            {
                if (camera.ID == cameraID)
                    return camera;
            }
            return null;
        }

		// 把camera加到集合中
		public void Add(Camera camera)
		{
			InnerList.Add(camera);
		}

        // 把camera从集合中移除
		public void Remove(Camera camera)
		{
			InnerList.Remove(camera);
		}


	}
}
