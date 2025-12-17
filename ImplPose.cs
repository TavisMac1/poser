using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

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

    private void Start() => Initialize();

    private void Initialize()
    {
        _bones.ForEach((bone) =>
        {
            SetBone(bone);
        });
    }

    private void SetBone
    (
        Transform boneName
     )
    {
        var name = transform.name.ToLower();
        name = name.Trim();

        var isLeg = name.Contains("leg");
        var isArm = name.Contains("arm");

        if (!isLeg & !isLeg) return;

        var boneIndicies = new List<int>();

        char[] legArr = new char[] {'l', 'e', 'g'};
        char[] armArr = new char[] { 'a', 'r', 'm' };

        var count = new int();
        for (var i = 0; i < name.Count(); i++)
        {
            var n = name[i];
            if (count == 3) break;

            if (n.Equals(legArr[0]) || n.Equals(armArr[0]))
            {
                count++;
                boneIndicies.Add(i);
            }
            if (count == 1)
                if (n.Equals(legArr[1]) || n.Equals(armArr[1]))
                {
                    count++;
                    boneIndicies.Add(i);
                }
            if (count == 2)
                if (n.Equals(legArr[2]) || n.Equals(armArr[2]))
                {
                    count++;
                    boneIndicies.Add(i);
                    break;
                }
        }

        if (boneIndicies.Count != 3) return;

        for (var i = 0; i < boneIndicies.Count; i++) name.Remove(boneIndicies[i]);

        name = RemoveSpecChar(name);

        var isLeft = name.Contains("left") || name.Contains("l");

        var isRight = false;
        if (!isLeft) isRight = name.Contains("right") || name.Contains("r");

        if (!isRight) return;

        if (isArm)
            if (isRight) SetArmPose(boneName.name, _rightArmRotation);
            else SetArmPose("", _leftArmRotation);
        if (isLeg)
            if (isRight) SetLegPose(boneName.name, _rightLegRotation);
            else SetLegPose("", _leftLegRotation);
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

    private string RemoveSpecChar(string input) => Regex.Replace(input, "[^a-zA-Z0-9]", string.Empty);
}
