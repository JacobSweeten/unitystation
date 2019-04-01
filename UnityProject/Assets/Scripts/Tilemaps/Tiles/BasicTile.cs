﻿using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public struct TileState
{
	public Sprite Sprite;
	public float Damage;
}

public abstract class BasicTile : LayerTile
{
	public bool AtmosPassable;
	public bool IsSealed;
	public PassableDictionary Passable;

	public float MaxHealth;
	public TileState[] HealthStates;

	public GameObject ItemSpawn;
	public int amount;

	public LayerTile DestroyedTile;

	public override void RefreshTile(Vector3Int position, ITilemap tilemap)
	{
		foreach (Vector3Int p in new BoundsInt(-1, -1, 0, 3, 3, 1).allPositionsWithin)
		{
			tilemap.RefreshTile(position + p);
		}
	}

	public bool IsPassable(CollisionType colliderType)
	{
		return Passable[colliderType];
	}

	public bool IsAtmosPassable()
	{
		return AtmosPassable;
	}

	public bool IsSpace()
	{
		return IsAtmosPassable() && !IsSealed;
	}
}