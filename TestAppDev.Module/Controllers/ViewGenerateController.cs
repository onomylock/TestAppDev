using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAppDev.Module.BusinessObjects;

namespace TestAppDev.Module.Controllers
{
	// For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
	//private SimpleAction generateDB;
	public partial class ViewGenerateController : ViewController
	{
		private SimpleAction generateDB;
		private char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
		private StringBuilder sb;
		public ViewGenerateController()
		{
			InitializeComponent();
			TargetViewType = ViewType.ListView;			
			TargetObjectType = typeof(Airport);
			
			generateDB = new SimpleAction(this, "GenerateDB", "View", generatetorDB);
		}
		private void generatetorDB(object sender, SimpleActionExecuteEventArgs e)
		{
			Random rand = new Random();
			int airportCount = rand.Next(1, 10);
			int planeCount = rand.Next(airportCount, 20);
			int pilotCount = rand.Next(planeCount, 30);

			for(int i = 0; i < airportCount; i++)
			{
				var airport = ObjectSpace.CreateObject<Airport>();
				airport.AirportName = GenRandomWord(rand.Next(1, 99));
				airport.Save();

				for (int j = 0; j < planeCount; j++)
				{
					var plane = ObjectSpace.CreateObject<Plane>();
					plane.PlaneName = GenRandomWord(rand.Next(1, 99));
					plane.Save();
					airport.Planes.Add(plane);
				}

				for(int j = 0; j < pilotCount; j++)
				{
					var pilot = ObjectSpace.CreateObject<Pilot>();
					pilot.PilotName = GenRandomWord(rand.Next(1, 99));
					pilot.Save();
					airport.Pilots.Add(pilot);
				}
				
				foreach (var plane in airport.Planes)
				{
					foreach (var pilot in plane.Pilots)
					{
						int tmpCount = rand.Next(1, pilotCount - 1);
						pilot.Planes.Add(airport.Planes[tmpCount]);
						airport.Planes[tmpCount].Pilots.Add(pilot);
					}
				}
			}
			ObjectSpace.CommitChanges();
			
		}

		private string GenRandomWord(int charNum)
		{			
			Random rand = new Random();
			sb = new StringBuilder(charNum - 1);
			int pos = 0;
			for(int i = 0; i < charNum; i++)
			{
				pos = rand.Next(0, letters.Length - 1);
				sb.Append(letters[pos]);
			}
			
			return sb.ToString();
		}


		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
		}
		protected override void OnViewControlsCreated()
		{
			base.OnViewControlsCreated();
			// Access and customize the target View control.
		}
		protected override void OnDeactivated()
		{
			// Unsubscribe from previously subscribed events and release other references and resources.
			base.OnDeactivated();
		}
	}
}
