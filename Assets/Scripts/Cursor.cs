using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorControl : MonoBehaviour {

    public Texture2D _clickable, _default;

    public Vector2 hotSpot = Vector2.zero;

    // Use this for initialization
    void Start ()
    {

  

    }
	
	// Update is called once per frame
	void Update () {
       
    }
   void OnMouseOver()
    {
        Cursor.SetCursor(_clickable, hotSpot, CursorMode.ForceSoftware);

    }
     void OnMouseExit()
    {
        Cursor.SetCursor(_default, hotSpot, CursorMode.ForceSoftware);
    }
    public void OnMouseOverButton()
    {
        Cursor.SetCursor(_clickable, hotSpot, CursorMode.ForceSoftware);

    }
    public void OnMouseExitButton()
    {
        Cursor.SetCursor(_default, hotSpot, CursorMode.ForceSoftware);
    }



}
