using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {
	public int size_x = 100;
	public int size_z = 50;
	public float size_Tile = 1.0f;


	// Use this for initialization
	void Start () {
		BuildMesh ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void BuildMesh()
	{
		int num_tile = size_x * size_z;
		int num_triangle = num_tile * 2;
		int num_vertex = (size_x + 1) * (size_z + 1);

		Vector3[] vertex = new Vector3[num_vertex];
		Vector3[] normal = new Vector3[num_vertex];
		Vector2[] uv = new Vector2[num_vertex];

		vertex [0] = new Vector3 (0, 0, 0);
		vertex [1] = new Vector3 (1, 0, 0);
		vertex [2] = new Vector3 (0, 0, -1);
		vertex [3] = new Vector3 (1, 0, -1);

		int[] triangle = new int[num_triangle * 3];
		int t;
		for (int z = 0; z < size_z; z++) {
			for (int x = 0; x < size_x; x++) {
				t = z * (size_x + 1) + x;
				vertex [t] = new Vector3 (x * size_Tile, 0, z * size_Tile);
				normal [t] = Vector3.up;
				uv [t] = new Vector2 ((float)x / (size_x + 1), (float)z / (size_z + 1));
			}
		}

		for (int z = 0; z < size_z; z++) {
			for (int x = 0; x < size_x; x++) {
				int triOffset = (z * size_x + x) * 6;
				t = z * (size_x + 1) + x;

				triangle [triOffset + 0] = t + 0;
				triangle [triOffset + 1] = t + (size_x + 1) + 0;
				triangle [triOffset + 2] = t + (size_x + 1) + 1;

				triangle [triOffset + 3] = t + 0;
				triangle [triOffset + 4] = t + (size_x + 1) + 1;
				triangle [triOffset + 5] = t + (size_x + 1) + 1;
			}
		}

		Mesh mesh = new Mesh ();
		mesh.vertices = vertex;
		mesh.triangles = triangle;
		mesh.normals = normal;
		mesh.uv = uv;

		MeshFilter meshFilter = GetComponent<MeshFilter> ();
		MeshRenderer meshRenderer = GetComponent<MeshRenderer> ();
		MeshCollider meshCollider= GetComponent<MeshCollider> ();

		meshFilter.mesh = mesh;
	}
}
