#if UNITY_EDITOR
using System.IO;
using LeKirschbaum.CustomValidators.ValueValidators;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;
using UnityEditor;

// Currently not working, hoping to get it working in the near future.

//[assembly: RegisterValidationRule(typeof(CameraMainValidator), Name = "CameraMainValidator", Description = "Some description text.")]

//namespace LeKirschbaum.CustomValidators.ValueValidators
//{
//    public class CameraMainValidator : ValueValidator<MonoBehaviour>
//    {
//        [EnumToggleButtons] public ValidatorSeverity CameraMainSeverity;

//        protected override void Validate(ValidationResult result)
//        {
//            var obj = this.Value;

//            if (obj == null)
//                return;

//            string[] guids = AssetDatabase.FindAssets("t:TextAsset", new string[] { "Assets/Scripts" });

//            foreach (string guid in guids)
//            {
//                string path = AssetDatabase.GUIDToAssetPath(guid);

//                if (!path.EndsWith(".cs"))
//                    continue;

//                StreamReader reader = new StreamReader(path);

//                while (reader.Peek() >= 0)
//                {
//                    string line = reader.ReadLine();

//                    if (line.Contains("Camera.main"))
//                    {
//                        //if (obj.gameObject.GetComponent<MonoBehaviour>() == AssetDatabase.LoadAssetAtPath(path, typeof(MonoBehaviour)))
//                        //{
//                        //    result.Add(CameraMainSeverity,
//                        //        "You are using Camera.Main, this is soo bad! This will cause a memory leak!");
//                        //}

//                        Object test = AssetDatabase.LoadAssetAtPath(path, typeof(MonoScript));

//                        if (test.name == obj.gameObject.GetComponent<MonoBehaviour>().name)
//                        {
//                            result.Add(CameraMainSeverity,
//                                "You are using Camera.Main, this is soo bad! This will cause a memory leak!");
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
#endif