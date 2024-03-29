﻿using System;

namespace Lab2
{
	/**
	 * \brief Base class for humans
	 */
	public abstract class Man : EconomicUnit{
		private const double START_BUDGET_COEF = 100;
		private const int BAD_PRODUCTION_RAIT = 30;
		protected void GoToShop(Enterprise e){
			if (Budget > 0) {
				Say ("It's time to make some purchases!");
				if (rnd.Next (BAD_PRODUCTION_RAIT) == 1) {
					Say ("Omg I need moral compensation for bad products!");
					var compensation = (decimal)rnd.NextDouble () * e.Budget * Power / (Power + e.Power);
					e.Pay (this, compensation);
				}
				decimal amount = this.Budget / rnd.Next (5, 20);
				Console.WriteLine ($"{Name} spends ${amount:0.##}");
				Pay (e, amount);
			} else {
				Say ("Oh, I have to find a job and earn some money");
			}
		}
		protected virtual void Die(){
			Console.WriteLine ($"{Name} dies");
			DoDeactivate ();
		}
		protected Man(string name) : base(name, START_BUDGET_COEF){
			Console.WriteLine ($"{Name} borns and he has ${Budget:0.##}");
		}
		protected Man() : this(NameGenerator.NextName()){}
		protected void Say(string what){
			Console.WriteLine ($"{ownName} says: {what}");
		}
	}
}

