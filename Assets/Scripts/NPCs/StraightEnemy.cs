using System.Collections;
using UnityEngine;

public class StraightEnemy : UnitStatus {
    
    Coroutine moveCoroutine;

    public int stopChance = 0;

    private void Start()
    {
        checkAhead = transform.Find("CheckCollide").gameObject;
    }

    private void Update() 
    {
        // AttackControl();
		if (isMoving || Random.Range(0, stopChance) > 0)
		{
			return;
		}
        MovementControl();
    }
    
    protected override void MovementControl()
    {
        xDir = direction.x;
        yDir = direction.y;

        if ( xDir != 0 )
            yDir = 0;
    
        if (xDir != 0 || yDir != 0)
        {
            Move(xDir, yDir);
        }
    }

    void Move(int x, int y)
    {
        checkAhead.GetComponent<BoxCollider2D>().offset = direction;
        Vector3 currentCell = transform.position;
        Vector3 targetCell = currentCell + new Vector3(x, y, currentCell.z);

        bool hasBlock = isBlockAhead(x, y);
        if (!hasBlock)
        {
            isMoving = true;
            moveCoroutine = StartCoroutine(Moving(targetCell));
        } else {
            direction *= -1;
            checkAhead.GetComponent<BoxCollider2D>().offset = direction;
        }
    }
    IEnumerator Moving(Vector3 destination)
    {
        float distance = (transform.position - destination).sqrMagnitude;

        while (distance > 0f)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);
            transform.position = newPos;
            distance = (transform.position - destination).sqrMagnitude;

            yield return null;
        }
        isMoving = false;
    }
    bool isBlockAhead(int x, int y)
    {
        return checkAhead.GetComponent<PlayerCheckCollide>().isCollided;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Services.IgnoreCollisionByTag(this.gameObject, other, "Enemy");
        Services.IgnoreCollisionByTag(this.gameObject, other, "Player");

        switch(other.gameObject.tag)
        {
            case "Wall":
            case "Bomb":
            case "Destructable":
            case "Block":
                StopCoroutine(moveCoroutine);
                isMoving = false;
                direction *= -1;
                break;
        }
    }

}