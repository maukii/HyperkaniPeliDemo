using UnityEngine;

public class PositionColliders : MonoBehaviour
{
    [SerializeField] private BoxCollider2D leftColl;
    [SerializeField] private BoxCollider2D rightColl;
    [SerializeField] private BoxCollider2D bottomColl;

    private float screenHalfWidth;
    private float screenHalfHeight;


    private void Awake()
    {
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        screenHalfHeight = Camera.main.orthographicSize;

        leftColl.size = new Vector2(leftColl.size.x, screenHalfHeight * 3f);
        rightColl.size = new Vector2(rightColl.size.x, screenHalfHeight * 3f);
        leftColl.transform.position = new Vector3(-screenHalfWidth - leftColl.bounds.size.x * 0.5f, 0);
        rightColl.transform.position = new Vector3(screenHalfWidth + rightColl.bounds.size.x * 0.5f, 0);
        bottomColl.size = new Vector3(screenHalfWidth * 2f, 1.0f);
    }
}
