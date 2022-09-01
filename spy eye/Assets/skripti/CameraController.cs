using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector3 startPosition;
    public Camera cam;
    public bool prib;

    private void Start()
    {
        prib= false;
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        
        if (Input.GetMouseButton(0))
        {
            float pos = cam.ScreenToViewportPoint(Input.mousePosition).x - startPosition.x;
            float posz = cam.ScreenToViewportPoint(Input.mousePosition).y - startPosition.y;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x + pos, -30.0f, 30.0f), transform.position.y, Mathf.Clamp(transform.position.z + posz, 100.0f, 235.0f));
        }
    }
    public void priblizit()
    {
        if (!prib)
        {

            transform.position = new Vector3(transform.position.x -8, transform.position.y - 8, transform.position.z -8);
            prib = true;
        }
        else
        {

            transform.position = new Vector3(transform.position.x+8, transform.position.y + 8, transform.position.z+8);
            prib = false;
        }
    }
}