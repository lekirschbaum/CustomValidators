#if UNITY_EDITOR
using LeKirschbaum.CustomValidators.RootObjectValidators;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;
using Sirenix.OdinInspector;

[assembly: RegisterValidationRule(typeof(AnimatorValidator), Name = "Animator Validator", Description = "Validator for the Animator component.")]

namespace LeKirschbaum.CustomValidators.RootObjectValidators
{
    public class AnimatorValidator : RootObjectValidator<Animator>
    {
        [EnumToggleButtons]
        public ValidatorSeverity AnimatorSeverity;
        
        protected override void Validate(ValidationResult result)
        {
            var obj = this.Object;

            if (obj == null)
                return;

            if (obj.transform.parent == null)
                return;

            if (obj.transform.GetComponentInParent<Canvas>())
            {
                if (obj.enabled)
                {
                    //result.Add(AnimatorSeverity,
                    //    "Animating UI with the Unity Animator costs a lot of performance, due to dirtying the canvas. Use a tweener like <a href=\"http://dotween.demigiant.com/index.php\">Dotween</a>.");

                    result.Add(AnimatorSeverity,
                            "Animating UI with the Unity Animator costs a lot of performance, due to dirtying the canvas. Use a tweener like Dotween.")
                        .WithFix(() => CustomFix(obj));
                }
            }
        }

        private void CustomFix(Animator animator)
        {
            animator.enabled = false;   // Hopefully a future fix, where the component can be deleted without any issues.

            Application.OpenURL("http://dotween.demigiant.com/index.php");
        }
    }
}
#endif