using UnityEngine;

public class ResponsiveCharacter : MonoBehaviour
{
    public int counter { get; private set; }
    public float secondsBetweenDecrements;
    public int initialCount;

    void Start()
    {
        counter = initialCount;
        InvokeRepeating("DecrementCounter", secondsBetweenDecrements, secondsBetweenDecrements);
    }

    private void OnMouseDown()
    {
        counter++;
        Debug.Log("Clicked on a: " + gameObject.name + " count: " + counter);
    }

    private void DecrementCounter()
    {
        counter--;
    }
}
