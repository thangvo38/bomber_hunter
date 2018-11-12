using UnityEngine; 

public class BombClassic : BombBehavior {
	public int fireLength = 3;
	protected override void Explode(Vector2 position)
	{
			this.maxLength = fireLength;
			Vector3Int originCell = tilemap.WorldToCell(position);
      ExplodeCell(originCell, Vector3Int.zero, 0);
			ExplodeCell(originCell, new Vector3Int(1, 0, 0));
			ExplodeCell(originCell, new Vector3Int(0, 1, 0));
			ExplodeCell(originCell, new Vector3Int(-1, 0, 0));
			ExplodeCell(originCell, new Vector3Int(0, -1, 0));
	}

}