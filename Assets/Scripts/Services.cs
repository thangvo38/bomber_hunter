using UnityEngine;
using UnityEngine.Tilemaps;

public class Services {
    public static Vector3Int ToVectorOne (Vector3Int vector) {
        return new Vector3Int (vector.x / ReplaceIfZero (vector.x),
            vector.y / ReplaceIfZero (vector.y),
            vector.z / ReplaceIfZero (vector.z));
    }

    public static void IgnoreCollisionByTag (GameObject gameObject, Collision2D collision, string tag) {
        if (collision.gameObject.tag == tag) {
            Physics2D.IgnoreCollision (collision.collider, gameObject.GetComponent<Collider2D> ());
        }
    }

    public static int ReplaceIfZero (int value) {
        if (value == 0) {
            return 1;
        }
        return Mathf.Abs (value);
    }
    public static Transform GetObjectInCell (Tilemap tilemap, Vector3 position) {
        Transform parent = tilemap.transform;
        int childCount = parent.childCount;
        Vector3 min = (Vector3) tilemap.WorldToCell (position);
        Vector3 max = (Vector3) tilemap.WorldToCell (position + Vector3Int.one);
        Bounds bounds = new Bounds (position, Vector2.one);

        for (int i = 0; i < childCount; i++) {
            Transform child = parent.GetChild (i);
            if (bounds.Contains (child.position))
                return child;
        }
        return null;
    }
}