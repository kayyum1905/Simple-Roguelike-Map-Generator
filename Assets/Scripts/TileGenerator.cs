using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour 
{

	public GameObject[] tiles;
	public Transform tilesParent;

	[SerializeField] float xTilePos = -8f;
	[SerializeField] float yTilePos = -4f;

	[SerializeField] int redTileLimit = 8;

	void Start () 
	{
		for (int x = 1; x <= 17; x++) 
		{
			int tileNo = 0;

			for (int y = 1; y <= 9; y++) 
			{
				if(xTilePos == -8f || xTilePos == 8f)
				{
					if(yTilePos == 0f)
					{
						tileNo = 1;
					}
					else
						tileNo = 3;
				}
				else if(yTilePos == -4f || yTilePos == 4f)
				{
					if(xTilePos == 0f)
					{
						tileNo = 1;
					}
					else
						tileNo = 4;
				}
				else
					tileNo = 0;

				SpawnTile(tileNo);	

			}

			yTilePos = -4f;
			xTilePos += 1f;

		}
	}

	void SpawnTile(int num)
	{
		if(num == 0)
		{
			if(redTileLimit > 0)
			{
				int ranNum = Random.Range( 0, 10);

				if(ranNum == 4)
				{
					num = 2;
					redTileLimit--;
				}
			}
		}

		GameObject tile = Instantiate(tiles[num] , new Vector2( xTilePos, yTilePos) , Quaternion.identity) as GameObject;
		tile.transform.parent = tilesParent;
		yTilePos += 1f;

	}
}
