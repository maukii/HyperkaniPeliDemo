using UnityEngine;

public static class Utils
{
    /// <summary>
    /// Remaps value from range to new range
    /// </summary>
    /// <param name="value">Value to remap</param>
    /// <param name="from1">start value 1</param>
    /// <param name="to1">end value 1</param>
    /// <param name="from2">start value 2</param>
    /// <param name="to2">end value 2</param>
    /// <returns>remapped value</returns>
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    /// <summary>
    /// Without Z value
    /// </summary>
    /// <returns>Vector3 where z is 0</returns>
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 result = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        result.z = 0.0f;
        return result;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        return worldCamera.ScreenToWorldPoint(screenPosition);
    }


    /// <summary>
    /// Creates a game object with text mesh component with given text and parameters
    /// </summary>
    /// <param name="text">input text</param>
    /// <returns>returns TextMesh object</returns>
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color color = default(Color), TextAnchor textAnchor = TextAnchor.MiddleCenter, int sortingOrder = 0)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, sortingOrder);
    }
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, int sortingOrder)
    {
        GameObject go = new GameObject("World_text", typeof(TextMesh));
        Transform transform = go.transform;
        transform.SetParent(parent);
        transform.localPosition = localPosition;
        TextMesh textMesh = go.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

        return textMesh;
    }
}
