using UnityEngine;

public class StraightEnemy : UnitStatus {
    
    private void Start()
    {
        
    }

    private void Update() 
    {
        AttackControl();
		if (isMoving)
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
            // Move(xDir, yDir);
        }
    }

    


}