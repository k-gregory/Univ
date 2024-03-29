﻿using System;

namespace Lab3
{
	/**
	 * \brief Visitor able to make operations with EconomicUnit
	 */
	public interface IMoneyInteractor
	{
		void Visit(LawfulMan l);
		void Visit(Bandit b);
		void Visit(Enterprise e);
	}

	public interface IMoneyInteractable{
		void Accept(IMoneyInteractor i);
	}
}

