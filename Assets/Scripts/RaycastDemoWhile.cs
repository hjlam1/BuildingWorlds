using UnityEngine;
using System.Collections;

public class RaycastDemoWhile : MonoBehaviour {

	public Transform originalBlueprint;

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
		RaycastHit rayHit = new RaycastHit();
		if (Physics.Raycast (ray, out rayHit, 1000f)) {
			if (Input.GetMouseButtonDown (0) ){
				int howManyCopies = 0;
				while ( howManyCopies<10) {
					Instantiate (originalBlueprint, rayHit.point, Random.rotation);
					howManyCopies++;
				}

			}
		}
	}
}
