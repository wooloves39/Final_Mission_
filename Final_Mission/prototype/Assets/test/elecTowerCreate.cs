using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using UnityEngine;

public class elecTowerCreate : MonoBehaviour {

	TileMapMouse tile;
	public GameObject mouseTile;
	public GameObject prefab;
	public List<Vector3> arr;

	// Use this for initialization
	void Start () {
		tile = mouseTile.GetComponent<TileMapMouse>();
		arr = new List<Vector3> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			arr.Add( Instantiate (prefab,tile.currentTileCoord,tile.transform.rotation).transform.position + new Vector3 (0, 4, 0) );
		}
	}

}

