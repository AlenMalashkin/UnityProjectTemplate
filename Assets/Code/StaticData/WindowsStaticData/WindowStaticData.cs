using Code.UI.Windows;
using UnityEngine;

namespace Code.StaticData.WindowsStaticData
{
    [CreateAssetMenu(fileName = "Window", menuName = "Window Static Data", order = 0)]
    public class WindowStaticData : ScriptableObject
    {
        [SerializeField] private WindowType type;
        [SerializeField] private WindowBase template;

        public WindowType Type => type;
        public WindowBase Template => template;
    }
}