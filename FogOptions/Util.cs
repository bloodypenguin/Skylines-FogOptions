using UnityEngine;

namespace FogOptions
{
    public static class Util
    {
        public static MonoBehaviour GetCameraBehaviour(string name)
        {
            var cameraBehaviours = Camera.main.GetComponents<MonoBehaviour>();
            for (int i = 0; i < cameraBehaviours.Length; i++)
            {
                if (cameraBehaviours[i].GetType().Name == name)
                {
                    return cameraBehaviours[i];
                }
            }
            return null;
        }
    }
}