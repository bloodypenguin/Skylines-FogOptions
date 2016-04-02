using System.Linq;
using UnityEngine;

namespace FogOptions
{
    public static class Util
    {
        public static MonoBehaviour GetCameraBehaviour(string name)
        {
            var cameraBehaviours = Camera.main.GetComponents<MonoBehaviour>();
            return cameraBehaviours.FirstOrDefault(t => t.GetType().Name == name);
        }
    }
}