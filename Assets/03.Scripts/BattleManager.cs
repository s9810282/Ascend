using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BattleManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] TileMapManager tileManager;

    [Header("Current Info")]
    [SerializeField] TurnType currentTurn;
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

    [SerializeField] Vector3Int[] unitMoveArea;
    [SerializeField] Unit tempUnit;

    Unit selectecUnit;
    Unit seletedTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        selectecUnit = tempUnit;
        //TurnStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTurn == TurnType.None)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tileManager.SetAreaColor(new Vector3Int(selectecUnit.positionX, selectecUnit.positionY, 0), unitMoveArea);
                currentTurn = TurnType.SelectMove;
            }
        }



        if (currentTurn == TurnType.SelectBehaviour)
        {
            
        }
        else if (currentTurn == TurnType.SelectMove)
        {
            MoveBehaviour();
        }
        else if (currentTurn == TurnType.SelectTarget)
        {

        }
    }

    public void SetSkill(int n)
    {
        Vector3Int[] skillArea = selectecUnit.unitData.skills[n].GetSkillArea();
        tileManager.SetAreaColor(tileManager.GetWorldToCell(selectecUnit.transform.position), skillArea);
    }

    public void SelectBehaviour()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            SetSkill(0);
        else if (Input.GetKeyDown(KeyCode.Keypad2))
            SetSkill(1);
        else if (Input.GetKeyDown(KeyCode.Keypad3))
            SetSkill(2);
        else if (Input.GetKeyDown(KeyCode.Keypad4))
            SetSkill(3);
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            tileManager.SetAreaColor(new Vector3Int(selectecUnit.positionX, selectecUnit.positionY, 0), unitMoveArea);
            currentTurn = TurnType.SelectMove;
        }
    }


    public void MoveBehaviour()
    {
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int pos = tileManager.GetWorldToCell(mousePoint);

        tileManager.SetRedColor(Vector3Int.zero, pos);

        if (Input.GetMouseButtonDown(0))
        {
            if (Array.Exists(unitMoveArea, x => x == pos - selectecUnit.ReturnPos()))
            {
                //Move
                Vector3 movePos = tileManager.GetCellToWorld(pos);
                selectecUnit.MoveTo(movePos, pos.x, pos.y);


                tileManager.SwapBeforeTile();
                tileManager.ReleaseAreaColor();

                currentTurn = TurnType.None;
            }
        }
    }






    public void TurnStart()
    {
        currentTurn = TurnType.None;

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
    public void SelectMove()
    {
        currentTurn = TurnType.SelectMove;
    }
    public void SelectBebaviour()
    {
        currentTurn = TurnType.SelectBehaviour;

        selectecUnit = turnList[unitTurnCount];
        unitTurnCount++;


    }
    public void SelectTarget()
    {
        currentTurn = TurnType.SelectTarget;
    }
    public void CheckEnd()
    {

    }
}
