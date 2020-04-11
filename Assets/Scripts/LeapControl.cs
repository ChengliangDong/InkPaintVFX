using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class LeapControl : MonoBehaviour
{
    public bool isLeap = false;
	public GameObject moveObj;
	Controller lpControler;
	Hand leapHand;
    // Start is called before the first frame update
    void Start()
    {
     	lpControler =  new Controller(); 
     	if (lpControler.IsConnected)
     	{
     		Debug.Log("Leap is Ready!");
     	}  
     	else 
     	{
     		Debug.Log("Leap is NOT Ready!");
     	}
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeap)
        {
            Frame frame =  lpControler.Frame();
        
            if (frame !=null)
            {
                leapHand = frame.Hands[0];
                if (leapHand != null)
                {
                    Vector3 PalmPosition = new Vector3(0,0,0);
                    Vector3 PalmNormal = new Vector3(0,0,0);
                    Vector3 PalmDirection = new Vector3(0,0,0);
                    PalmPosition = leapHand.PalmPosition.ToUnityTranslated();
                    PalmNormal = leapHand.PalmNormal.ToUnity();
                    PalmDirection = leapHand.PalmPosition.ToUnity();
                    //Debug.Log(PalmPosition);
                    moveObj.transform.position = PalmPosition;
                }
            }
        }
        
       // Finger fingerOfinterest = frame.Finger (0);
        //Debug.Log(fingerOfinterest.ToString());
    }
}
