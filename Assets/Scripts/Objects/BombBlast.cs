using UnityEngine; 

public class BombBlast : BombBehavior {
	public override void Explode(Vector2 position)
	{
			this.maxLength = Constants.BOMB_BLAST_LEN;
      ExplodeCell(Vector3Int.zero, 0);
			ExplodeCell(new Vector3Int(1, 0, 0));
			ExplodeCell(new Vector3Int(1, 1, 0));
			ExplodeCell(new Vector3Int(0, 1, 0));
			ExplodeCell(new Vector3Int(-1, 1, 0));
			ExplodeCell(new Vector3Int(-1, 0, 0));
			ExplodeCell(new Vector3Int(-1, -1, 0));
			ExplodeCell(new Vector3Int(0, -1, 0));
			ExplodeCell(new Vector3Int(1, -1, 0)); 
	}

}