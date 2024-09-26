using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    [Header("Current Info")]
    [SerializeField] TurnType currentTurn;
    [Space(20f)]
    [Header("Manager")]
    [SerializeField] TileMapManager mapManager;
    [Space(20f)]
    [Header("Units")]
    [SerializeField] List<Unit> units;
    [Space(20f)]
    [Header("Monsters")]
    [SerializeField] List<Unit> monsters;
    [Space(20f)]
    [Header("Turn")]
    [SerializeField] List<Unit> turnList;
    [SerializeField] int unitTurnCount;

    Unit selectecUnit;
    Unit seletedTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TurnStart()
    {
        OrderByDex();
        SelectBebaviour();
    }


    
    public void OrderByDex()
    {
        units = units.OrderByDescending(a => a.unitData.unitInfo.dex).ToList();
        monsters = monsters.OrderByDescending(a => a.unitData.unitInfo.dex).ToList();

        int mCount = 0;
        int uCount = 0;

        turnList = new List<Unit>();

        for(int i = 0; i < units.Count + monsters.Count; i++)
        {
            if(units[uCount].unitData.unitInfo.dex >= monsters[mCount].unitData.unitInfo.dex)
            {
                turnList.Add(units[uCount]);
                uCount++;
            }
            else
            {
                turnList.Add(monsters[mCount]);
                mCount++;
            }
        }
    }
    public void SelectBebaviour()
    {
        currentTurn = TurnType.SelectBehaviour;
    }
    public void SelectTarget()
    {
        currentTurn = TurnType.SelectTarget;
    }
    public void CheckEnd()
    {

    }
}
