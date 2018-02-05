using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTile : MonoBehaviour {

	public int xCoord;
	public int yCoord;

	public void updateCoords(int x, int y){
		xCoord = x;
		yCoord = y;
	}

	// ------------------------------------------

	private bool buildMode;

	public void toggleBuildMode(){
		if (!buildMode) {
			buildMode = true;
		} else {
			buildMode = false;
		}
	}

	void OnMouseOver(){
		if(buildMode) {
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
	}

	void OnMouseExit(){
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseDown(){
		if (buildMode) {
			transform.parent.GetComponent<Map> ().getTileGO (gameObject);
			buildMode = false;
		}
	}

}
