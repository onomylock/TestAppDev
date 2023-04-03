using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TestAppDev.Module.BusinessObjects
{
	[DefaultClassOptions]
	[NavigationItem("Baza")]
	public class Plane : BaseObject
	{
		private string planeName;
		private int pilotCount;
		private Airport airport;
		public Plane(Session session)
			: base(session)
		{
		}
		public override void AfterConstruction()
		{
			base.AfterConstruction();
		}

		//[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string PlaneName
		{
			get { return planeName; }
			set { SetPropertyValue(nameof(PlaneName), ref planeName, value); }
		}

		public int PilotCount
		{
			get 
			{
				pilotCount = Pilots.Count;
				return pilotCount; 
			}
			set { SetPropertyValue(nameof(PilotCount), ref pilotCount, value); }
		}

		[DevExpress.Xpo.Association]
		public Airport Airport
		{
			get => airport;
			set => SetPropertyValue(nameof(Airport), ref airport, value);
		}

		[DevExpress.Xpo.Association("Pilots-Planes")]
		public XPCollection<Pilot> Pilots
		{
			get => GetCollection<Pilot>(nameof(Pilots));			
		}
	}
}