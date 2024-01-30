using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bird : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;
    public Vector3 Initial_Position;
    public int Bird_Speed;
    public string Scene_Name;
    private bool Bird_Enable_Time;
    private float Bird_Wait_Time;
    public void Awake()
    {
        Initial_Position = transform.position;
    }
    public void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void OnMouseUp()
    {
        Vector2 Spring_force = Initial_Position - transform.position;
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Rigidbody2D> ().gravityScale = 1;
        GetComponent<Rigidbody2D> ().AddForce(Bird_Speed * Spring_force);
        Bird_Enable_Time = true;

    }
       public void OnMouseDrag()
    {
        Vector3 DragPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        transform.position = new Vector3 (DragPosition.x, DragPosition.y);
    }
    void Update()
    {
        if (Bird_Enable_Time && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.5)
        {
            Bird_Wait_Time += Time.deltaTime;
        }
        if (transform.position.x > 15 
            || transform.position.x < -15 
            || transform.position.y > 15
            || transform.position.y < -15 
            || Bird_Wait_Time > 3)
        {
            SceneManager.LoadScene(Scene_Name);
        }
    }
}
