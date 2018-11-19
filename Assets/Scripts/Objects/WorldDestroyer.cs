using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldDestroyer : MonoBehaviour {
    public Tilemap tilemap;
    public Tile destructibleTile;

    public GameObject explosionPrefab;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell);
    }

    bool ExplodeCell(Vector3Int cellPos)
    {
        Tile tile = tilemap.GetTile<Tile>(cellPos);
        if (tile == destructibleTile)
        { 
            tilemap.SetTile(cellPos, null);
        } else {
            return false;
        }

        Vector3 pos = tilemap.GetCellCenterWorld(cellPos);
		Instantiate(explosionPrefab, pos, Quaternion.identity);

		return true;
    }
}