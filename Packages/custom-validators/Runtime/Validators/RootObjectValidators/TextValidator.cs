#if UNITY_EDITOR
using LeKirschbaum.CustomValidators.Runtime.RootObjectValidators;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine.UI;

[assembly: RegisterValidationRule(typeof(TextValidator), Name = "Text (Legacy) Validator", Description = "Validator for the legacy text component.")]

namespace LeKirschbaum.CustomValidators.Runtime.RootObjectValidators
{
    public class TextValidator : RootObjectValidator<Text>
    {
        [EnumToggleButtons]
        public ValidatorSeverity RaycastTargetSeverity;
        public ValidatorSeverity BestFitSeverity;

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

            if (obj.resizeTextForBestFit)
            {
                result.Add(BestFitSeverity, "Best Fit is enabled on this text. Disabling it improves the performance.")
                    .WithFix(() => obj.resizeTextForBestFit = false);
            }
        }
    }
}
#endif