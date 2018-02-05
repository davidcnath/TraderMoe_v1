using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour {

	public ParticleSystem particle;

	private GameObject buildingManager;
	private GameObject resourceManager;

	private float time = 0f;
	private float farmSpeed = 5f;

	// Use this for initialization
	void Start () {
		buildingManager = transform.parent.gameObject;
		foreach (Transform child in buildingManager.transform.parent){
			if (child.name == "ResourceManager") {
				resourceManager = child.gameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > farmSpeed) {
			resourceManager.GetComponent<ResourceManager> ().updateFood (1);
			particle.Play ();
			time = 0;
		}
	}
}
