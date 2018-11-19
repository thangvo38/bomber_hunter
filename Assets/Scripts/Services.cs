using UnityEngine;

public class Services {
    public Vector3Int ToVectorOne(Vector3Int vector)
    {
        return new Vector3Int(vector.x / ReplacceIfZero(vector.x),
        vector.y / ReplacceIfZero(vector.y),
        vector.z / ReplacceIfZero(vector.z));
    }

    int ReplacceIfZero(int value)
    {
        if (value == 0)
        {
            return 1;
        }
        return Mathf.Abs(value);
    }
}