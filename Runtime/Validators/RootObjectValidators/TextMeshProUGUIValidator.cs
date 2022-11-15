#if UNITY_EDITOR
using LeKirschbaum.CustomValidators.Runtime.RootObjectValidators;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;
using TMPro;

[assembly: RegisterValidationRule(typeof(TextMeshProUGUIValidator), Name = "Text (TMP) Validator", Description = "Validator for the TextMeshProGUI component.")]

namespace LeKirschbaum.CustomValidators.Runtime.RootObjectValidators
{
    public class TextMeshProUGUIValidator : RootObjectValidator<TextMeshProUGUI>
    {
        [EnumToggleButtons]
        public ValidatorSeverity RaycastTargetSeverity;
        public ValidatorSeverity AutoSizeSeverity;
        public ValidatorSeverity ShaderSeverity;

        protected override void Validate(ValidationResult result)
        {
            var obj = this.Object;

            if (obj == null)
                return;

            if (obj.raycastTarget)
            {
                result.Add(RaycastTargetSeverity,
                        "Raycast Target is enabled on this text. Disabling it slightly improves the performance.")
                    .WithFix(() => obj.raycastTarget = false);
            }

            if (obj.enableAutoSizing)
            {
                result.Add(AutoSizeSeverity, "Auto Size is enabled on this text. Disabling it improves the performance.")
                    .WithFix(() => obj.enableAutoSizing = false);
            }

            if (obj.materialForRendering.shader == Shader.Find("TextMeshPro/Distance Field"))
            {
                result.Add(ShaderSeverity,
                        "Desktop version of the shader is being used, changing to the less demanding mobile version, which support less effects, increases the performance.")
                    .WithMetaData("Current shader in use:", obj.materialForRendering.shader)
                    .WithFix(() => obj.materialForRendering.shader = Shader.Find("TextMeshPro/Mobile/Distance Field"));
            }
        }
    }
}
#endif