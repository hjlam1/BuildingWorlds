using UnityEngine;
using System.Collections;

public class CityCreate : MonoBehaviour {

	public Transform buildingOne;
	public Transform buildingTwo;
	public Transform buildingThree;
	public Transform buildingFour;
	public GameObject streetLight;
	public Transform taxi;
	public Transform bus;
	public Transform woman;

	void Start () {
		StartCoroutine (CityItems());
	}
	
	IEnumerator CityItems () {

		float endOfRow = 125f;
		float xUnitsSoFar = 0f;
		float zUnitsSoFar = 0f;
		Quaternion rotation = Quaternion.identity;
		rotation.eulerAngles = new Vector3(0,90,0);
		Quaternion lightRotation = Quaternion.identity;
		lightRotation.eulerAngles = new Vector3(-12,0,0);
		Quaternion busRotation = Quaternion.identity;
		busRotation.eulerAngles = new Vector3(-76,-90,0);
		Quaternion taxiRotation = Quaternion.identity;
		taxiRotation.eulerAngles = new Vector3(-15,90,0);
		Quaternion womanRotation = Quaternion.identity;
		womanRotation.eulerAngles = new Vector3(0,-90,0);
		int groundType = 1;
		int streetDirection = 1;

		while (true) {

			float randomNum = Random.Range (0f, 10f);
			if (groundType == 1) {
				if ( randomNum < 2.5f) {
					Instantiate (buildingOne, new Vector3(xUnitsSoFar,1.1f,zUnitsSoFar),rotation);
					xUnitsSoFar+=2.6f;					
				} else if ((randomNum >= 2.5f) && (randomNum < 5f)){
					Instantiate (buildingTwo, new Vector3(xUnitsSoFar,2.4f,zUnitsSoFar),rotation);
					xUnitsSoFar+=2.9f;
				} else if ((randomNum >= 5f) && (randomNum <7.5f)){
					Instantiate (buildingThree, new Vector3(xUnitsSoFar+1.3f,1.45f,zUnitsSoFar),rotation);
					xUnitsSoFar+=6f;
				} else {
					Instantiate (buildingFour, new Vector3(xUnitsSoFar+1f,2.25f,zUnitsSoFar),rotation);
					xUnitsSoFar+=5.5f;					
				}
			} else if (groundType == 2) {
				if (randomNum <3f) {
					Instantiate (streetLight, new Vector3(xUnitsSoFar,0.7f, zUnitsSoFar), lightRotation);
				} else if (randomNum >9.5f) {
					Instantiate (woman, new Vector3(xUnitsSoFar,0.00655f, zUnitsSoFar), womanRotation);
				}
				xUnitsSoFar+=10f;
			} else if (groundType == 3) {
				if (randomNum < 5f) {
					Instantiate (taxi, new Vector3(xUnitsSoFar+0.25f,0.35f, zUnitsSoFar), taxiRotation);

				} else if (randomNum > 9.3f) {
					Instantiate (bus, new Vector3(xUnitsSoFar+0.5f,0.28f, zUnitsSoFar), busRotation);
				} 
				xUnitsSoFar+=Random.Range (2f, 6f);
			} else {
				xUnitsSoFar=endOfRow+1f;
			}

			if (xUnitsSoFar>endOfRow) {
				xUnitsSoFar = 0f;



				if (groundType ==0) {
					zUnitsSoFar+=1.5f;
					streetDirection = 1;
					rotation.eulerAngles = new Vector3(0,90,0);
					lightRotation.eulerAngles = new Vector3(-12,0,0);
					busRotation.eulerAngles = new Vector3(-76,-90,0);
					taxiRotation.eulerAngles = new Vector3(-15,90,0);
					womanRotation.eulerAngles = new Vector3(0,-90,0);
				} else if (groundType == 1) {
					zUnitsSoFar+=2.5f;
				} else if (groundType ==2) {
					zUnitsSoFar+=2f;
				} else if (groundType ==3) {
					zUnitsSoFar += 2f;
				} else if (groundType==4) {
					zUnitsSoFar+=.5f;
					streetDirection =-1;
					rotation.eulerAngles = new Vector3(0,270,0);
					lightRotation.eulerAngles = new Vector3(-12,180,0);
					busRotation.eulerAngles = new Vector3(-76,90,0);
					taxiRotation.eulerAngles = new Vector3(-15,-90,0);
					womanRotation.eulerAngles = new Vector3(0,90,0);
				}



				groundType += streetDirection;

			}
			yield return new WaitForSeconds(0.001f);
		}
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (0);
		}
	}
}
