﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFarmingHoe : GOAPAction
{
	/// <summary>
	/// If a farming hoe has been collected.
	/// </summary>
	private bool m_Collected = false;

	/// <summary>
	/// Constructor.
	/// </summary>
	public CollectFarmingHoe()
	{
		AddPrecondition("hasFarmingHoe", false);

		AddEffect("hasFarmingHoe", true);
	}

	/// <summary>
	/// Reset the action.
	/// </summary>
	public override void DoReset()
	{
		m_Collected = false;
	}

	/// <summary>
	/// If the action has been completed.
	/// </summary>
	/// <returns>If the action has been completed.</returns>
	public override bool IsDone()
	{
		return m_Collected;
	}

	/// <summary>
	/// Check if the action needs the agent to be in range.
	/// </summary>
	/// <returns>True, this action requires the agent to be in range.</returns>
	public override bool RequiresInRange()
	{
		return true;
	}

	/// <summary>
	/// Check if the agent can find the base to collect a farming hoe from.
	/// </summary>
	/// <param name="agent">The agent checking this action.</param>
	/// <returns>If a target was found.</returns>
	public override bool CheckProceduralPrecondition(GameObject agent)
	{
		m_Target = GameObject.FindGameObjectWithTag("Base");

		return m_Target != null;
	}

	/// <summary>
	/// Collect a farming hoe.
	/// </summary>
	/// <param name="agent">The agent performing the action.</param>
	/// <returns>If the action was completed.</returns>
	public override bool Perform(GameObject agent)
	{
		Inventory inv = agent.GetComponent<Inventory>();

		inv.SetTool("farmingHoe");

		m_Collected = true;

		return m_Collected;
	}
}