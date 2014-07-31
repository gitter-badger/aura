﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Aura.Shared.Database;
using Aura.Shared.Mabi;
using SharpExpress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aura.Web.Controllers
{
	public class RegisterController : IController
	{
		public void Index(Request req, Response res)
		{
			var name = req.Parameters.Get("name");
			var pass1 = req.Parameters.Get("password1");
			var pass2 = req.Parameters.Get("password2");

			var error = "";
			var success = "";

			if (name != null && pass1 != null && pass2 != null)
			{
				if (pass1 != pass2)
				{
					error = "The passwords don't match.";
					goto L_Send;
				}

				if (name.Length < 4)
				{
					name = "";
					error = "Username too short (min. 4 characters).";
					goto L_Send;
				}

				if (!Regex.IsMatch(name, @"^[0-9A-Za-z]+$"))
				{
					error = "Username contains invalid characters.";
					goto L_Send;
				}

				if (AuraDb.Instance.AccountExists(name))
				{
					error = "Account already exists.";
					goto L_Send;
				}

				var passHash = Password.RawToMD5SHA256(pass1);

				AuraDb.Instance.CreateAccount(name, passHash);

				name = "";
				success = "Account created successfully.";
			}

		L_Send:
			res.Render("web/register.htm", new { error = error, success = success, name = name });
		}
	}
}
