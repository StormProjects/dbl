using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class NavigationManager{
	
	public struct Route {
		public string RouteDescription;
		public bool CanTravel;
	}

	public static Dictionary<string, Route> RouteInformation = new Dictionary<string, Route>() {
		{ "Plains", new Route { RouteDescription = "The big bad plains, watch for dinos", CanTravel = true}
		},
		{ "Mountains", new Route { RouteDescription = "The mountain area",CanTravel = false}
		},
	};

	public static string GetRouteInfo(string destination) {
		return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].RouteDescription : null;
	}

	public static bool CanNavigate(string destination) {
		return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].CanTravel : false;
	}

	public static void NavigateTo(string destination) {
		SceneManager.LoadScene(destination);
	}

}