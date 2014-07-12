﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Aura.Shared.Network;
using Aura.Shared.Util;
using System;

namespace Aura.Msgr.Network
{
	/// <summary>
	/// Messenger Server, different protocol than Login and Channel.
	/// </summary>
	public class MsgrServer : BaseServer<MsgrClient>
	{
		protected override int GetPacketLength(byte[] buffer, int ptr)
		{
			// <0x55><0x??><0x02><length>
			return buffer[ptr + 3] + 4;
		}

		protected override void HandleBuffer(MsgrClient client, byte[] buffer)
		{
			Log.Debug("in:  " + BitConverter.ToString(buffer));

			var length = buffer.Length;
			if (length < 5) return;

			// Challenge
			if (client.State == ClientState.BeingChecked)
			{
				if (buffer[4] == 0x00)
				{
					client.Socket.Send(new byte[] { 0x55, 0xfb, 0x02, 0x05, 0x00, 0x00, 0x00, 0x00, 0x40 });
					Log.Debug("0x55, 0xfb");
				}
				else if (buffer[4] == 0x01)
				{
					client.Socket.Send(new byte[] { 0x55, 0xff, 0x02, 0x09, 0x01, 0x1e, 0xf7, 0x5d, 0x68, 0x00, 0x00, 0x00, 0x40 });
					Log.Debug("0x55, 0xff");
				}
				else if (buffer[4] == 0x02)
				{
					Log.Debug("0x55, 0x12");
					client.Socket.Send(new byte[] { 0x55, 0x12, 0x02, 0x01, 0x02 });
					client.State = ClientState.LoggingIn;
				}
			}
			// Actual packets
			else
			{
				// Get to the end of the protocol header
				var start = 3;
				while (start < length)
				{ if (buffer[++start] == 0) break; }

				var packet = new Packet(buffer, start);
				this.Handlers.Handle(client, packet);
			}
		}
	}
}
