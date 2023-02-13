using UnityEngine;

public class GameManager : MonoBehaviour {
	public PlayerMouvements player;
    public GameObject point;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position.normalized;
                point.transform.position = new Vector3(startTouchPosition.x, startTouchPosition.y, 1);
                    
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                
                point.transform.position = new Vector3(0, 0, 10);

            }
            /*if (touch.phase == TouchPhase.Moved)*/
            {
                currentTouchPosition = touch.position.normalized;
                if (touch.position.x < 0) currentTouchPosition.x *= -1;
                if (touch.position.y < 0) currentTouchPosition.x *= -1;
                Vector2 touchGap = currentTouchPosition - startTouchPosition;

                player.MoveBy(touchGap*Time.deltaTime);
            }
        }
    }
}
