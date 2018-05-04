using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapMouse : MonoBehaviour {
	TileMap tileMap;
	public Transform selectionCube;
	public Vector3 currentTileCoord;
	// Use this for initialization
	void Start () {
		tileMap = GetComponent<TileMap> ();	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo, Mathf.Infinity/*,1<<LayerMask.NameToLayer("Ground")*/)) {

			int x = Mathf.FloorToInt (hitInfo.point.x / tileMap.size_Tile);
			int z = Mathf.FloorToInt (hitInfo.point.z / tileMap.size_Tile);



			currentTileCoord.x = x+0.5f;
			currentTileCoord.z = z+0.5f;
		
			selectionCube.transform.position = currentTileCoord;
		} else {
			if (Input.GetMouseButtonDown (1) && selectionCube != null) {
			
			}
		}
			
	}
}
