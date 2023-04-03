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
	public class Pilot : BaseObject
	{
		private Airport airport;
		private string pilotName;

		public Pilot(Session session)
			: base(session)
		{
		}
		public override void AfterConstruction()
		{
			base.AfterConstruction();
		}


		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string PilotName
		{
			get => this.pilotName;
			set => SetPropertyValue(nameof(PilotName), ref pilotName, value);
		}

		[DevExpress.Xpo.Association]
		public Airport Airport
		{
			get => airport;
			set => SetPropertyValue(nameof(Airport), ref airport, value);
		}

		[DevExpress.Xpo.Association("Pilots-Planes")]
		public XPCollection<Plane> Planes
		{
			get => GetCollection<Plane>(nameof(Planes));
		}
	}
}