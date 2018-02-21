using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOSBPM.Models
{
	public class BuildingApplication
	{
		public QualifyingInfo QualifyingInfoData { get; set; }

		public PropertyOwnerInfo PropertyOwnerInfoData { get; set; }

		public PropertyOwnerIndividual PropertyOwnerIndividualData { get; set; }

		public PropertyOwnerContact PropertyOwnerContactData { get; set; }
	}
}