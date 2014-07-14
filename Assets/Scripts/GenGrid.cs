using UnityEngine;
using System.Collections;

public class GenGrid : MonoBehaviour {

	//Attributes
	public float tileSize;
	public int gridX;
	public int gridZ;
	//private Vector3 offset = new Vector3 (0, 0, 0);
	
	void Start () {

		ProcMesh mesh = new ProcMesh(); //create a procedural mesh

		for (int z = 0; z < gridZ; z++){
			float zOffset= tileSize * z;
			for (int x = 0; x < gridX; x++){
				float xOffset = tileSize * x;
				Vector3 offset = new Vector3(xOffset, 0, zOffset);
				mesh.BuildTile (tileSize,offset); //create a tile
			}
		}

		MeshFilter filter = GetComponent<MeshFilter>(); //cache the mesh
		if (filter != null){
			filter.sharedMesh = mesh.CreateMesh(); //create and apply the mesh
		}
	}
	
}
