#if UNITY_EDITOR
using LeKirschbaum.CustomValidators.RootObjectValidators;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine.UI;

[assembly: RegisterValidationRule(typeof(OutlineValidator), Name = "Outline Validator", Description = "Validator for the Outline component.")]

namespace LeKirschbaum.CustomValidators.RootObjectValidators
{
    public class OutlineValidator : RootObjectValidator<Outline>
    {
        [EnumToggleButtons]
        public ValidatorSeverity OutlineSeverity;

        protected override void Validate(ValidationResult result)
        {
            var obj = this.Object;

            if (obj == null)
                return;

            if (obj.enabled)
            {
                result.Add(OutlineSeverity, "Outline component enabled, this can cause severe performance issues.")
                    .WithFix(() => obj.enabled = false);
            }
        }
    }
}
#endif