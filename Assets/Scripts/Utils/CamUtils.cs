using UnityEngine;

namespace Utils
{
	public static class CamUtils
	{
		public static float GetHighestPoint(Camera camera) 
			=> camera.orthographicSize;
		
		public static float GetWidthestPoint(Camera camera) 
			=> (float)Screen.width / Screen.height * camera.orthographicSize;
	}
}