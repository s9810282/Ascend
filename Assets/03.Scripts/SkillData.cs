using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public Sprite skillImage;

    public float coolTime;
    public float damage;
     
    //아 시발 버프 디버프 나중에 함

    public Vector3Int[] skillRangePositions;



    public Vector3Int[] GetSkillArea()
    {
        return skillRangePositions;
    }
}
