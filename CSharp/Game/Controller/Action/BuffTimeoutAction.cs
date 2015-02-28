﻿using Common.Event;
using Model;
using MongoDB.Bson;

namespace Controller
{
	[Action(ActionType.BuffTimeoutAction)]
	public class BuffTimeoutAction: IEventSync
	{
		public void Run(Env env)
		{
			Unit owner = World.Instance.GetComponent<UnitComponent>().Get(env.Get<ObjectId>(EnvKey.OwnerId));
			if (owner == null)
			{
				return;
			}
			owner.GetComponent<BuffComponent>().RemoveById(env.Get<ObjectId>(EnvKey.BuffId));
		}
	}
}