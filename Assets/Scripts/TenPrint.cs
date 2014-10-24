using UnityEngine;
using System.Collections;

public class TenPrint : MonoBehaviour {

	public TextMesh textMesh;

	void Start () {
		StartCoroutine ( TenPrintProcess ()) ;
	}
	
	// Update is called once per frame
	IEnumerator TenPrintProcess () {
		int charsSoFar = 0;
		while (true) {
			if (Random.Range (0f, 10f) < 5f) {
				textMesh.text+= "\\";
			} else {
				textMesh.text+= "/";
			}
			charsSoFar++;
			if (charsSoFar%20==0) {
				textMesh.text+= "\n";
			}
			yield return new WaitForSeconds(0.25f);
		}
	}
}
