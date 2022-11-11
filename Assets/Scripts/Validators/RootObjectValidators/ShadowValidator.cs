#if UNITY_EDITOR
using LeKirschbaum.CustomValidators.RootObjectValidators;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine.UI;

[assembly: RegisterValidationRule(typeof(ShadowValidator), Name = "Shadow Validator", Description = "Validator for the Shadow component.")]

namespace LeKirschbaum.CustomValidators.RootObjectValidators
{
    public class ShadowValidator : RootObjectValidator<Shadow>
    {
        [EnumToggleButtons]
        public ValidatorSeverity ShadowSeverity;

        protected override void Validate(ValidationResult result)
        {
            var obj = this.Object;

            if (obj == null)
                return;

            if (obj.enabled && obj.GetType() != typeof(Outline))  // Type check, because Outline inherits from Shadow, thus no double errors. 
            {
                result.Add(ShadowSeverity, "Shadow component enabled, this can cause severe performance issues.")
                    .WithFix(() => obj.enabled = false);
            }
        }
    }
}
#endif