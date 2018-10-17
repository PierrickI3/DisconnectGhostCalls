using System;
using System.Windows.Forms;

namespace DisconnectCalls
{
	public partial class DisplayConversation : Form
	{
		String _jsonObject = String.Empty;

		public DisplayConversation(String JsonObject)
		{
			InitializeComponent();

			_jsonObject = JsonObject;
			txtConversation.Text = _jsonObject.ToString();
			txtConversation.SelectionLength = 0;
		}
	}
}
