/***********************************************************************************************
 * CustomNetworkDiscovery.cs
 * 	-This script extends the functionality of the basic Network Discovery component
 * 	-Users can only view LAN games with this discovery script
 * 	-Use this to display custom server list
 * *********************************************************************************************/

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;


public class CustomNetworkDiscovery : NetworkDiscovery {
	
#region Variables / Delegates / Events
	public List<ServerResponse> serverList = new List<ServerResponse>();

	public delegate void DiscoveryEvent ();
	public event DiscoveryEvent OnNewServerFound;

	public void OnServerAdded () {
		if (OnNewServerFound != null) 
			OnNewServerFound();
	}
	#endregion

#region Override that handles receiving a broadcast
	/// <summary>
	/// Raises the received broadcast event.
	/// </summary>
	/// <param name="fromAddress">From address.</param>
	/// <param name="data">Data.</param>
	public override void OnReceivedBroadcast (string fromAddress, string data)
	{
		// Network Discovery component has found a server being broadcasted
		ServerFound(fromAddress, data);
	}		
	#endregion	

#region Function to decipher received broadcasts
	/// <summary>
	/// Handles the found server.
	/// </summary>
	/// <param name="ip">Ip.</param>
	/// <param name="data">Data.</param>
	void ServerFound(string ip, string data) {
		// create new server response with name/ip
		var _srv = new ServerResponse (data, ip);
		// check if server info with same IP address has already been created
		if (serverList.Find (x => x.serverIP == _srv.serverIP) != null) {
			return;
		} else {
			// Add to list
			serverList.Add (_srv);
			// Call event for any listeners
			OnServerAdded ();
		}
	}
	#endregion
}


/// <summary>
/// Server response simple class
/// </summary>
public class ServerResponse {
	public ServerResponse (string name, string ip) {
		serverName = name;
		serverIP = ip;
	}
	public string serverName { get; set; }
	public string serverIP { get; set; }
	public bool visible { get; set; }
}	
