using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    None,
    Unit,
    Monster,
}


public class UnitInfo
{
    public int hp;
    public int atk;
    public int mAtk;
    public int nova;
    public int dex;
    public int arm;

    public int auror;
    public int focus;
    public int spirit;
}



[CreateAssetMenu(fileName = "UnitData")]
public class UnitData : ScriptableObject
{
    public UnitInfo unitInfo;
    public Sprite defaultImage;
    public List<SkillData> skills;
}

