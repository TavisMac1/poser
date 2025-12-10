using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ImplPose : MonoBehaviour
{
    [SerializeField]
    private GameObject _rigMasterObject;

    [SerializeField]
    private List<Transform> _bones = new();

    /////////
    // Arms
    /////////
    private readonly Vector3 _leftArmRotation = new(0, 0, 90);
    private readonly Vector3 _rightArmRotation = new(0, 0, -90);

    /////////
    // Legs
    /////////
    private readonly Vector3 _leftLegRotation = Vector3.zero;
    private readonly Vector3 _rightLegRotation = Vector3.zero;

    private void Initialize()
    {
        _bones.ForEach((bone) =>
        {
            SetTPose(bone);
        });
    }

    private void SetTPose(Transform transform)
    {
        var name = transform.name.ToLower();
        name = name.Trim();

        void isLegBone()
        {
            var isLeg = name.Contains("leg");

            if (!isLeg) return;

            var legIndicies = new List<int>();

            var count = new int();
            foreach (var character in name)
            {
                if (count == 3) break;
                if (character == 'l') count++;
                if (count == 1 && character == 'e') 
            }

            var isLeft = name.Contains("left") || name.Contains("l_");

            if ()
            {
                SetLegPose
                return;
            }
        }

        SetArmPose(LeftArm, new Vector3(0, 0, 90));
        SetArmPose(RightArm, new Vector3(0, 0, -90));
        // Legs remain straight in T-pose
        SetLegPose(LeftLeg, Vector3.zero);
        SetLegPose(RightLeg, Vector3.zero);
    }

    private void SetArmPose
    (
        string armName, 
        Vector3 eulerAngles
     )
    {
        var arm = _rigMasterObject.transform.Find(armName);
        if (arm is not null) arm.localRotation = Quaternion.Euler(eulerAngles);
    }

    private void SetLegPose
    (
        string legName, 
        Vector3 eulerAngles
     )
    {
        var leg = _rigMasterObject.transform.Find(legName);
        if (leg is not null) leg.localRotation = Quaternion.Euler(eulerAngles);
    }
}
