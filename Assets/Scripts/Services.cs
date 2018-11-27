using UnityEngine;

public class Services {
    public static Vector3Int ToVectorOne(Vector3Int vector)
    {
        return new Vector3Int(vector.x / ReplaceIfZero(vector.x),
        vector.y / ReplaceIfZero(vector.y),
        vector.z / ReplaceIfZero(vector.z));
    }

    public static void IgnoreCollisionByTag(GameObject gameObject, Collision2D collision, string tag)
    {
        if (collision.gameObject.tag == tag)
       {
           Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
       }
    }

    public static int ReplaceIfZero(int value)
    {
        if (value == 0)
        {
            return 1;
        }
        return Mathf.Abs(value);
    }

}