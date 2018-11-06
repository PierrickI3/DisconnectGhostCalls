using System;

namespace DisconnectCalls
{
	public class EdgeInfo
	{
		public String Id { get; set; }
		public String Name { get; set; }
		public bool? Online { get; set; }

		public override string ToString()
		{
			return Name + " (" + (Online == true ? "Online" : "OFFLINE") + ")";
		}

		public EdgeInfo(string id, string name, bool? online)
		{
			Id = id;
			Name = name;
			Online = online;
		}
	}
}
