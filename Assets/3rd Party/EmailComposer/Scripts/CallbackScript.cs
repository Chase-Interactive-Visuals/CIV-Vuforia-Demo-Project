using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackScript : MonoBehaviour
{

	public static CallbackScript Instance;
	string currentStatus = "";
	void Awake(){
		Instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(650,120,350,50),"Message Received : "+currentStatus);
    }

    public void mailCallback(string status){
		currentStatus = status;
        print(status);
	}
}
