using Sandbox;
using System;
using System.Collections.Generic;

public sealed class PlayerDamageTracker : Component, Component.ITriggerListener
{
	#region Vars
	private PlayerStats playerStats;
	private bool isEnemyInTrigger = false;
	private TimeSince timeSinceLastDamage;
	#endregion

	#region Logic
	public void OnTriggerEnter( Collider other )
	{
		if ( other.GameObject.Tags.Has( "enemy" ) )
		{
			isEnemyInTrigger = true;
		}
	}

	public void OnTriggerExit( Collider other )
	{
		if ( other.GameObject.Tags.Has( "enemy" ) )
		{
			isEnemyInTrigger = false;
		}
	}
	#endregion

	#region Components
	protected override void OnStart()
	{
		playerStats = GameObject.Components.Get<PlayerStats>();
	}

	protected override void OnUpdate()
	{
		if ( isEnemyInTrigger && timeSinceLastDamage > 1f )
		{
			playerStats?.TakeDamage( 10f );
			timeSinceLastDamage = 0;
		}
	}
	#endregion
}
