#if UNITY_EDITOR
using System.Collections.Generic;
using LeKirschbaum.CustomValidators.Runtime.RootObjectValidators;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;
using Sirenix.OdinInspector;

[assembly: RegisterValidationRule(typeof(ChildCountValidator), Name = "Child Count Validator", Description = "Validator that checks the amount of children for GameObjects.")]

namespace LeKirschbaum.CustomValidators.Runtime.RootObjectValidators
{
    public class ChildCountValidator : RootObjectValidator<GameObject>
    {
        public int ChildCountLimit = 50;

        [EnumToggleButtons]
        public ValidatorSeverity ChildCountSeverity;

        protected override void Validate(ValidationResult result)
        {
            var obj = this.Object;

            if (obj.transform.parent == null)
                return;

            if (obj == null)
                return;

            if (obj.transform.GetComponentInParent<Canvas>())
            {
                if (obj.transform.childCount > ChildCountLimit)
                {
                    result.Add(ChildCountSeverity,
                            "This object has a lot of children, if this is intentional I suggest to use Object Pooling to improve performance. Otherwise reduce the child count to improve performance as well.")
                        .WithFix((FixArgs args) => CustomFix(args.childrenToDelete));
                }
            }
        }

        private void CustomFix(List<GameObject> childrenToDelete)
        {
            foreach (GameObject g in childrenToDelete)
            {
                UnityEngine.Object.DestroyImmediate(g);
            }
        }

        public class FixArgs
        {
            public List<GameObject> childrenToDelete;
        }
    }
}
#endif