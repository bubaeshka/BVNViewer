﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNViewer
{
	public class _3200op_service : _op_service
	{
		public _3200op_service(string inpl, int poz) : base(inpl, poz)
		{
		}

		public string GetProfile() 
		{
			//return "Борода!";
			throw new NotImplementedException("Нужно доделывать!");
		}

		public void SetProfile(string val) 
		{ 
			throw new NotImplementedException("Нужно доделывать!");
		}
	}
}
