using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TestAppDev.Module.BusinessObjects
{
	[DefaultClassOptions]
	[NavigationItem("Baza")]
	public class Airport : BaseObject
	{
		private string airportName;
		public Airport(Session session)
			: base(session)
		{
		}
		public override void AfterConstruction()
		{
			base.AfterConstruction();
		}

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string AirportName
		{
			get { return airportName; }
			set { SetPropertyValue(nameof(AirportName), ref airportName, value); }
		}

		[DevExpress.Xpo.Association]
		public XPCollection<Pilot> Pilots
		{
			get => GetCollection<Pilot>(nameof(Pilots));
		}

		[DevExpress.Xpo.Association]
		public XPCollection<Plane> Planes
		{
			get => GetCollection<Plane>(nameof(Planes));
		}
	}
}