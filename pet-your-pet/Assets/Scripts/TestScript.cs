using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Transform target;
    public float turnSpeed = 50f;

    void Start()
    {
    }

    void Update()
    {
        //transform.LookAt(target);
        ReactToInput();
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on an object");
    }

    private void ReactToInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}
