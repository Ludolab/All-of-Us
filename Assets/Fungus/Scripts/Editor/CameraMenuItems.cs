// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Fungus.EditorUtils
{
    public class CameraMenuItems 
    {
        [MenuItem("Tools/Fungus/Create/View", false, 100)]
        static void CreateView()
        {
            FlowchartMenuItems.SpawnPrefab("View");
        }
    }
}