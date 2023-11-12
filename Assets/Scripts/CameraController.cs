using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;                                                                //movement speed of camera
    public float panBorderThickness = 10f;                                                      //pan thickness for border
    public float scrollSpeed = 5f;                                                              //zoom speed when scroll is used
    public float minY = 10f;                                                                    //zoomed in
    public float maxY = 80f;                                                                    //zoomed out
    public float length = 35f;                                                                  //length of border
    public float width = 35f;                                                                   //width of border
    public float startX;                                                                        //start position for x
    public float startZ;                                                                        //start position for z
    void Start()
    {
        startX = transform.position.x;                                                          //camera starts at x
        startZ = transform.position.z;                                                          //camera starts at z
    }
    void Update()
    {
        if(GameManager.gameIsOver)                                                              //checks if game is over
        {
            this.enabled = false;                                                               //camera is disabled when game is over
            return;
        }
        
        if(Input.GetKey("w")||Input.mousePosition.y >= Screen.height - panBorderThickness)      //go up by pressing w
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); 
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)                   //go back by pressing s
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)    //go right by pressing d
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)                   //go left by pressing a
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll =  Input.GetAxis("Mouse ScrollWheel");                                     //scroll for zooming

        Vector3 pos = transform.position;                                                       //sets current position
        pos.y -= scroll *1000* scrollSpeed * Time.deltaTime;            
        pos.x = Mathf.Clamp(pos.x, startX - length, startX + length);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, startZ - width+50, startZ + width);
        transform.position = pos;
    }
}
