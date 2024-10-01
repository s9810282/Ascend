using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Unit : MonoBehaviour
{
    public UnitData unitData;

    public int positionX = 0;
    public int positionY = 0;

    public bool isMove = false;
    public Vector3 targetPos;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove)
        {
            transform.position =  Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (transform.position == targetPos)
                isMove = false;
        }
    }

    public void MoveTo(Vector3 pos, int x = 0, int y = 0)
    {
        targetPos = pos;
        isMove = true;

        positionX = x;
        positionY = y;
    }

    public Vector3Int ReturnPos()
    {
        return new Vector3Int(positionX, positionY , 0);
    }
}
