using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D defaultCursor, grabCursor, arrowNW;
    [SerializeField] private GameObject rightClick;

    public static CursorController Instance { get; private set; }

    void Start()
    {
        SetDefaultCursor();
        rightClick.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            //if (hitInfo.transform.gameObject.tag == "Grab")
            if (hitInfo.collider.GetComponent<Grab>() != null)
            {
                SetGrabCursor();
            }
            else
            {
                SetDefaultCursor();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            rightClick.transform.position = Input.mousePosition + new Vector3(68, -85, 0);
            rightClick.SetActive(true);
        }

    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
    public void SetGrabCursor()
    {
        Cursor.SetCursor(grabCursor, Vector2.zero, CursorMode.Auto);
    }
    public void SetArrowNW()
    {
        Cursor.SetCursor(arrowNW, Vector2.zero, CursorMode.Auto);
    }
}