using UnityEngine;

public class ResponsiveCharacter : MonoBehaviour
{
    public int timesResponded { get; private set; }

    void Start()
    {
        timesResponded = 0;
    }

    private void OnMouseDown()
    {
        timesResponded++;
        Debug.Log("Clicked on a: " + gameObject.name + " count: " + timesResponded);
    }

    void Update()
    {

    }
}
